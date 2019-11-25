using System;
using System.Collections.Generic;

namespace TomaattiAPI.Models
{
    public partial class Kayttaja
    {
        public Kayttaja()
        {
            Tuote = new HashSet<Tuote>();
        }

        public int KayttajaId { get; set; }
        public string KayttajaNimi { get; set; }
        public string Email { get; set; }
        public string Salasana { get; set; }
        public string SalasanaHash { get; set; }
        public string SalasanaSalt { get; set; }
        public string Kuvaus { get; set; }
        public string Puhelinnumero { get; set; }

        public virtual ICollection<Tuote> Tuote { get; set; }
    }
}
