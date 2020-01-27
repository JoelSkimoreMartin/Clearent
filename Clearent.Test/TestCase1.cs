using Clearent.Groupers;
using Clearent.Models;
using NUnit.Framework;
using System.Linq;

namespace Clearent.Test
{
	public class TestCase1 : TestCaseBase
	{
		public TestCase1() : base(1) { }

		private Person Person1 => GetPerson();
		private Wallet Wallet1 => GetWallet();
		private CreditCard VisaCard => GetCard(CreditCardType.Visa);
		private CreditCard MasterCardCard => GetCard(CreditCardType.MasterCard);
		private CreditCard DiscoverCard => GetCard(CreditCardType.Discover);

		[Test]
		public void TestData_Correct()
		{
			// Validate that the test data is correct
			Assert.IsNotNull(Person1);
			Assert.IsNotNull(Wallet1);
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
		public void TestData_Has_Only1_Wallet()
		{
			Assert.IsNotNull(Person1);
			Assert.IsNotNull(Person1.Wallets);
			Assert.AreEqual(Person1.Wallets.Count(), 1);
		}

		[TestCase(CreditCardType.Visa)]
		[TestCase(CreditCardType.MasterCard)]
		[TestCase(CreditCardType.Discover)]
		public void TestData_Has_Only1_(CreditCardType cardType)
		{
			Assert.IsNotNull(Wallet1);
			Assert.AreNotEqual(cardType, CreditCardType.Unknown);
			Assert.AreEqual(Wallet1.Cards.Count(c => c.Type == cardType), 1);
		}

		[Test]
		public void Calculate_ForPerson()
		{
			var calculation = SimpleInterestCalculator.Calculate(Person1);

			Assert.AreEqual(calculation, 16.0M);
		}

		[Test]
		[TestCase(CreditCardType.Visa, 10)]
		[TestCase(CreditCardType.MasterCard, 5)]
		[TestCase(CreditCardType.Discover, 1)]
		public void Calculate_ByCard_(CreditCardType cardType, decimal interestRate)
		{
			Assert.IsNotNull(Wallet1);
			Assert.AreNotEqual(cardType, CreditCardType.Unknown);

			var creditCard = GetCard(Wallet1, cardType);

			Assert.IsNotNull(creditCard);

			var calculation = SimpleInterestCalculator.Calculate(creditCard);

			Assert.AreEqual(calculation, interestRate);
		}
	}
}