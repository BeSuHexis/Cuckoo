using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace PalmGroupRESTAPIServer.Tools
{

    public static class MessageTools
    {
        private static MessagesRepository _messagesRepository = new MessagesRepository();
        private static SeenMessagesRepository _seenMessagesRepository = new SeenMessagesRepository();
        private static UsersRepository _usersRepository = new UsersRepository();
        public static List<Message> getAllMessages(int idUser)
        { if (_usersRepository.FindBy(x => x.Id== idUser && x.IsDeleted == false).FirstOrDefault()==null)
            {
                throw new UserWithThisIdDoesNotExists();
            }
            List<Message> messages = new List<Message>();
            foreach (int item in ChatRoomTools.getListIdChatRoomFromUser(idUser))
            {
               messages.AddRange( _messagesRepository.FindBy(x => x.IsDeleted == false && x.IdChatRoom == item).ToList());
            }
            return messages;
            
        }

        public static List<Message> getAllMessages(int idUser, int idLastMessage)
        {
            if (_usersRepository.FindBy(x => x.Id == idUser && x.IsDeleted == false).FirstOrDefault() == null)
            {
                throw new UserWithThisIdDoesNotExists();
            }
            List<Message> messages = new List<Message>();
            foreach (int item in ChatRoomTools.getListIdChatRoomFromUser(idUser))
            {
                messages.AddRange(_messagesRepository.FindBy(x => x.IsDeleted == false && x.IdChatRoom == item && x.Id>idLastMessage).ToList());
            }
            return messages;

        }
        public static List<DtoOutMessageDetails> getMessageDetailsFromMessagesList(int idUser)
        {
            List<Message> messages = getAllMessages(idUser);
            List<SeenMessage> seenMessages = new List<SeenMessage>();
            List<DtoOutMessageDetails> result = new List<DtoOutMessageDetails>();
            List<Message> messagestmp = new List<Message>();
            foreach (Message item in messages)
            {
                SeenMessage message =_seenMessagesRepository.FindBy(x => x.IsDeleted == false && x.IdMessage == item.Id).FirstOrDefault();
                if (message == null)
                {
                    messagestmp.Add(item);
                }
                else
                {
                    seenMessages.Add(message);
                }
            }
            foreach (SeenMessage item in seenMessages)
            {
                result.Add(new DtoOutMessageDetails(item));
            }
            foreach (Message item in messagestmp)
            {
                result.Add(new DtoOutMessageDetails(item));
            }
            return result;
        }
        public static List<DtoOutMessageDetails> getMessageDetailsFromMessagesList(int idUser, int idLastMessage)
        {
            List<Message> messages = getAllMessages(idUser,idLastMessage);
            List<SeenMessage> seenMessages = new List<SeenMessage>();
            List<DtoOutMessageDetails> result = new List<DtoOutMessageDetails>();
            List<Message> messagestmp = new List<Message>();
            foreach (Message item in messages)
            {
                SeenMessage message = _seenMessagesRepository.FindBy(x => x.IsDeleted == false && x.IdMessage == item.Id).FirstOrDefault();
                if (message == null)
                {
                    messagestmp.Add(item);
                }
                else
                {
                    seenMessages.Add(message);
                }
            }
            foreach (SeenMessage item in seenMessages)
            {
                result.Add(new DtoOutMessageDetails(item));
            }
            foreach (Message item in messagestmp)
            {
                result.Add(new DtoOutMessageDetails(item));
            }
            return result;
        }
    }
}