using Clearent.Models;
using Clearent.Models.TestData;
using Clearent.Repo.Interfaces;
using Clearent.Test.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clearent.Test
{
	public class TestFailures
	{
		protected ICardRepo CardRepo { get; private set; }
		protected ICardRepo CardRepo_Incomplete { get; private set; }

		[SetUp]
		public void Setup()
		{
			CardRepo =
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

			CardRepo_Incomplete =
				new CardRepoMock
				{
					MockData =
						new CreditCardInterestRates
						{
							[CreditCardType.Visa] = 0.1M,
							//[CreditCardType.MasterCard] = 0.05M,
							[CreditCardType.Discover] = 0.01M,
						}
				};
		}

		[Test]
		public void Fail_Null_CardRepo()
		{
			var calculator = new SimpleInterestCalculator(null);

			var validData = TestDataFactory.GetData(1).people.ToArray();

			Assert.Throws(
				Is.TypeOf<NullReferenceException>()
					.And.Message.EqualTo("CardRepo is null"),
				() =>
				{
					var calculation = calculator.Calculate(validData);
				});
		}

		[Test]
		public void Fail_Null_Resolvers()
		{
			var calculator = new SimpleInterestCalculator(CardRepo);

			Assert.Throws(
				Is.TypeOf<ArgumentNullException>()
					.And.Message.EqualTo("Value cannot be null. (Parameter 'resolvers')"),
				() =>
				{
					var calculation = calculator.Calculate(null);
				});
		}

		[Test]
		public void Fail_Null_CreditCard()
		{
			var calculator = new SimpleInterestCalculator(CardRepo);

			var nullCards =
				new Person
				{
					Wallets =
						new List<Wallet>
						{
							new Wallet
							{
								Cards =
									new List<CreditCard>
									{
										null,
									},
							}
						},
				};

			Assert.Throws(
				Is.TypeOf<ArgumentException>()
					.And.Message.EqualTo("Cannot have null credit cards"),
				() =>
				{
					var calculation = calculator.Calculate(nullCards);
				});
		}

		[Test]
		public void Fail_Missing_InterestRate()
		{
			var calculator = new SimpleInterestCalculator(CardRepo_Incomplete);

			var person =
				new Person
				{
					Wallets =
						new List<Wallet>
						{
							new Wallet
							{
								Cards =
									new List<CreditCard>
									{
										CreditCardType.MasterCard,
									},
							}
						},
				};

			Assert.Throws(
				Is.TypeOf<ArgumentException>()
					.And.Message.EqualTo("Interest rate(s) do not exist for: MasterCard"),
				() =>
				{
					var calculation = calculator.Calculate(person);
				});
		}
	}
}