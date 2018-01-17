using Data.Entities;
using System;


namespace LicenseDRIVER.Models
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }
        public Guid UserId { get; set; }
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public bool Ack { get; set; }

    }
}
