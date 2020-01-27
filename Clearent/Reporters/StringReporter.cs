using Clearent.Groupers;
using Clearent.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Clearent.Reporters
{
	public class StringReporter : BaseReporter<string>, IStringReporter
	{
		public StringReporter(IGroupCalculator groupCalculator)
			: base(groupCalculator) { }

		protected override string BuildReport(IEnumerable<GroupCalculation> calculations)
		{
			var sb = new StringBuilder();

			foreach (var calculation in calculations)
			{
				sb.AppendLine($"{calculation.Person} has a simple interest rate of {calculation.PersonInterest:C}");

				foreach (var (resolver, resolverInterest) in calculation.Resolvers)
				{
					sb.AppendLine($"{resolver} has a simple interest rate of {resolverInterest:C}");
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}