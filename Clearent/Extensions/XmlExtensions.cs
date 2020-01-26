using System.IO;
using System.Text;
using System.Xml;

namespace Clearent
{
	internal static class XmlExtensions
	{
		public static XmlElement AppendChild(this XmlElement element, string name, string value = null)
		{
			var childElement = element.OwnerDocument.CreateElement(name);

			if (string.IsNullOrWhiteSpace(value) == false)
				childElement.InnerText = value;

			element.AppendChild(childElement);

			return childElement;
		}

		public static string PrettyPrint(this XmlDocument xml)
		{
			using var mStream = new MemoryStream();
			using var writer = new XmlTextWriter(mStream, Encoding.Unicode);

			var prettyDoc = new XmlDocument();

			// Load the XmlDocument with the XML.
			prettyDoc.LoadXml(xml.OuterXml);

			writer.Formatting = Formatting.Indented;

			// Write the XML into a formatting XmlTextWriter
			prettyDoc.WriteContentTo(writer);
			writer.Flush();
			mStream.Flush();

			// Have to rewind the MemoryStream in order to read
			// its contents.
			mStream.Position = 0;

			// Read MemoryStream contents into a StreamReader.
			using var sReader = new StreamReader(mStream);
			return sReader.ReadToEnd();
		}
	}
}