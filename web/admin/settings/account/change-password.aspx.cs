using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_account_change_password : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string oldpass = tbOldPassword.Text.Trim();
        string newpass = tbNewPassword.Text.Trim();
        string newpass2 = tbNewPassword2.Text.Trim();

        if (!string.IsNullOrEmpty(oldpass) && !string.IsNullOrEmpty(newpass) && !string.IsNullOrEmpty(newpass2))
        {
            if (newpass == newpass2)
            { 
                string oldpassMD5 = BasePage.MD5Crypto(oldpass);
                Person p = DBProvider.GetPersonByEmailAndPassword(CurrentPerson.Email, oldpassMD5);
                if (p != null)
                {
                    CurrentPerson.Password = BasePage.MD5Crypto(newpass);
                    DBProvider.SaveChanges();
                    SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, "Başarılı!", "Şifre değiştirme işleminiz başarıyla gerçekleştirildi.", "alert alert-success");
                }
                else
                {
                    SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, "Hata!", "Eski şifrenizi hatalı girdiniz.", "alert alert-danger");
                }
            }
            else
            {
                SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, "Hata!", "Yeni şifreler birbiriyle uyuşmamktadır.", "alert alert-danger");
            }            
        }
        else
        {
            SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, "Hata!", "Lütfen eski ve yeni şifrelerinizi giriniz", "alert alert-danger");
        }
    }
}