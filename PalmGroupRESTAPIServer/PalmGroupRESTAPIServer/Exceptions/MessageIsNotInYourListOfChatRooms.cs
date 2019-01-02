using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class MessageIsNotInYourListOfChatRooms : Exception
    {
        public MessageIsNotInYourListOfChatRooms()
        {
        }
    }
}