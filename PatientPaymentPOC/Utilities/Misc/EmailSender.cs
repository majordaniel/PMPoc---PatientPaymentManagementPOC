using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Utilities.Misc
{
    public class EmailSender
    {
        private readonly string _sender = "support@xxxxxxxx";//AppSettings.PostmarkEmail;
        private readonly string _aws_smtp_port = "587";
        private readonly string _aws_smtp_username = "xxxxxxxxxxxxxxxxxxxx";
        private readonly string _aws_smtp_pwd = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        private readonly string _aws_smtp_host = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";




        public bool IsValidEmailAddress(string emailAddress)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(emailAddress);
                return !string.IsNullOrWhiteSpace(mailAddress.Address);
            }
            catch
            {
                return false;
            }
        }

        public void SendEmail_AWS(IEnumerable<string> emails, string body, string subject, string attachmentPath = "")
        {
            if (emails == null || !emails.Any())
                return;



            foreach (var email in emails)
            {
                if (string.IsNullOrWhiteSpace(email) || !IsValidEmailAddress(email))
                    continue;



                int port = Convert.ToInt32(_aws_smtp_port);
                using (var client = new SmtpClient(_aws_smtp_host, port))
                {
                    try
                    {
                        MailMessage message = new MailMessage(from: _sender, to: email);
                        message.IsBodyHtml = true;
                        message.Subject = subject;
                        message.Body = body;



                        if (!string.IsNullOrWhiteSpace(attachmentPath) && File.Exists(attachmentPath))
                        {
                            var fileInfo = new FileInfo(attachmentPath);
                            var ext = fileInfo.Extension.ToLower();
                            var attachment = new System.Net.Mail.Attachment(attachmentPath);



                            if (ext == ".pdf")
                                attachment.ContentType = new System.Net.Mime.ContentType("application/pdf");
                            else if (ext == ".xls")
                                attachment.ContentType = new System.Net.Mime.ContentType("application/vnd.ms-excel");
                            else if (ext == ".xlsx")
                                attachment.ContentType = new System.Net.Mime.ContentType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");



                            message.Attachments.Add(attachment);
                        }



                        client.Credentials = new NetworkCredential(_aws_smtp_username, _aws_smtp_pwd);
                        client.EnableSsl = true;
                        client.Send(message);
                        message.Dispose();
                    }
                    catch (Exception ex)
                    {
                        // StackifyLib.Logger.QueueException($"[{nameof(MailService)}] Error sending email.", ex);

                    }
                }

            }
        }

        public int SendSingleEmail_AWS(string email, string body, string subject, string attachmentPath = "")
        {
            if (email == null || !email.Any())
                return 0;


            if (string.IsNullOrWhiteSpace(email) || !IsValidEmailAddress(email))
                return 0;

            int port = Convert.ToInt32(_aws_smtp_port);



            //foreach (var email in emails)
            //{




            using (var client = new SmtpClient(_aws_smtp_host, port))
            {
                try
                {
                    MailMessage message = new MailMessage(from: _sender, to: email);
                    message.IsBodyHtml = true;
                    message.Subject = subject;
                    message.Body = body;



                    if (!string.IsNullOrWhiteSpace(attachmentPath) && File.Exists(attachmentPath))
                    {
                        var fileInfo = new FileInfo(attachmentPath);
                        var ext = fileInfo.Extension.ToLower();
                        var attachment = new System.Net.Mail.Attachment(attachmentPath);



                        if (ext == ".pdf")
                            attachment.ContentType = new System.Net.Mime.ContentType("application/pdf");
                        else if (ext == ".xls")
                            attachment.ContentType = new System.Net.Mime.ContentType("application/vnd.ms-excel");
                        else if (ext == ".xlsx")
                            attachment.ContentType = new System.Net.Mime.ContentType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");



                        message.Attachments.Add(attachment);
                    }



                    client.Credentials = new NetworkCredential(_aws_smtp_username, _aws_smtp_pwd);
                    client.EnableSsl = true;
                    client.Send(message);
                    message.Dispose();
                }
                catch (Exception ex)
                {
                    // StackifyLib.Logger.QueueException($"[{nameof(MailService)}] Error sending email.", ex);

                }
            }

            // }
            return 1;
        }

    }
}
