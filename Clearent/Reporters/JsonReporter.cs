using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.Interfaces;
using Clearent.Models.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Clearent.Reporters
{
	public class JsonReporter : BaseReporter<string>, IJsonReporter
	{
		public JsonReporter(Grouper grouper, ISimpleInterestCalculator simpleInterestCalculator)
			: base(grouper, simpleInterestCalculator) { }

		protected override string BuildReport(List<(Person person, decimal personInterest, List<(ICardResolver resolver, decimal resolverInterest)> items)> calculations)
		{
			var sb = new StringBuilder();
			var sw = new StringWriter(sb);

			using var writer = new JsonTextWriter(sw) {Formatting = Formatting.Indented};

			writer.WriteStartObject();

			writer.WriteProperty("People");

			writer.WriteStartArray();

			foreach (var (person, personInterest, items) in calculations)
			{
				writer.WriteStartObject();

				writer.WriteProperty("Name", person.Name);
				writer.WriteProperty("SimpleInterest", $"{personInterest:C}");

				var itemsCreated = false;

				foreach (var (resolver, resolverInterest) in items)
				{
					if (itemsCreated == false)
					{
						itemsCreated = true;

						writer.WriteProperty(resolver.GetType().Name + "s");
						writer.WriteStartArray();
					}

					writer.WriteStartObject();

					writer.WriteProperty("Name", resolver.Name);
					writer.WriteProperty("SimpleInterest", $"{resolverInterest:C}");

					writer.WriteEndObject();
				}

				if (itemsCreated)
					writer.WriteEndArray();

				writer.WriteEndObject();
			}

			writer.WriteEndArray();

			writer.WriteEndObject();

			return sb.ToString();
		}
    }
}