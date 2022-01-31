using System;
using Microsoft.AspNetCore.Mvc;
using SignalRHub.Hubs;

namespace SignalRHub.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly Lazy<IHub> _notificationsHub;
        protected IHub NotificationsHub => _notificationsHub.Value;

        public BaseController()
        {
            _notificationsHub = new Lazy<IHub>(() => new NotificationsHub());
        }

        public BaseController(IHub notificationsHub)
        {
            if (notificationsHub == null) throw new ArgumentNullException(nameof(notificationsHub));
            _notificationsHub = new Lazy<IHub>(() => notificationsHub);
        }
    }
}
