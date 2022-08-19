using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using AjaxForms.Models;
using System.Threading.Tasks;

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
        public async Task<JsonResult> formsubmitajax([FromBody] ModelObject model)
        {
            await InsertIntoTable(model);
            return Json("");
        }


        private async Task InsertIntoTable(ModelObject model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(configuration.GetConnectionString("SQLServerConnection"));
                var query = @"INSERT INTO [Table]([Name],[UserName],[Password])  VALUES ('" + model.Name + "','" + model.UserName + "', '" + ModelClass.encryptString(model.Password) + "' )";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
