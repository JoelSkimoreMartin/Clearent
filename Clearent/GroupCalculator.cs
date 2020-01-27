using Clearent.Groupers;
using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.TestData;
using System.Collections.Generic;
using System.Linq;

namespace Clearent
{
	public class GroupCalculator : IGroupCalculator
	{
		private Grouper Grouper { get; }
		private ISimpleInterestCalculator SimpleInterestCalculator { get; }

		public GroupCalculator(Grouper grouper, ISimpleInterestCalculator simpleInterestCalculator)
		{
			Grouper = grouper;
			SimpleInterestCalculator = simpleInterestCalculator;
		}

		public IEnumerable<GroupCalculation> Calculate(Grouping grouping, IEnumerable<Person> people)
		{
			var groups = Grouper.Group(grouping, people);

			return
				groups
					.Select(g =>
						new GroupCalculation
						{
							Grouping = grouping,
							Person = g.Person,
							PersonInterest = SimpleInterestCalculator.Calculate(g.Person),
							Resolvers = g.Resolvers.Select(r => (r, SimpleInterestCalculator.Calculate(r)))
								.ToList(),
						})
					.ToList();
		}
	}
}