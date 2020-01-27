using Clearent.Models;
using Clearent.Models.TestData;
using System.Collections.Generic;

namespace Clearent.Interfaces
{
	public interface IReporter<out TResult>
	{
		TResult Report(Grouping grouping, IEnumerable<Person> people);
		TResult Report(Grouping grouping, params Person[] people);
	}

	public interface IStringReporter : IReporter<string> { }

	public interface IJsonReporter : IReporter<string> { }

	public interface IXmlReporter : IReporter<string> { }
}