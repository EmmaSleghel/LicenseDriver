using System;
using System.Collections.Generic;
using System.Text;
using Services.Dtos;

namespace Services.Notification
{
    class NotificationService:INotificationService
    {
        private Guid notification_id;
        private String text;
        private Guid user_id;
        private DateTime timestamp;
        private bool ack;

        private  void Notification(Guid notification_id, string text, Guid user_id, DateTime timestamp, bool ack)
        {
            this.notification_id = notification_id;
            this.text = text;
            this.user_id = user_id;
            this.timestamp = timestamp;
            this.ack = ack;
        }

        public void add_notification(Guid user_id, String text)
        {
            NotificationDtos newNotification = new NotificationDtos(new Guid(), text, user_id, DateTime.Now, false);
            //insert in db newNotification

            /*this.user_id = user_id;
            this.text = text;
            this.ack = false;
            this.timestamp=DateTime.Now;
            this.notification_id=new Guid();*/
            //add in db
        }

        public NotificationDtos[] GetNotifications(Guid user_id)
        {
            //return notifications
        }

        public void Ack_notification(Guid notification_id)
        {
            //get notif by notification_id
            //update ack=true
        }
    }
}
