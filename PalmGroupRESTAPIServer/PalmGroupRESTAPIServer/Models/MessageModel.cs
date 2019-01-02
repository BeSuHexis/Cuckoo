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
    public class MessageModel
    {
       private MessagesRepository _messagesRepository = new MessagesRepository();
        private SeenMessagesRepository _seenMessagesRepository = new SeenMessagesRepository();

        public IDtoOutObjects Send(DtoInMessage dtoInMessage)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInMessage.Token, dtoInMessage.DeviceName))
            {
                Message message=null;
                try
                {
                     message = new Message(dtoInMessage);
                }
                catch (ObjectIsNotValidException ex)
                {
                    error.Exception = ex;
                    error.Message = "this chatroom does not exists";
                    return error;
                }
                if (ChatRoomTools.getListIdChatRoomFromUser(TokenTools.getUserFromToken(dtoInMessage.Token).Id).Contains(message.IdChatRoom))
                {
                    error.Exception = new MessageIsNotInYourListOfChatRooms();
                    error.Message = "Message is not in your list of chatRooms";
                    return error;
                }
                Message result=_messagesRepository.Add(message);
                _messagesRepository.Save(); 
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Message, DtoOutMessage>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutMessage dtoOutMessage = new DtoOutMessage();
                mapper.Map(result, dtoOutMessage);
                return dtoOutMessage;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }

        }
        public IDtoOutObjects Seen(DtoInSeenMessage dtoInSeenMessage)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInSeenMessage.Token, dtoInSeenMessage.DeviceName))
            {
                SeenMessage seenMessage = new SeenMessage();
                seenMessage.SeenTime = System.DateTime.Now;
                Message message = _messagesRepository.FindBy(x => x.Id == dtoInSeenMessage.IdMessage && x.IsDeleted == false).FirstOrDefault();
                if ( message== null)
                {
                    error.Exception = new MessageWithThisIdDoesNotExistsException();
                    error.Message = "Message with this id {"+dtoInSeenMessage.IdMessage+"} does not exists";
                    return error;
                }
                if (!ChatRoomTools.getListIdChatRoomFromUser(TokenTools.getUserFromToken(dtoInSeenMessage.Token).Id).Contains(message.IdChatRoom))
                {
                    error.Exception = new MessageIsNotInYourListOfChatRooms();
                    error.Message = "Message is not in your list of chatRooms";
                    return error;
                }
                seenMessage.IdMessage = dtoInSeenMessage.IdMessage;
                seenMessage.IdUser = TokenTools.getUserFromToken(dtoInSeenMessage.Token).Id;
                 SeenMessage result = _seenMessagesRepository.Add(seenMessage);

                var config = new MapperConfiguration(cfg => { cfg.CreateMap<SeenMessage, DtoOutSeenMessage>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutSeenMessage dtoOutSeenMessage = new DtoOutSeenMessage();
                mapper.Map(result, dtoOutSeenMessage);
                return dtoOutSeenMessage;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }

        }
        public IDtoOutObjects GetAllMessages(DtoInLogout dtoInLogout)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInLogout.Token, dtoInLogout.DeviceName))
            {
                try
                {
                    List<DtoOutMessageDetails> list = MessageTools.getMessageDetailsFromMessagesList(TokenTools.getUserFromToken(dtoInLogout.Token).Id);
                    DtoOutAllMessages result = new DtoOutAllMessages();
                    result.dtoOutMessageDetails = list;
                    return result;
                }
                catch(Exception ex)
                {
                    error.Exception = ex;
                    return error;

                }
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }

        }
        public IDtoOutObjects GetNewMessages(DtoInGetNewMessages dtoInGetNewMessages)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInGetNewMessages.Token, dtoInGetNewMessages.DeviceName))
            {
                try
                {
                    List<DtoOutMessageDetails> list = MessageTools.getMessageDetailsFromMessagesList(TokenTools.getUserFromToken(dtoInGetNewMessages.Token).Id,dtoInGetNewMessages.IdLastMessage);
                    DtoOutAllMessages result = new DtoOutAllMessages();
                    result.dtoOutMessageDetails = list;
                    return result;
                }
                catch (Exception ex)
                {
                    error.Exception = ex;
                    return error;

                }
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