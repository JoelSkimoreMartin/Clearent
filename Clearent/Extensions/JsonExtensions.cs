using Newtonsoft.Json;

namespace Clearent
{
	internal static class JsonExtensions
	{
		public static void WriteProperty(this JsonTextWriter writer, string name, string value = null)
		{
			writer.WritePropertyName(name);

			if (string.IsNullOrWhiteSpace(value) == false)
				writer.WriteValue(value);
		}
	}
}