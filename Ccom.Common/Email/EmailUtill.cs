using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Ccom.Common.DomainObjects;
using Ccom.Common.Utils;
using Ccom.ExceptionHandling.ExceptionHandlers;
using RazorEngine;

namespace Ccom.Common.Email
{
    public static class EmailUtill
    {
        private static readonly EmailConfigurations EmailConfigurations = new EmailConfigurations();

        public static bool Send(string toAddress, string message, string subject)
        {
            bool done;
            try
            {
                //See this http://www.mywindowshosting.com/support/KB/a1546/send-email-from-gmail-with-smtp-authentication-but.aspx
                //when occur below error
                //The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.5.1 Authentication Required. Learn more at
                //or
                //use this https://www.google.com/settings/security/lesssecureapps?pli=1
                
                
                var mail = new MailMessage();
                var smtpServer = new SmtpClient(EmailConfigurations.ServerName, 25);
                mail.From = new MailAddress(EmailConfigurations.SenderAddress);
                mail.IsBodyHtml = true;
                mail.To.Add(toAddress);
                mail.Subject = subject;
                var credentials = new NetworkCredential(EmailConfigurations.SenderAddress, EmailConfigurations.Password);
                smtpServer.EnableSsl = false;
                smtpServer.UseDefaultCredentials = true;
                smtpServer.Credentials = credentials;
                mail.Body = message;
                smtpServer.Send(mail);
                done = true;

                //var mail = new MailMessage();
                //var smtpServer = new SmtpClient(EmailConfigurations.ServerName);
                //mail.From = new MailAddress(EmailConfigurations.SenderAddress);
                //mail.IsBodyHtml = true;
                //mail.To.Add(toAddress);
                //mail.Subject = subject;
                //var credentials = new NetworkCredential(EmailConfigurations.SenderAddress, EmailConfigurations.Password);
                //smtpServer.EnableSsl = true;
                //smtpServer.UseDefaultCredentials = true;
                //smtpServer.Credentials = credentials;
                //mail.Body = message;
                //smtpServer.Send(mail);
                //done = true;
            }
            catch (Exception ex)
            {
                done = false;
                if (CommonExceptionHandler.HandleException(ref ex)) throw ex;
            }
            return done;
        }

        public static void SendAcyncEmail<T>(T model, IEmailEntity emailEntity)
        {
            SetConfigurations();
            new Task(() => SetEmail(model, emailEntity)).Start();
        }

        public static void SendSyncEmail<T>(T model, IEmailEntity emailEntity)
        {
            SetConfigurations();
            SetEmail(model, emailEntity);
        }

        private static void SetEmail<T>(T model, IEmailEntity emailEntity)
        {
            try
            {
                var template = SetMailTemplate(emailEntity.TemplateName);
                var message = Razor.Parse(template, model);
                Send(emailEntity.ToEmailAddress, message, emailEntity.Subject);
            }
            catch (Exception ex)
            {
                if (CommonExceptionHandler.HandleException(ref ex)) throw ex;
            }
        }

        public static string SetMailTemplate(string templateName)
        {
            try
            {
                var uri = new Uri(EmailConfigurations.TemplateFolderPath + templateName);
                var req = WebRequest.Create(uri);
                var resp = req.GetResponse();
                var stream = resp.GetResponseStream();
                if (stream == null) return string.Empty;
                var sr = new StreamReader(stream);
                var template = sr.ReadToEnd();
                return template;
            }
            catch (Exception ex)
            {
                if (CommonExceptionHandler.HandleException(ref ex)) throw ex;
            }
            return null;
        }

        public static void SetConfigurations()
        {
            string configFilePath = GetLocation.GetLocationPath() + @"\EmailConfig.xml";
            if (!File.Exists(configFilePath))
            {

            }
            ConfigurationItemList config = XmlSerializerUtil.DeSerializeXmlToObject<ConfigurationItemList>(configFilePath);

            if (config != null)
                if (config.Configurations != null)
                    foreach (ConfigurationItem item in config.Configurations)
                    {
                        switch (item.Key)
                        {
                            case "Server_Name":
                                EmailConfigurations.ServerName = item.Value;
                                break;
                            case "Sender_Address":
                                EmailConfigurations.SenderAddress = item.Value;
                                break;
                            case "Receiver_Address":
                                EmailConfigurations.ReceiverAddress = item.Value;
                                break;
                            case "Template_Folder_Path":
                                EmailConfigurations.TemplateFolderPath = item.Value;
                                break;
                            case "Password":
                                EmailConfigurations.Password = item.Value;
                                break;
                            //case "CC_Address":
                            //    EmailConfigurations.CcAddress = item.Value;
                            //    break;

                            //case "BCC_Address":
                            //    EmailConfigurations.BccAddress = item.Value;
                            //    break;

                            //case "Header_Text_FilePath":
                            //    EmailConfigurations.HeaderTextFilePath = item.Value;
                            //    break;

                            //case "Footer_Text_FilePath":
                            //    EmailConfigurations.FooterTextFilePath = item.Value;
                            //    break;

                            //case "Subject_Text_FilePath":
                            //    EmailConfigurations.SubjectTextFilePath = item.Value;
                            //    break;

                            //case "Destination_Email":
                            //    EmailConfigurations.DestinationEmail = item.Value;
                            //    break;
                        }
                    }
        }

        // public SendEmail()
        //{
        //    string filename = @"D:\WorkDir_IOneSoft\HMS.KIOSK\IOS.HMS.KIOSK\IOS.Common\Message\EmailTemplate.html";
        //    string mailbody = System.IO.File.ReadAllText(filename);
        //    mailbody = mailbody.Replace("##NAME##", "Gayan");
        //    string to = "rangani.peramuna@gmail.com";
        //    string from = "gayanmadushanka2@gmail.com";
        //    MailMessage message = new MailMessage(from, to);
        //    message.Subject = "Testing";
        //    message.Body = mailbody;
        //    message.BodyEncoding = Encoding.UTF8;
        //    message.IsBodyHtml = true;
        //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //    System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("gayanmadushanka2@gmail.com", "abc123");
        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = true;
        //    client.Credentials = basicCredential;
        //    try
        //    {
        //        client.Send(message);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}
