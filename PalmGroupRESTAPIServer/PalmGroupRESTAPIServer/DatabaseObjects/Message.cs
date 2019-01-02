using PalmGroupRESTAPIServer.DatabaseRepositories;
using PalmGroupRESTAPIServer.Dto.In;
using PalmGroupRESTAPIServer.Exceptions;
using PalmGroupRESTAPIServer.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbmessages")]
    public class Message: IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdChatRoom { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public string File { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("IdUser")]
        public virtual User ObjectUser { get; set; }
        [ForeignKey("IdChatRoom")]
        public virtual ChatRoom ObjectChatRoom { get; set; }

        public Message()
        {
        }
        public Message(DtoInMessage dtoInMessage)
        {
            this.Text = dtoInMessage.Text;
            this.File = dtoInMessage.File;
            this.SendTime = System.DateTime.Now;
            this.ObjectUser = TokenTools.getUserFromToken(dtoInMessage.Token);
            ChatRoomsRepository chatRoomsRepository = new ChatRoomsRepository();          
            this.ObjectChatRoom = chatRoomsRepository.FindBy(x => x.Id == dtoInMessage.ChatRoomId&&x.IsDeleted==false).FirstOrDefault();
            if (ObjectChatRoom == null)
            {
                throw new ObjectIsNotValidException("chatroom");
            }
        }

    }
}