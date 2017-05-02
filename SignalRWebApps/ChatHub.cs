using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRWebApps.Models;

namespace SignalRWebApps
{
    public class ChatHub : Hub
    {
        SignalRContext _db = new SignalRContext();

        public void Send(string name, string message, string groupName)
        {
            Clients.Group(groupName).addMessageToGroup(name, message, groupName);
            _db.GroupMessages.Add(new GroupMessage { User = name, Name = groupName, Message = message });
            _db.SaveChanges();
            //groupMessage.Add(new GroupMessage { User = name, Name = groupName, Message = message });
            //Clients.AllExcept(Context.ConnectionId).addNewMessageToGroup(groupMessage);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.Add(Context.ConnectionId, groupName);
            Clients.Caller.addGroup(groupName, _db.GroupMessages.ToList());
        }

        public void SendToCaller(string name, string message)
        {
           // Clients.AllExcept(Context.ConnectionId).addMessageToCaller(groupMessage);
        }
           

    }

}                    