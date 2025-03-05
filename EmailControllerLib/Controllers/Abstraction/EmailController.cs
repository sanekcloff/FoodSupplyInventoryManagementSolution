using MailingControllerLib.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailingControllerLib.Controllers.Abstraction
{
    public class EmailController : ISender
    {
        public async Task Send()
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    // Установка параметров SMTP
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("email", "password"); // Используйте пароль приложения, если включена 2FA
                    smtp.EnableSsl = true; // Включение SSL

                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress("email");
                        mail.To.Add("email");
                        mail.Subject = "Test message";
                        mail.Body = "This is a test message launched from my C# app";

                        // Отправка сообщения
                        await smtp.SendMailAsync(mail);
                    }
                }

                Debug.WriteLine("[SUCCESS] Email sent successfully.");
            }
            catch (SmtpException smtpEx)
            {
                Debug.WriteLine($"SMTP ERROR: {smtpEx.StatusCode} - {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
