using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Server2.Models;

namespace Server2
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }


        //// Отправка сообщений
        //public void Send(string name, string message)
        //{
        //    Clients.All.addMessage(name, message);
        //}

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (Users.Count(x => x.Id == id) == 0)
            {
                Users.Add(new User { Id = id, Name = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Отключение пользователя
        //public override System.Threading.Tasks.Task OnDisconnected()
        //{
        //    var item = Users.FirstOrDefault(x => x.Id == Context.ConnectionId);
        //    if (item != null)
        //    {
        //        Users.Remove(item);
        //        var id = Context.ConnectionId;
        //        Clients.All.onUserDisconnected(id, item.Name);
        //    }

        //    return base.OnDisconnected();
        //}







    }

}