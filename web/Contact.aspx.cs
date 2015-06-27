using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSendMessage_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbName.Text.Trim()) && !string.IsNullOrEmpty(tbEmail.Text.Trim()) && !string.IsNullOrEmpty(tbMessage.Text.Trim()))
        {
            MailClient mail = new MailClient(tbEmail.Text.Trim(), "mustafaseven1981@gmail.com", tbName.Text.Trim(), "Site üzerinden mesajınız var!", tbMessage.Text.Trim());
            string description = "";
            bool isSend = mail.SendMail(out description);

            pnlStatus.Visible = true;
            if (isSend)
            {
                pnlStatus.CssClass = "mail-send success";
                pnlStatus.Controls.Add(new Literal() { Text = "Görüşleriniz tarafımıza iletilmiştir. En kısa sürede bilgi maili ile bilgilendirileceksiniz." });
            }
            else
            {
                pnlStatus.CssClass = "mail-send error";
                pnlStatus.Controls.Add(new Literal() { Text = "Mail gönderimi sırasında bir hata oluştu." });
            }
        }
    }
}