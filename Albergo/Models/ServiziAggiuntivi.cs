using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class ServiziAggiuntivi
    {
        public int IdServizioAggiuntivo { get; set; }

        [Required]
        public int IdPrenotazione { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataServizio { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La quantità deve essere maggiore di 0")]
        public int Quantita { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }
    }
}