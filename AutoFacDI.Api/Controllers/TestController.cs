using AutoFacDI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoFacDI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISingletonServices _singletonServices;
        private readonly IScopeServices _scopeServices;

        public TestController(ISingletonServices singletonServices, IScopeServices scopeServices)
        {
            _singletonServices = singletonServices;
            _scopeServices = scopeServices;
        }

        public IActionResult Sum()
        {
            return Ok(new {singleton = _singletonServices.GetId() , scope = _scopeServices.GetId()});
        }
    }
}
