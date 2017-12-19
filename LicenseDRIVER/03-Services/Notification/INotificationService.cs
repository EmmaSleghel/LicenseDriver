using System;
using Services.Dtos;
using System.Collections.Generic;
using System.Text;

namespace Services.Notification
{
    public interface INotificationService
    {
        void add_notification(Guid user_id, String text);
        NotificationDtos[] GetNotifications(Guid user_id);
        void Ack_notification(Guid notification_id);

    }
}
