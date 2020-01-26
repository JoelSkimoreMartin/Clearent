using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.Interfaces;
using Clearent.Models.Tools;
using System.Collections.Generic;
using System.Xml;

namespace Clearent.Reporters
{
	public class XmlReporter : BaseReporter<string>, IXmlReporter
	{
		public XmlReporter(Grouper grouper, ISimpleInterestCalculator simpleInterestCalculator)
			: base(grouper, simpleInterestCalculator) { }

		protected override string BuildReport(List<(Person person, decimal personInterest, List<(ICardResolver resolver, decimal resolverInterest)> items)> calculations)
		{
			var doc = new XmlDocument();
			doc.LoadXml("<credit-card-interest />");

			foreach (var (person, personInterest, items) in calculations)
			{
				var personNode = doc.DocumentElement.AppendChild("person");

				personNode.AppendChild("name", person.Name);
				personNode.AppendChild("simple-interest", $"{personInterest:C}");

				XmlElement itemsNode = null;

				foreach (var (resolver, resolverInterest) in items)
				{
					if (itemsNode == null)
						itemsNode = personNode.AppendChild(resolver.GetType().Name.ToLower() + "s");

					var itemNode = itemsNode.AppendChild(resolver.GetType().Name.ToLower());

					itemNode.AppendChild("name", resolver.Name);
					itemNode.AppendChild("simple-interest", $"{resolverInterest:C}");
				}
			}

			return doc.PrettyPrint();
		}
	}
}