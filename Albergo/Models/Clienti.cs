using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace Albergo.Models
{
    public class Clienti
    {
        public int IdCliente { get; set; }

        [Required]
        [StringLength(16)]
        public string CodFis{ get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Citta { get; set; }

        [StringLength(2)]
        public string Provincia { get; set; }

        [EmailAddress]
        public string Email { get; set; }

      

        [Phone]
        public string Cellulare { get; set; }
    }
}