using Clearent.Repo.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Clearent.Repo
{
	public static class DependencyInjectionExtensions
	{
		private static bool IsAdded { get; set; }

		public static void AddClearentTestRepo(this IServiceCollection services)
		{
			if (IsAdded)
				return;

			services.AddTransient<IJsonRepo, JsonRepo>();
			services.AddTransient<ICardRepo, CardRepo>();

			IsAdded = true;
		}
	}
}