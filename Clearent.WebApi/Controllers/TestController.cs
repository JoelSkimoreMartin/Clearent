using Clearent.Interfaces;
using Clearent.Models.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Clearent.WebApi.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
		private IStringReporter Reporter { get; }

		public TestController(IStringReporter reporter)
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