using Business.Repository;
using System;
using AutoMapper;
using Services.Dtos;
using Data.Entities;
using Business.Infrastructure;

namespace Services
{
    public class UserService: IUserService
    {
        public IRepository<User> _userRepository { get; set; }
        private  IMapper _mapper { get; set; }
        private IUnitOfWork _unitOfWork { get; set; }
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public UserDto GetUserById(Guid id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetByKey(id));

        }
        public void  CreateUser(UserDto user)
        {
            _userRepository.Add(_mapper.Map<User>(user));
            _unitOfWork.Commit();
        }
    }
}
