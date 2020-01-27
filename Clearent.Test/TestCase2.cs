using Clearent.Groupers;
using Clearent.Models;
using NUnit.Framework;
using System.Linq;

namespace Clearent.Test
{
	public class TestCase2 : TestCaseBase
	{
		public TestCase2() : base(2) { }

		private Person Person1 => GetPerson();
		private Wallet Wallet1 => GetWallet();
		private Wallet Wallet2 => GetWallet(2);
		private CreditCard VisaCard => GetCard(Wallet1, CreditCardType.Visa);
		private CreditCard MasterCardCard => GetCard(Wallet2, CreditCardType.MasterCard);
		private CreditCard DiscoverCard => GetCard(Wallet1, CreditCardType.Discover);

		[Test]
		public void TestData_Correct()
		{
			// Validate that the test data is correct
			Assert.IsNotNull(Person1);
			Assert.IsNotNull(Wallet1);
			Assert.IsNotNull(Wallet2);
			Assert.IsNotNull(VisaCard);
			Assert.IsNotNull(MasterCardCard);
			Assert.IsNotNull(DiscoverCard);
			Assert.AreEqual(VisaCard.Balance, 100.0M);
			Assert.AreEqual(MasterCardCard.Balance, 100.0M);
			Assert.AreEqual(DiscoverCard.Balance, 100.0M);
		}

		[Test]
		public void TestData_Has_Only1_Person()
		{
			Assert.IsNotNull(People);
			Assert.AreEqual(People.Count(), 1);
		}

		[Test]
		public void TestData_Has_2_Wallets()
		{
			Assert.IsNotNull(Person1.Wallets);
			Assert.AreEqual(Person1.Wallets.Count(), 2);
		}

		[TestCase(CreditCardType.Visa, 1)]
		[TestCase(CreditCardType.MasterCard, 2)]
		[TestCase(CreditCardType.Discover, 1)]
		public void TestData_Has_Only1_(CreditCardType cardType, int walletId)
		{
			var wallet = GetWallet(Person1, walletId);

			Assert.IsNotNull(wallet);
			Assert.AreEqual(wallet.Cards.Count(c => c.Type == cardType), 1);
		}

		[Test]
		public void Calculate_ForPerson()
		{
			var calculation = SimpleInterestCalculator.Calculate(Person1);

			Assert.AreEqual(calculation, 16.0M);
		}

		[Test]
		[TestCase(1, 11)]
		[TestCase(2, 5)]
		public void Calculate_ByWallet_(int walletId, decimal interestRate)
		{
			var wallet = GetWallet(Person1, walletId);

			Assert.IsNotNull(wallet);

			var calculation = SimpleInterestCalculator.Calculate(wallet);

			Assert.AreEqual(calculation, interestRate);
		}
	}
}