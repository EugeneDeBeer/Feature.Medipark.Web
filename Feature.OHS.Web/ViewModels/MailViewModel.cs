using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class MailViewModel
    {
        public string MailSource { get; set; }
        public string MailDestination { get; set; }
        public string MailTitle { get; set; }
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPortNumber { get; set; }
    }
}
