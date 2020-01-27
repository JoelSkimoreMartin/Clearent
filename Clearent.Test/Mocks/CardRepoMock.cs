using Clearent.Models;
using Clearent.Repo.Interfaces;

namespace Clearent.Test.Mocks
{
	internal class CardRepoMock : ICardRepo
	{
		public CreditCardInterestRates MockData { get; set; }

		public CreditCardInterestRates LoadInterestRates() => MockData;
	}
}