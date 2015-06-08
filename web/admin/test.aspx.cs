using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

public partial class test : System.Web.UI.Page
{

    TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
    MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
    string key = "SomeKeyValue1";

    protected void Page_Load(object sender, EventArgs e)
    {
        string deneme = "a=5&b=3,4,5&c=11&q=djgakbajksbasjfgbalksjfbalsblab323b123b2mö3nbk1093b";
        string hash = Encrypt(deneme);
        lbl.Text = hash;
        lbl2.Text = Decypt(hash);

    }

    public string Encrypt(string text)
    {
        cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
        cryptDES3.Mode = CipherMode.ECB;
        ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
        byte[] buff = ASCIIEncoding.ASCII.GetBytes(text);
        string Encrypt = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        Encrypt = Encrypt.Replace("+", "!");
        Encrypt = Encrypt.Replace("/", "__");
        return Encrypt;
    }

    public string Decypt(string text)
    {
        text = text.Replace("!", "+");
        text = text.Replace("__", "/");
        byte[] buf = new byte[text.Length];
        cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
        cryptDES3.Mode = CipherMode.ECB;
        ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
        buf = Convert.FromBase64String(text);
        string Decrypt = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buf, 0, buf.Length));
        return Decrypt;
    }
}