using Clearent.Groupers;
using Clearent.Interfaces;
using System.Collections.Generic;
using System.Xml;

namespace Clearent.Reporters
{
	public class XmlReporter : BaseReporter<string>, IXmlReporter
	{
		public XmlReporter(IGroupCalculator groupCalculator)
			: base(groupCalculator) { }

		protected override string BuildReport(IEnumerable<GroupCalculation> calculations)
		{
			var doc = new XmlDocument();
			doc.LoadXml("<credit-card-interest />");

			foreach (var calculation in calculations)
			{
				var personNode = doc.DocumentElement.AppendChild("person");

				personNode.AppendChild("name", calculation.Person.Name);
				personNode.AppendChild("simple-interest", $"{calculation.PersonInterest:C}");

				XmlElement itemsNode = null;

				foreach (var (resolver, resolverInterest) in calculation.Resolvers)
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