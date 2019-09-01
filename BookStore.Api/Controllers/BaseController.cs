using BookStore.Application.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceNotificationHandler _serviceNotificationHandler;

        public BaseController(IServiceNotificationHandler serviceNotificationHandler)
        {
            _serviceNotificationHandler = serviceNotificationHandler;
        }

        protected IActionResult ResponseBadRequest()
        {
            if (_serviceNotificationHandler.HasNotifications())
                return BadRequest(new { Errors = _serviceNotificationHandler.GetNotifications() });
            else
                return BadRequest();
        }
    }
}