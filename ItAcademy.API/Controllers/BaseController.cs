using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.API.Controllers
{
    [ApiController]
    [Route("API/v{version:apiVersion}/[Controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
    }
}
