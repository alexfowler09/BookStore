using System.Collections.Generic;

namespace BookStore.Application.Notifications
{
    public interface IServiceNotificationHandler
    {
        void Add(ServiceNotification serviceNotification);
        bool HasNotifications();
        List<ServiceNotification> GetNotifications();
    }
}
