using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dtos
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public Guid UserId { get; set; }
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public bool Ack { get; set; }

    }
}
