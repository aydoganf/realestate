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
            MailClient mail = new MailClient(tbEmail.Text.Trim(), "faruk.aydgn@gmail.com" ,tbName.Text.Trim(), "Site üzerinden mesajınız var!" ,tbMessage.Text.Trim());
            string description = "";
            bool isSend = mail.SendMail(out description);

            pnlStatus.Controls.Add(new Literal() { Text = "İşlem Sonucu: " + description });
            pnlStatus.Visible = true;
        }
    }
}