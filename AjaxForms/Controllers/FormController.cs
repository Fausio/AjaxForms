using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using AjaxForms.Models;

namespace AjaxForms.Controllers
{
    public class FormController : Controller
    {
        IConfiguration configuration;

        public FormController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult form()
        {
            return View();
        }

        [HttpPost]
        public JsonResult formsubmitajax(string name, string username, string password)
        {
            List<string> strings = new List<string>();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("SQLServerConnection"));

            var query = $@"INSERT INTO [TABLE]([Name],[UserName],[Password])  VALUES ({name},{username},{ModelClass.encryptString(password)})";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            strings.Add("Tuple Inserted.");
            return Json(strings);
        }

        [HttpPost]
        public JsonResult theajax(int MyId)
        {
            List<string> strings = new List<string>();

            strings.Add("Tuple Inserted.");
            return Json(strings);
        }
    }
}
