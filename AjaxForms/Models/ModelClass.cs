using System;
using System.Text;

namespace AjaxForms.Models
{
     

    public static class ModelClass
    {
        public static  string encryptString(this string value)
        {
            byte[] b = Encoding.ASCII.GetBytes(value);
            string envalue = Convert.ToBase64String(b);
            return envalue;
        }
    }


    public class ModelObject
    {
        public string Name { get; set; }
         public string UserName { get; set; }
         public string Password { get; set; }
    }
}
