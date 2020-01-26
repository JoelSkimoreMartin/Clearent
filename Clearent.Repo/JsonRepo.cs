using Clearent.Repo.DataSources.Json;
using Clearent.Repo.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace Clearent.Repo
{
	public class JsonRepo : IJsonRepo
	{
		private static readonly string Directory = new FileInfo(typeof(JsonRepo).Assembly.Location).Directory?.FullName;
		private static readonly string JsonFileName = Path.Combine(Directory, "DataSources", "Json", "DataSource.json");

		public DataSource Read()
		{
			try
			{
				return
					File.Exists(JsonFileName) == false
						? null
						: JsonConvert.DeserializeObject<DataSource>(File.ReadAllText(JsonFileName));
			}
			catch
			{
				return null;
			}
		}

		public void Write(DataSource dataSource)
		{
			if (dataSource == null)
			{
				File.Delete(JsonFileName);
				return;
			}

			File.WriteAllText(JsonFileName, JsonConvert.SerializeObject(dataSource));
		}
	}
}