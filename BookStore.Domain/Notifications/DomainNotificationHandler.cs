using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Domain.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private List<DomainNotification> _notifications { get; set; }

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Add (DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
