using Clearent.Groupers;
using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.TestData;
using System.Collections.Generic;
using System.Linq;

namespace Clearent.Reporters
{
	public abstract class BaseReporter<TResult> : IReporter<TResult>
	{
		private IGroupCalculator GroupCalculator { get; }

		protected BaseReporter(IGroupCalculator groupCalculator)
		{
			GroupCalculator = groupCalculator;
		}

		public TResult Report(Grouping grouping, IEnumerable<Person> people) =>
			Report(grouping, people?.ToArray() ?? new Person[0]);

		public TResult Report(Grouping grouping, params Person[] people)
		{
			var calculations = GroupCalculator.Calculate(grouping, people);

			return BuildReport(calculations);
		}

		protected abstract TResult BuildReport(IEnumerable<GroupCalculation> calculations);
	}
}