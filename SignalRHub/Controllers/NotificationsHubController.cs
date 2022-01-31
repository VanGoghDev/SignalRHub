using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsHubController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult NotifyUser()
        {
            NotificationsHub.SendMessage("from", "to");
            return Ok();
        }

    }
}
