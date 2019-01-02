using PalmGroupRESTAPIServer.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutMessageDetails : IDtoOutObjects
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdChatRoom { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public string File { get; set; }
        public int IdSeenUser { get; set; }
        public DateTime SeenTime { get; set; }

        public DtoOutMessageDetails(SeenMessage seenMessage)
        {
            this.Id = seenMessage.ObjectMessage.Id;
            this.IdUser = seenMessage.ObjectMessage.IdUser;
            this.IdChatRoom = seenMessage.ObjectMessage.IdChatRoom;
            this.Text = seenMessage.ObjectMessage.Text;
            this.SendTime = seenMessage.ObjectMessage.SendTime;
            this.File = seenMessage.ObjectMessage.File;
            this.IdSeenUser = seenMessage.IdUser;
            this.SeenTime = seenMessage.SeenTime;
        }

        public DtoOutMessageDetails(Message message)
        {
            this.Id = message.Id;
            this.IdUser = message.IdUser;
            this.IdChatRoom = message.IdChatRoom;
            this.Text = message.Text;
            this.SendTime = message.SendTime;
            this.File = message.File;
        }
    }
}