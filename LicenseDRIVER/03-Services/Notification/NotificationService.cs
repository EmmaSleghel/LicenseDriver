using AutoMapper;
using Business.Infrastructure;
using Business.Repository;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Notification
{
   public class NotificationService:INotificationService
    {
        public IRepository<Data.Entities.Notification> notificationRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork { get; set; }

        public NotificationService(IRepository<Data.Entities.Notification> notificationRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public NotificationDto GetNotificationById(int id)
        {
            var notification = notificationRepository.GetByKey(id);
            if (notification == null) return null;
            return mapper.Map<NotificationDto>(notification);
        }
        public void CreateNotification(NotificationDto notification)
        {
            var notificationEntity = mapper.Map<Data.Entities.Notification>(notification);
            notificationRepository.Add(notificationEntity);
            unitOfWork.Commit();
        }
        public List<NotificationDto> GetAll()
        {
            var notification = notificationRepository.Query().ToList();
            return mapper.Map<List<NotificationDto>>(notification);
        }
    }
}
