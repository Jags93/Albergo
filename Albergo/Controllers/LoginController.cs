using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Security;
using Albergo.Models;
using System.Runtime.Remoting.Messaging;


namespace Albergo.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Dipendente d)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Albergo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Dipendenti WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", d.Username);
                    cmd.Parameters.AddWithValue("@Password", d.Password);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        FormsAuthentication.SetAuthCookie(d.Username, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username o Password errati");
                    }
                }
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}