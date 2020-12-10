using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSample.Services.Email
{
    public class MessageModel : Postal.Email
    {
        protected MessageModel() : base()
        {

        }

        public MessageModel(string viewName)
            : base(viewName)
        {

        }

        public MessageModel(string viewName, string areaName)
            : base(viewName, areaName, new EmptyModelMetadataProvider())
        {

        }

        public string To
        {
            get
            {
                return (string)ViewData["to"];
            }
            set
            {
                ViewData["to"] = value;
            }
        }
        public string Cc
        {
            get
            {
                return (string)ViewData["cc"];
            }
            set
            {
                ViewData["cc"] = value;
            }
        }
        public string Bcc
        {
            get
            {
                return (string)ViewData["bcc"];
            }
            set
            {
                ViewData["bcc"] = value;
            }
        }
        public string Subject
        {
            get
            {
                return (string)ViewData["Subject"];
            }
            set
            {
                ViewData["Subject"] = value;
            }
        }
        public string DisplayName
        {
            get
            {
                return (string)ViewData["DisplayName"];
            }
            set
            {
                ViewData["DisplayName"] = value;
            }
        }
    }
}
