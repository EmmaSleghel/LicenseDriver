using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public Guid UserId { get; set; }
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public bool Ack { get; set; }
    }
    public enum NotificationType
    {
        Request=1,
        Task=2,
        AcceptedRequest=3,
        DeniedRequest=4
    }
}
