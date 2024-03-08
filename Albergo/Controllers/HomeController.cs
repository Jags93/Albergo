using Albergo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Albergo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Albergo"].ConnectionString;
           SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Clienti", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Clienti> clienti = new List<Clienti>();
                while (reader.Read())
                {
                    Clienti cliente = new Clienti();
                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.CodFis = reader.GetString(1);
                    cliente.Cognome = reader.GetString(2);
                    cliente.Nome = reader.GetString(3);
                    cliente.Citta = reader.GetString(4);
                    cliente.Provincia = reader.GetString(5);
                    cliente.Email = reader.GetString(6);
                    
                    cliente.Cellulare = reader.GetString(7);
                    clienti.Add(cliente);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View();
        }

        public ActionResult CreateCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCliente(Clienti cliente)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Albergo"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Clienti (CodFis, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodFis, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)", connection);
                    command.Parameters.AddWithValue("@CodFis", cliente.CodFis);
                    command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Citta", cliente.Citta);
                    command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    
                    command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);
                    command.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
                catch (SqlException ex)
                {
                    ViewBag.Message = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return View(cliente);
        }

        [HttpGet]

        public ActionResult EditCliente(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Albergo"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            Clienti cliente = new Clienti();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Clienti WHERE IdCliente = @IdCliente", connection);
                command.Parameters.AddWithValue("@IdCliente", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.CodFis = reader.GetString(1);
                    cliente.Cognome = reader.GetString(2);
                    cliente.Nome = reader.GetString(3);
                    cliente.Citta = reader.GetString(4);
                    cliente.Provincia = reader.GetString(5);
                    cliente.Email = reader.GetString(6);
                    
                    cliente.Cellulare = reader.GetString(7);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(cliente);
        }

        [HttpPost]

        public ActionResult EditCliente(Clienti cliente)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Albergo"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Clienti SET CodFis = @CodFis, Cognome = @Cognome, Nome = @Nome, Citta = @Citta, Provincia = @Provincia, Email = @Email, Cellulare = @Cellulare WHERE IdCliente = @IdCliente", connection);
                    command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    command.Parameters.AddWithValue("@CodFis", cliente.CodFis);
                    command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Citta", cliente.Citta);
                    command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    
                    command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);
                    command.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
                catch (SqlException ex)
                {
                    ViewBag.Message = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return View(cliente);
        }
        

        public ActionResult NewPrenotazione()
        {
            return View();
        }

        [HttpPost]

        public ActionResult NewPrenotazione(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Albergo"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Prenotazioni (IdCliente, IdCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, PeriodoDal, PeriodoAl, CaparraConfirmatoria, Tariffa, DettaglioPensione) VALUES (@IdCliente, @IdCamera, @DataPrenotazione, @NumeroProgressivoAnno, @Anno, @PeriodoDal, @PeriodoAl, @CaparraConfirmatoria, @Tariffa, @DettaglioPensione)", connection);
                    command.Parameters.AddWithValue("@IdCliente", prenotazione.IdCliente);
                    command.Parameters.AddWithValue("@IdCamera", prenotazione.IdCamera);
                    command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                    command.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                    command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                    command.Parameters.AddWithValue("@PeriodoDal", prenotazione.PeriodoDal);
                    command.Parameters.AddWithValue("@PeriodoAl", prenotazione.PeriodoAl);
                    command.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                    command.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
                    command.Parameters.AddWithValue("@DettaglioPensione", prenotazione.DettaglioPensione);
                    command.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
                catch (SqlException ex)
                {
                    ViewBag.Message = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return View(prenotazione);
        }
        
    }
}