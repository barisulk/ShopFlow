using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

public static class EmailHelper
{
    private static readonly string SenderEmail = "testshopflow@gmail.com";
    private static readonly string AppPassword = "bhzofvkhbodbvyqb";
    private static readonly string SmtpHost = "smtp.gmail.com";
    private static readonly int SmtpPort = 587;

    public static void Send(string to, string subject, string body)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SenderEmail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort);
            smtp.Credentials = new NetworkCredential(SenderEmail, AppPassword);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Mail gönderilirken hata oluştu: " + ex.Message);
        }
    }
}
