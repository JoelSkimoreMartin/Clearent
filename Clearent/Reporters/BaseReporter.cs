using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.Interfaces;
using Clearent.Models.Tools;
using System.Collections.Generic;
using System.Linq;

namespace Clearent.Reporters
{
	public abstract class BaseReporter<TResult> : IReporter<TResult>
	{
		private Grouper Grouper { get; }
		private ISimpleInterestCalculator SimpleInterestCalculator { get; }

		protected BaseReporter(Grouper grouper, ISimpleInterestCalculator simpleInterestCalculator)
		{
			Grouper = grouper;
			SimpleInterestCalculator = simpleInterestCalculator;
		}

		public TResult Report(Grouping grouping, IEnumerable<Person> people) =>
			Report(grouping, people?.ToArray() ?? new Person[0]);

		public TResult Report(Grouping grouping, params Person[] people)
		{
			var groups = Grouper.Group(grouping, people);

			var calculations =
				new List<(Person person, decimal personInterest, List<(ICardResolver resolver, decimal resolverInterest)> items)>();

			foreach (var group in groups)
			{
				var items =
					group.Resolvers
						.Select(r => (r, SimpleInterestCalculator.Calculate(r)))
						.ToList();

				var personInterest = SimpleInterestCalculator.Calculate(group.Person);

				calculations.Add((group.Person, personInterest, items));

			}

			return BuildReport(calculations);
		}

		protected abstract TResult BuildReport(List<(Person person, decimal personInterest, List<(ICardResolver resolver, decimal resolverInterest)> items)> calculations);
	}
}