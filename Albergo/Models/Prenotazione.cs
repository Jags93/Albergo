using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Albergo.Models
{
    public class Prenotazione
    {
        public int IdPrenotazione { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdCamera { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataPrenotazione { get; set; }

        public int NumeroProgressivoAnno { get; set; }

        [Required]
        public int Anno { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodoDal { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodoAl { get; set; }

        [DataType(DataType.Currency)]
        public decimal CaparraConfirmatoria { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Tariffa { get; set; }

        public string DettaglioPensione { get; set; } // Considera l'uso di un enum
    }
}