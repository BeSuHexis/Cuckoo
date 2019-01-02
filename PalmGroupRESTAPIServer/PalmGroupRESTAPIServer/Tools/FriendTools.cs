using PalmGroupRESTAPIServer.DatabaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Tools
{
    public static class FriendTools
    {
        private static FriendsRepository friendsRepository = new FriendsRepository();
        public static bool areAlreadyFriends(int idApplicant, int idReciever)
        {
            if (friendsRepository.FindBy(x => x.IdApplicant == idApplicant && x.IdReciever==idReciever&&x.IsDeleted==false || x.IdReciever==idApplicant && x.IdApplicant==idReciever&&x.IsDeleted==false).FirstOrDefault()==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}