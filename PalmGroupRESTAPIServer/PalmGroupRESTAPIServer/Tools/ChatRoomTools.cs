using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Tools
{
    public static class ChatRoomTools
    {
        private static ChatMembersRepository _chatMemberRepository = new ChatMembersRepository();
      
        public static void Create(List<User> users)
        {
            ChatRoom chatRoom = new ChatRoom();
            chatRoom.ChatRoomPhoto = "default";
            chatRoom.Color = "default";
            foreach (User item in users)
            {
                chatRoom.Name += item.Name+" ";
                ChatMember chatMember = new ChatMember();
                chatMember.ObjectUser = item;
                chatMember.ObjectChat = chatRoom;
                _chatMemberRepository.Add(chatMember);
                _chatMemberRepository.Save();              
            }
         
       
        }
        public static List<int> getListIdChatRoomFromUser(int idUser)
        {
            List<int> result = new List<int>();
            foreach (var item in _chatMemberRepository.FindBy(y => y.IdUser == idUser && y.IsDeleted==false).ToList<ChatMember>())
            {
                result.Add(item.IdChat);

            }
            return result;
        }
    }
}