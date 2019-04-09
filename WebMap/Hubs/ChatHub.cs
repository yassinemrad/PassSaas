using System;
using System.Collections.Generic;
using System.Linq;
using DomainMap.Entities;
using Microsoft.AspNet.SignalR;
using WebMap.Models;
using Microsoft.AspNet.Identity;
using WebMap.Controllers;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

using System.Data;
using System.Diagnostics;

namespace WebMap.Hubs
{



    public class ChatHub : Hub
    {
     

        static List<Users> ConnectedUsers = new List<Users>();
        static List<Messages> CurrentMessage = new List<Messages>();
        ConnClass ConnC = new ConnClass();
        Random rnd = new Random();
      public static string usern { get; set; } 
        public void Connect(string userName,int user2)
        {
            usern  = Context.ConnectionId;
            if (ConnectedUsers.Count(x => x.UserName.Equals(userName)).Equals(0)) 
            {
                string UserImg = GetUserImage(userName);
                string logintime = DateTime.Now.ToString();
                ConnectedUsers.Add(new Users { ConnectionId = usern, UserName = userName, UserImage = UserImg, LoginTime = logintime });
                // send to caller
                Clients.Caller.onConnected(usern, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(usern).onNewUserConnected(usern, userName, UserImg, logintime);
            }
        }

        

        public void SendMessageToAll(string userName, string message, string time)
        {
            string UserImg = GetUserImage(userName);
            // store last 100 messages in cache
            AddMessageinCache(userName, message, time, UserImg);

            // Broad cast message
            Clients.All.messageReceived(userName, message, time, UserImg);

        }

        private void AddMessageinCache(string userName, string message, string time, string UserImg)
        {
            CurrentMessage.Add(new Messages { UserName = userName, Message = message, Time = time, UserImage = UserImg });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
           
        }

        // Clear Chat History
        public void clearTimeout()
        {
            CurrentMessage.Clear();
        }

        public string GetUserImage(string username)
        {
            string RetimgName = "/images/dummy.png";
            try
            {
                string query = "select Image from Users where FirstName='" + username + "'";
                string ImageName = ConnC.GetColumnVal(query, "Image");

                if (ImageName != "")
                    RetimgName = "/images/DP/" + ImageName;
            }
            catch (Exception ex)
            { }
            return RetimgName;
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {

            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId.Equals(usern));
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                   var id =usern;
                Clients.All.onUserDisconnected(usern, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }

        public void SendPrivateMessage(string toUserId, string message,string user)
        {
            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId.Equals(toUserId));
            Debug.WriteLine("to user" + toUser.ConnectionId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId .Equals(usern));
            string fromUserId = fromUser.ConnectionId;
            Debug.WriteLine("from user" + fromUser.ConnectionId);
            if (toUser != null && fromUser != null)
            {
                string CurrentDateTime = DateTime.Now.ToString();
                string UserImg = GetUserImage(fromUser.UserName);
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message, UserImg, CurrentDateTime);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message, UserImg, CurrentDateTime);
             
            }

        }
    }
}