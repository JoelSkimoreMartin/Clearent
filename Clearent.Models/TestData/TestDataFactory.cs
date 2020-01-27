using System;
using System.Collections.Generic;
using System.Linq;

namespace Clearent.Models.TestData
{
	public static class TestDataFactory
	{
		public static (IEnumerable<Person> people, Grouping groupings) GetData(int id)
		{
			var data = GetPeople(id);
			var grouping = GetGrouping(id);

			data.SelectMany(d => d.Cards).ToList().ForEach(c => c.Balance = 100.0M);

			return (data, grouping);
		}

		private static Grouping GetGrouping(int id)
		{
			switch (id)
			{
				case 1: return Grouping.ByCard;
				case 2: return Grouping.ByWallet;
				case 3: return Grouping.ByWallet;
				default:
					throw new ArgumentOutOfRangeException(nameof(id));
			}
		}

		private static List<Person> GetPeople(int id)
		{
			switch (id)
			{
				// 1 person has 1 wallet and 3 cards (1 Visa, 1 MC 1 Discover)
				// Each Card has a balance of $100
				// Calculate the total interest (simple interest) for this person and per card. 
				case 1:
					return
						new List<Person>
						{
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
													CreditCardType.Visa,
													CreditCardType.MasterCard,
													CreditCardType.Discover,
												}
										}
									},
							}

						};

				// 1 person has 2 wallets
				// Wallet 1 has a Visa and Discover
				// Wallet 2 a MC
				// Each card has $100 balance
				// Calculate the total interest(simple interest) for this person and interest per wallet
				case 2:
					return
						new List<Person>
						{
							// 1 person has 2 wallets
							new Person
							{
								Wallets =
									new List<Wallet>
									{
										// Wallet 1 has a Visa and Discover
										new Wallet
										{
											Cards =
												new List<CreditCard>
												{
													CreditCardType.Visa,
													CreditCardType.Discover,
												}
										},
										// Wallet 2 a MC
										new Wallet
										{
											Id = 2,
											Cards =
												new List<CreditCard>
												{
													CreditCardType.MasterCard,
												}
										}
									},
							}

						};

				// 2 people have 1 wallet each
				// Person 1 has 1 wallet , with 2 cards MC and visa
				// Person 2 has 1 wallet – 1 visa and 1 MC
				// Each card has $100 balance
				// Calculate the total interest(simple interest) for each person and interest per wallet
				case 3:
					return
						new List<Person>
						{
							// Person 1 has 1 wallet , with 2 cards MC and visa
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
													CreditCardType.Visa,
												}
										},
									},
							},
							// Person 2 has 1 wallet – 1 visa and 1 MC
							new Person
							{
								Id = 2,
								Wallets =
									new List<Wallet>
									{
										new Wallet
										{
											Id = 2,
											Cards =
												new List<CreditCard>
												{
													CreditCardType.Visa,
													CreditCardType.MasterCard,
												}
										},
									},
							}
						};

				default:
					throw new ArgumentOutOfRangeException(nameof(id));
			}
		}
	}
}