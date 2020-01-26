using Clearent.Repo.DataSources.Json;

namespace Clearent.Repo.Interfaces
{
	public interface IJsonRepo
	{
		DataSource Read();
		void Write(DataSource dataSource);
	}
}