using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class SMSRequestedEvent : INotification
    {
        public SMSRequestedEvent(string message, string mobilenumber,
           string userid)
        {
            Message = message;
            MobileNumber = mobilenumber;
            UserID = userid;
        }
        public string Message { get; private set; }
        public string MobileNumber { get; private set; }
        public string UserID { get; private set; }
    }
}
