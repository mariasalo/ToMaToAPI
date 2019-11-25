using System;
using System.Collections.Generic;

namespace TomaattiAPI.Models
{
    public partial class Tuote
    {
        public int TuoteId { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public int? Lkm { get; set; }
        public DateTime? Paivays { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public byte[] Kuva { get; set; }
        public string BlobstorageLinkki { get; set; }
        public int? KayttajaId { get; set; }
        public bool? Itsetehty { get; set; }
        public bool? Juomat { get; set; }
        public bool? Avaamattomat { get; set; }
        public bool? Hevi { get; set; }
        public bool? Kuivatuotteet { get; set; }
        public bool? Kylmatuotteet { get; set; }
        public bool? Kotitila { get; set; }
        public bool? Herkut { get; set; }
        public bool? Mausteet { get; set; }

        public virtual Kayttaja Kayttaja { get; set; }
    }
}
