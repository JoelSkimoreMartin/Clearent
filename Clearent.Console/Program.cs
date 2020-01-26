using Clearent.Models.Tools;
using Clearent.Repo;
using Clearent.Reporters;

namespace Clearent.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			//var interestRates = new CardRepo(new JsonRepo()).LoadInterestRates();

			var reporter = new StringReporter(new Grouper(), new SimpleInterestCalculator(new CardRepo(new JsonRepo())));

			var (people, groupings) = TestDataFactory.GetData(1);

			var output = reporter.Report(groupings, people);

			//var testCase1 = TestDataFactory.GetData(1).ToArray()[0];

			//var perPerson = calculator.Calculate(testCase1);
			//foreach (var card in testCase1.Cards)
			//{
			//	var perCard = calculator.Calculate(card);
			//}
			//var forWallet1 = calculator.Calculate(testCase1.Wallets.ToArray()[0]);
			//var forWallet2 = calculator.Calculate(testCase1.Wallets.ToArray()[1]);
		}
	}
}