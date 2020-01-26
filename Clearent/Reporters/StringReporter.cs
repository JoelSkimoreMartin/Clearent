using Clearent.Interfaces;
using Clearent.Models;
using Clearent.Models.Interfaces;
using Clearent.Models.Tools;
using System.Collections.Generic;
using System.Text;

namespace Clearent.Reporters
{
	public class StringReporter : BaseReporter<string>, IStringReporter
	{
		public StringReporter(Grouper grouper, ISimpleInterestCalculator simpleInterestCalculator)
			: base(grouper, simpleInterestCalculator) { }

		protected override string BuildReport(List<(Person person, decimal personInterest, List<(ICardResolver resolver, decimal resolverInterest)> items)> calculations)
		{
			var sb = new StringBuilder();

			foreach (var (person, personInterest, items) in calculations)
			{
				sb.AppendLine($"{person} has a simple interest rate of {personInterest:C}");

				foreach (var (resolver, resolverInterest) in items)
				{
					sb.AppendLine($"{resolver} has a simple interest rate of {resolverInterest:C}");
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}