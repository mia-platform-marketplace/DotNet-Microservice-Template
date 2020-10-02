using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Decorators;
using MiaServiceDotNetLibrary.Environment;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ServiceStatusController
    {
        public TemplateController(MiaEnvConfiguration miaEnvConfiguration, ServiceClientFactory serviceClientFactory,
            DecoratorResponseFactory decoratorResponseFactory) : base(miaEnvConfiguration, serviceClientFactory,
            decoratorResponseFactory)
        {
        }

        /*
        * Insert your code here.
        */
    }
}
