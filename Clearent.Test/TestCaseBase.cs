using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.TestData;
using Clearent.Test.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Clearent.Test
{
	public class TestCaseBase
	{
		private int TestCaseId { get; }
		protected IEnumerable<Person> People { get; private set; }
		protected ISimpleInterestCalculator SimpleInterestCalculator { get; private set; }

		protected TestCaseBase(int testCaseId)
		{
			TestCaseId = testCaseId;
		}

		protected Person GetPerson(int personId = 1) =>
			People?.FirstOrDefault(p => p?.Id == personId);

		protected Wallet GetWallet(int walletId = 1) =>
			GetPerson()?.Wallets?.FirstOrDefault(w => w?.Id == walletId);

		protected Wallet GetWallet(Person person, int walletId = 1) =>
			person?.Wallets?.FirstOrDefault(w => w?.Id == walletId);

		protected CreditCard GetCard(CreditCardType cardType) =>
			GetWallet()?.Cards?.FirstOrDefault(c => c?.Type == cardType);

		protected CreditCard GetCard(Wallet wallet, CreditCardType cardType) =>
			wallet?.Cards?.FirstOrDefault(c => c?.Type == cardType);

		[SetUp]
		public void Setup()
		{
			var (people, _) = TestDataFactory.GetData(TestCaseId);

			People = people;

			var cardRepo =
				new CardRepoMock
				{
					MockData =
						new CreditCardInterestRates
						{
							[CreditCardType.Visa] = 0.1M,
							[CreditCardType.MasterCard] = 0.05M,
							[CreditCardType.Discover] = 0.01M,
						}
				};

			SimpleInterestCalculator = new SimpleInterestCalculator(cardRepo);
		}
	}
}