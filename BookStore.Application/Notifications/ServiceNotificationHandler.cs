﻿using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.Notifications
{
    public class ServiceNotificationHandler : IServiceNotificationHandler
    {
        private List<ServiceNotification> _notifications { get; set; }

        public ServiceNotificationHandler()
        {
            _notifications = new List<ServiceNotification>();
        }

        public void Add(ServiceNotification serviceNotification)
        {
            _notifications.Add(serviceNotification);
        }

        public List<ServiceNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
