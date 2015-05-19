using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_account_default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        tbFirstName.Text = CurrentPerson.FirstName;
        tbLastName.Text = CurrentPerson.LastName;
        tbEmail.Text = CurrentPerson.Email;
        tbPhone.Text = CurrentPerson.Phone;
        tbAddress.Text = CurrentPerson.Address;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string firstName = tbFirstName.Text.Trim();
        string lastName = tbLastName.Text.Trim();
        string email = tbEmail.Text.Trim();
        string phone = tbPhone.Text.Trim();
        string address = tbAddress.Text.Trim();
        string password = tbPassword.Text;

        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone))
        {
            Person p = DBProvider.GetPersonByEmailAndPassword(CurrentPerson.Email, BasePage.MD5Crypto(password), 2);
            if (p != null && p.ObjectId == CurrentPerson.ObjectId)
            {
                CurrentPerson.FirstName = firstName;
                CurrentPerson.LastName = lastName;
                CurrentPerson.Email = email;
                CurrentPerson.Phone = phone;
                CurrentPerson.Address = address;
                DBProvider.SaveChanges();
                Response.Redirect("default.aspx?status=0");
            }
            else
            {
                Response.Redirect("default.aspx?status=0&result_code=_badpassword");
            }            
        }
    }
}