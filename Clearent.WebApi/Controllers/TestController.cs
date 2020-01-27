using Clearent.Interfaces;
using Clearent.Models.TestData;
using Microsoft.AspNetCore.Mvc;

namespace Clearent.WebApi.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
		private IStringReporter /* IJsonReporter *//* IXmlReporter */ Reporter { get; }

		public TestController(IStringReporter /* IJsonReporter *//* IXmlReporter */ reporter)
		{
			Reporter = reporter;
		}

	    [HttpGet("{id}")]
	    public ActionResult<string> Get(int id)
	    {
		    var (people, groupings) = TestDataFactory.GetData(id);

		    return Reporter.Report(groupings, people);
	    }
    }
}