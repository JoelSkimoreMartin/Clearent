using Clearent.Groupers;
using Clearent.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Clearent.Reporters
{
	public class JsonReporter : BaseReporter<string>, IJsonReporter
	{
		public JsonReporter(IGroupCalculator groupCalculator)
			: base(groupCalculator) { }

		protected override string BuildReport(IEnumerable<GroupCalculation> calculations)
		{
			var sb = new StringBuilder();
			using var sw = new StringWriter(sb);
			using var writer = new JsonTextWriter(sw) {Formatting = Formatting.Indented};

			writer.WriteStartObject();

			writer.WriteProperty("People");

			writer.WriteStartArray();

			foreach (var calculation in calculations)
			{
				writer.WriteStartObject();

				writer.WriteProperty("Name", calculation.Person.Name);
				writer.WriteProperty("SimpleInterest", $"{calculation.PersonInterest:C}");

				var itemsCreated = false;

				foreach (var (resolver, resolverInterest) in calculation.Resolvers)
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