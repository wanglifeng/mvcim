using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public enum MessageType
    {
        Error,
        Warning,
        Info
    }

    public class Message
    {
        public String Content { get; set; }
        public MessageType Type { get; set; }
    }
}