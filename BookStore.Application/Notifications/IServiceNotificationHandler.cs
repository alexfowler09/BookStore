using System.Collections.Generic;

namespace BookStore.Application.Notifications
{
    public interface IServiceNotificationHandler
    {
        void Add(ServiceNotification domainNotification);
        bool HasNotifications();
        List<ServiceNotification> GetNotifications();
    }
}
