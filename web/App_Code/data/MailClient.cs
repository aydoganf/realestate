using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for MailClient
/// </summary>
public class MailClient
{
    private string SenderEmailAddress { get; set; }
    private string SenderEmailPassword { get; set; }
    private string SenderHost { get; set; }
    private string ToEmailAddress { get; set; }
    private string MailLogo { get; set; }
    private string MailSubject { get; set; }
    private string MailHeaderHTML { get; set; }
    private string MailBodyHTML { get; set; }
    private string MailFooterHTML { get; set; }
    private string MailContent { get; set; }

    public MailClient(string fromEmailAddress, string toEmailAddress, string name, string subject, string message)
    {
        #region Core Info
        this.SenderEmailAddress = ConfigurationManager.AppSettings["mailSenderUser"];
        this.SenderEmailPassword = ConfigurationManager.AppSettings["mailSenderPass"];
        this.SenderHost = ConfigurationManager.AppSettings["mailSenderHost"];
        this.ToEmailAddress = toEmailAddress;
        this.MailSubject = subject;
        #endregion

        #region Design Info
        this.MailLogo = "<img src='" + ConfigurationManager.AppSettings["mailLogoPath"] + "' height='50' style='max-height:50px'";
        this.MailHeaderHTML = "<div style='margin-bottom:20px; border-bottom:1px solid #d5d5d5'>" + MailLogo + "<hr /></div>";
        this.MailFooterHTML = "<div style='margin-top:20px;'><hr />" +
                              "<div>Bu mail habesoglugayrimenkul.com.tr tarafından otomatik olarak gönderilmiştir.</div>" +
                              "<div>habesoglugayrimenkul.com.tr © " + DateTime.Now.Year.ToString() + "</div>" +
                              "</div>";

        string contentHeader = "<table><tr>";
        string contentFooter = "</tr></table>";
        string contentItem = "<td><div style='margin-bottom:30px;'><strong>Mesaj İçeriği:</strong><br>" + message + "</div>" +
                             "<div><strong>Gönderen:</strong> " + name + "</div>" +
                             "<div><strong>Email:</strong> " + fromEmailAddress + "</div>" +
                             "</td>";
        this.MailBodyHTML = contentHeader + contentItem + contentFooter;
        this.MailContent = this.MailHeaderHTML + this.MailBodyHTML + this.MailFooterHTML;
        #endregion
    }

    public bool SendMail(out string description)
    {
        try
        {
            MailMessage _mail = new MailMessage();
            _mail.From = new MailAddress(this.SenderEmailAddress);
            _mail.To.Add(this.ToEmailAddress);
            _mail.Subject = this.MailSubject;
            _mail.Body = this.MailContent;
            _mail.IsBodyHtml = true;

            SmtpClient _client = new SmtpClient();
            _client.Credentials = new NetworkCredential(this.SenderEmailAddress, this.SenderEmailPassword);
            _client.Host = this.SenderHost;
            _client.Port = 587;
            _client.Send(_mail);

            description = "başarılı";
            return true;
        }
        catch (Exception ex)
        {
            description = ex.Message;
            return false;
        }
    }
}