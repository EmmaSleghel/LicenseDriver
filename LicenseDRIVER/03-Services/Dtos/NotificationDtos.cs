using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dtos
{
    public class NotificationDtos
    {
        public Guid notification_id;
        public String text;
        public Guid user_id;
        public DateTime timestamp;
        public bool ack;
    }
}
