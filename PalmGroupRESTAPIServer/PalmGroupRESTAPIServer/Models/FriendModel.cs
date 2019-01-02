using AutoMapper;
using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using PalmGroupRESTAPIServer.Dto.In;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using PalmGroupRESTAPIServer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Models
{
    public class FriendModel
    {
       private UsersRepository _usersRepository = new UsersRepository();
        private FriendsRepository _friendsRepository = new FriendsRepository();
        public IDtoOutObjects AddFriend(DtoInAddFriend dtoInFriend)

        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInFriend.Token, dtoInFriend.DeviceName))
            {
                User userApplicant = TokenTools.getUserFromToken(dtoInFriend.Token);
                User userReciever = _usersRepository.FindBy(x => x.Email == dtoInFriend.EmailReciever&&x.IsDeleted==false).FirstOrDefault();
                if (userReciever == null)
                {
                    UserWithThisEmailDoesntExistException ex = new UserWithThisEmailDoesntExistException();
                    error.Exception = ex;
                    return error;
                    
                }
                if (FriendTools.areAlreadyFriends(userApplicant.Id, userReciever.Id))
                {
                    YouAreAlreadyFriendsExceptions ex = new YouAreAlreadyFriendsExceptions();
                    error.Exception = ex;
                    return error;
                }
                Friend friend = new Friend();
                friend.ObjectApplicant = userApplicant;
                friend.ObjectReciever = userReciever;
                _friendsRepository.Add(friend);
                _friendsRepository.Save();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Friend, DtoOutFriend>(); });

                IMapper mapper = config.CreateMapper();
                DtoOutFriend dtoOutFriend = new DtoOutFriend();
                mapper.Map(friend, dtoOutFriend);
                return dtoOutFriend;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
            
        }
        public IDtoOutObjects Accept(DtoInAddFriend dtoInFriend)
        {

            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInFriend.Token, dtoInFriend.DeviceName))
            {
                User acceptant = TokenTools.getUserFromToken(dtoInFriend.Token);
                Friend friend = _friendsRepository.FindBy(x => x.IdReciever == acceptant.Id && x.IsDeleted == false && x.ObjectApplicant.Email == dtoInFriend.EmailReciever).FirstOrDefault();
                if (friend == null)
                {
                    UserDoesNotAskedForFriendshipException ex = new UserDoesNotAskedForFriendshipException();
                    error.Exception = ex;
                    return error;
                }
                if (friend.Accepted == true)
                {
                    YouAreAlreadyFriendsExceptions ex = new YouAreAlreadyFriendsExceptions();
                    error.Exception = ex;
                    return error;
                }
                friend.Accepted = true;
                _friendsRepository.Edit(friend);
                _friendsRepository.Save();
                ChatRoomTools.Create(new List<User>() { acceptant, _usersRepository.FindBy(x => x.Email == dtoInFriend.EmailReciever).FirstOrDefault() });
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Friend, DtoOutFriend>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutFriend dtoOutFriend = new DtoOutFriend();
                mapper.Map(friend, dtoOutFriend);
                return dtoOutFriend;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }
        public IDtoOutObjects Delete(DtoInAddFriend dtoInFriend)
        {

            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInFriend.Token, dtoInFriend.DeviceName))
            {
                User user = TokenTools.getUserFromToken(dtoInFriend.Token);
                Friend friend = _friendsRepository.FindBy(x => x.IdReciever == user.Id && x.IsDeleted == false && x.ObjectApplicant.Email == dtoInFriend.EmailReciever ||
                                                          x.ObjectReciever.Email == dtoInFriend.EmailReciever && x.IsDeleted == false && x.IdApplicant == user.Id).FirstOrDefault();
                if (friend == null)
                {
                    UserIsNotYourFriendException ex = new UserIsNotYourFriendException();
                    error.Exception = ex;
                    return error;
                }
                 friend.IsDeleted = true;
                _friendsRepository.Edit(friend);
                _friendsRepository.Save();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Friend, DtoOutFriend>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutFriend dtoOutFriend = new DtoOutFriend();
                mapper.Map(friend, dtoOutFriend);
                return dtoOutFriend;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }

    }
}