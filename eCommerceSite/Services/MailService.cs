﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace eCommerceSite.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            //try
            //{
            //    var msg = new MailMessage(from, to , subject, body);
            //    var client = new SmtpClient();
            //    client.Send(msg);
            //}
            //catch (Exception ex)
            //{
            //    add logging
            //    return false;
            //}
            return true;
        }
    }
}