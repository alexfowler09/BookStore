using System.Collections.Generic;

namespace BookStore.Domain.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Add(DomainNotification domainNotification);
        bool HasNotifications();
        List<DomainNotification> GetNotifications();
    }
}
