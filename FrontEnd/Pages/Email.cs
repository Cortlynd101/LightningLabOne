using System;
//using MailKit.Net.Smtp;
using MailKit;
using System.Net.Mail; // this namespace is required to send emails with SMTP
/*using MimeKit;

try
{
    using var email = new MimeMessage();

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}*/
namespace EmailSending
{
    class Email
    {
        public void SendEmail(string email)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient();
                client.Host = "foodboxbusiness00@gmail.com";

                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress("foodboxbusiness00@gmail.com", "FoodBox");

                newMail.To.Add(email);// declare the email subject

                newMail.Subject = "foodboxbusiness00@gmail.com"; // use HTML for the email body

                newMail.IsBodyHtml = true; newMail.Body = "<h1> Thank you for your purchase! </h1>";

                // enable SSL for encryption across channels
                client.EnableSsl = true;
                // Port 465 for SSL communication
                client.Port = 465;
                // Provide authentication information with Gmail SMTP server to authenticate your sender account
                client.Credentials = new System.Net.NetworkCredential("foodboxbusiness00@gmail.com", "P@ssword1.");

                client.Send(newMail); // Send the constructed mail
                Console.WriteLine("Email Sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
        }


    }
}