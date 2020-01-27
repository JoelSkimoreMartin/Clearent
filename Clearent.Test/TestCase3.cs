using Clearent.Groupers;
using Clearent.Models;
using NUnit.Framework;
using System.Linq;

namespace Clearent.Test
{
	public class TestCase3 : TestCaseBase
	{
		public TestCase3() : base(3) { }

		private Person Person1 => GetPerson();
		private Person Person2 => GetPerson(2);
		private Wallet Wallet1 => GetWallet(Person1);
		private Wallet Wallet2 => GetWallet(Person2, 2);
		private CreditCard VisaCard1 => GetCard(Wallet1, CreditCardType.Visa);
		private CreditCard MasterCardCard1 => GetCard(Wallet1, CreditCardType.MasterCard);
		private CreditCard VisaCard2 => GetCard(Wallet2, CreditCardType.Visa);
		private CreditCard MasterCardCard2 => GetCard(Wallet2, CreditCardType.MasterCard);

		[Test]
		public void TestData_Correct()
		{
			// Validate that the test data is correct
			Assert.IsNotNull(Person1);
			Assert.IsNotNull(Person2);
			Assert.IsNotNull(Wallet1);
			Assert.IsNotNull(Wallet2);
			Assert.IsNotNull(VisaCard1);
			Assert.IsNotNull(VisaCard2);
			Assert.IsNotNull(MasterCardCard1);
			Assert.IsNotNull(MasterCardCard2);
			Assert.AreEqual(VisaCard1.Balance, 100.0M);
			Assert.AreEqual(VisaCard2.Balance, 100.0M);
			Assert.AreEqual(MasterCardCard1.Balance, 100.0M);
			Assert.AreEqual(MasterCardCard2.Balance, 100.0M);
		}

		[Test]
		public void TestData_Has_2_People()
		{
			Assert.IsNotNull(People);
			Assert.AreEqual(People.Count(), 2);
		}

		[Test]
		public void TestData_Has_2_Wallets()
		{
			Assert.IsNotNull(Person1.Wallets);
			Assert.IsNotNull(Person2.Wallets);
			Assert.AreEqual(People.SelectMany(p => p.Wallets).Count(), 2);
		}

		[TestCase(CreditCardType.Visa, 1, 1)]
		[TestCase(CreditCardType.MasterCard, 1, 1)]
		[TestCase(CreditCardType.Visa, 2, 2)]
		[TestCase(CreditCardType.MasterCard, 2, 2)]
		public void TestData_Has_Only1_(CreditCardType cardType, int personId, int walletId)
		{
			var person = GetPerson(personId);
			var wallet = GetWallet(person, walletId);

			Assert.IsNotNull(wallet);
			Assert.AreEqual(wallet.Cards.Count(c => c.Type == cardType), 1);
		}

		[Test]
		[TestCase(1, 15)]
		[TestCase(2, 15)]
		public void Calculate_ForPerson(int personId,  decimal interestRate)
		{
			var person = GetPerson(personId);

			var calculation = SimpleInterestCalculator.Calculate(person);

			Assert.AreEqual(calculation, interestRate);
		}

		[Test]
		[TestCase(1, 1, 15)]
		[TestCase(2, 2, 15)]
		public void Calculate_ByWallet_(int personId, int walletId, decimal interestRate)
		{
			var person = GetPerson(personId);
			var wallet = GetWallet(person, walletId);

			Assert.IsNotNull(wallet);

			var calculation = SimpleInterestCalculator.Calculate(wallet);

			Assert.AreEqual(calculation, interestRate);
		}
	}
}