using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.NotificationEvents
{
    public class PushRequestedEvent : INotification
    {
        public PushRequestedEvent(string title, string content, string brief, string firebasetoken,
         string userid, string route, string jsonparameter)
        {
            Title = title;
            Content = content;
            Brief = brief;
            FirebaseToken = firebasetoken;
            UserID = userid;
            Route = route;
            JsonParameter = jsonparameter;
        }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Brief { get; private set; }
        public string FirebaseToken { get; private set; }
        public string UserID { get; private set; }
        public string JsonParameter { get; private set; }
        public string Route { get; private set; }
    }
}
