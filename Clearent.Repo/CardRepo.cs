using Clearent.Models;
using Clearent.Repo.Interfaces;

namespace Clearent.Repo
{
	public class CardRepo : ICardRepo
	{
		private IJsonRepo JsonRepo { get; }

		public CardRepo(IJsonRepo jsonRepo)
		{
			JsonRepo = jsonRepo;
		}

		public CreditCardInterestRates LoadInterestRates()
		{
			var dataSource = JsonRepo.Read();

			return dataSource?.InterestRates ?? new CreditCardInterestRates();
		}
	}
}