using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ApplicationGenericControls
/// </summary>
public class ApplicationGenericControls
{
	public static class OperationStatus
    {
        public static string StatusOKTitle = "Başarılı !";
        public static string StatusOKDescription = "İşleminiz başarıyla gerçekleştirilmiştir.";
        public static string StatusOKCSS = "alert alert-success";

        public static string StatusERRORTitle = "Hata !";
        public static string StatusERRORDescription = "İşleminiz sırasında bir hata oluştu.";
        public static string StatusERRORCSS = "alert alert-danger";

        public static string StatusEMPTYDescription = "Lütfen * ile belirtilen alanları doldurunuz.";
    }

    public static class Operations
    {
        public static class Advert
        {
            public static class Edit
            {
                public static string StatusOKDescription = "İlan değişiklikleri başarıyla kaydedilmiştir.";
            }
        }

        public static class AdvertPhoto 
        {
            public static string StatusOKDescription = "Fotoğraf başarıyla kaydedilmiştir.";
            public static string StatusERRORDescription = "Lütfen geçerli formatta bir resim seçiniz.";
            public static string StatusDELETEDescription = "Fotoğraf başarıyla silinmiştir.";
        }

        public static class ProjectAdvert
        {
            public static string StatusOKDescription = "İlan başarıyla projeye eklenmiştir.";
            public static string StatusERRORDescription = "Lütfen geçerli bir ilan numarası giriniz.";
            public static string StatusDELETEDescription = "İlan başarıyla projeden çıkarılmıştır.";
        }

        public static class Person
        {
            public static class Add
            {
                public static string StatusOKDescription = "Kullanıcı başarıyla oluşturulmuştur.";
            }
        }

        public static  class Password
        {
            public static string PasswordRepeatERRORDescription = "Girilen şifreler uyuşmuyor.";
        }
    }
}