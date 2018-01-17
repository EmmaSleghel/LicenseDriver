using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Notification
{
    public interface INotificationService
    {
        NotificationDto GetNotificationById(int id);
        void CreateNotification(NotificationDto notification);
        List<NotificationDto> GetAll();
    }
}
