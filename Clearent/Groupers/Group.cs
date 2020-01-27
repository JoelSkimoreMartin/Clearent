using Clearent.Models;
using Clearent.Models.Interfaces;
using Clearent.Models.TestData;
using System.Collections.Generic;

namespace Clearent.Groupers
{
	public class Group
	{
		public Person Person { get; }
		public IEnumerable<ICardResolver> Resolvers { get; }

		internal Group(Person person, Grouping grouping)
		{
			Person = person;
			Resolvers = LoadResolvers(this, grouping);
		}

		private static IEnumerable<ICardResolver> LoadResolvers(Group group, Grouping grouping)
		{
			switch (grouping)
			{
				case Grouping.ByWallet:
					return group.Person.Wallets;

				case Grouping.ByCard:
					return group.Person.Cards;

				default:
					return new ICardResolver[0];
			}
		}
	}
}