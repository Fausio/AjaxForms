using System;
using System.Text;

namespace AjaxForms.Models
{
     

    public class ModelClass
    {
        public string username { get; set; }
        public string password { get; set; }


        public string encryptString(string value)
        {
            byte[] b = Encoding.ASCII.GetBytes(value);
            string envalue = Convert.ToBase64String(b);
            return envalue;
        }
    }
}
