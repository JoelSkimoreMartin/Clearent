using Clearent.Models;

namespace Clearent.Repo.Interfaces
{
	public interface ICardRepo
	{
		CreditCardInterestRates LoadInterestRates();
	}
}