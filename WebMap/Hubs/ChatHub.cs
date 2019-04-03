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
using Hanssens.Net;
using System.Data;

namespace WebMap.Hubs
{
    


public class ChatHub :Hub
    {

       
        //   string id = System.Web.HttpContext.Current.User.Identity.GetUserId();
        string id = System.Web.HttpContext.Current.User.Identity.GetUserId();
        static List<Users> ConnectedUsers = new List<Users>();
        static List<Messages> CurrentMessage = new List<Messages>();
        ConnClass ConnC = new ConnClass();
      
        public void Connect(string userName)
        {
         //   Session["idU"] = User.Identity.GetUserId();
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
             var id = System.Web.HttpContext.Current.User.Identity.GetUserId();

            //   var userrrr = System.Web.HttpContext.Current.User.Identity.GetUserName();
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                string UserImg = GetUserImage(userName);
                string logintime = DateTime.Now.ToString();
                ConnectedUsers.Add(new Users { ConnectionId = id, UserName = userName, UserImage = UserImg, LoginTime = logintime });
                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName, UserImg, logintime);
            }
        }

        public void SendMessageToAll(string userName, string message, string time)
        {
           
           // Session["idU"] = System.Web.HttpContext.Current.User.Identity.GetUserName();
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
         //   string Query = "insert into message(UserName,Destination,Message,Time)Values('" + userName + "','all','" + message + "','chyhemek f zeby')";
            //ConnC.ExecuteQuery(Query);

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
                string query = "select image from Users where UserName='" + username + "'";
                string ImageName = ConnC.GetColumnVal(query, "image");

                if (ImageName != "")
                    RetimgName = "/images/DP/" + ImageName;
            }
            catch (Exception ex)
            { }
            return RetimgName;
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
         
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (item != null)
            {
                ConnectedUsers.Remove(item);

             //   var id = System.Web.HttpContext.Current.User.Identity.GetUserId();
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            //  string fromUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            string fromUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                string CurrentDateTime = DateTime.Now.ToString();
                string UserImg = GetUserImage(fromUser.UserName);
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message, UserImg, CurrentDateTime);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message, UserImg, CurrentDateTime);
               // string Query = "insert into message(UserName,Destination,Message,Time)Values('" + fromUserId + "','"+toUserId+"','" + message + "','chyhemek f zeby')";
                //ConnC.ExecuteQuery(Query);
            }

        }
    }
}