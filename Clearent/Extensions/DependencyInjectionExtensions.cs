using Clearent.Interfaces;
using Clearent.Models.Tools;
using Clearent.Repo;
using Clearent.Reporters;
using Microsoft.Extensions.DependencyInjection;

namespace Clearent
{
	public static class DependencyInjectionExtensions
	{
		private static bool IsAdded { get; set; }

		public static void AddClearentTest(this IServiceCollection services)
		{
			if (IsAdded)
				return;

			services.AddClearentTestRepo();
			services.AddSingleton<Grouper>();
			services.AddSingleton<ISimpleInterestCalculator, SimpleInterestCalculator>();
			services.AddSingleton<IStringReporter, StringReporter>();
			services.AddSingleton<IJsonReporter, JsonReporter>();
			services.AddSingleton<IXmlReporter, XmlReporter>();

			IsAdded = true;
		}
	}
}