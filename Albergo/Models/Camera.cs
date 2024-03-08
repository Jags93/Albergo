using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Albergo.Models
{
    public class Camera
    {
        public int IdCamera { get; set; }

        [Required]
        public int Numero { get; set; }

        public string Descrizione { get; set; }

        [Required]
        public string Tipologia { get; set; } // Considera l'uso di un enum per le tipologie


        
    }
 }
