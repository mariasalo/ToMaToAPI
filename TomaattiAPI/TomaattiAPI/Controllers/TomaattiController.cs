using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomaattiAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace TomaattiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors(origins: "*", headers: "*", methods: "get,post,put,delete")]
    public class TomaattiController : ControllerBase
    {
        // GET: api/Tomaatti
        [HttpGet]
        public IEnumerable<Tuote> Get()
        {
            KiertomaattiDBContext db = new KiertomaattiDBContext();
            return db.Tuote.AsEnumerable();
        }

        // GET: api/Tomaatti/5
        [HttpGet("{id}", Name = "Get")]
        public Tuote Get(int id)
        {
            using(KiertomaattiDBContext db = new KiertomaattiDBContext())
            {
                return db.Tuote.Find(id);
            }
        }

        //GET: api/tomaatti/<nimi>
        [HttpGet("search/{nimi}")]
        public IEnumerable<Tuote> Get(string nimi)
        {
            KiertomaattiDBContext db = new KiertomaattiDBContext();
            return db.Tuote.Where(t => t.Nimi.Contains(nimi));
        }

        // POST: api/Tomaatti
        [HttpPost]
        public void Post([FromBody] Tuote tuote /*reactista tuleva tuote-json parseroituu itsestään olioksi  */)
        {
            KiertomaattiDBContext db = new KiertomaattiDBContext();
            db.Tuote.Add(tuote);
            db.SaveChanges();
        }

        // PUT: api/Tomaatti/5
        [HttpPut("update/{id}")]
        [EnableCors("AllowOrigins")]

        public void Put(int id, [FromBody] Tuote tuote)
        {
            using (KiertomaattiDBContext db = new KiertomaattiDBContext())
            {
                try
                {
                    Tuote existing = db.Tuote.Find(id);

                    //existing.TuoteId = tuote.TuoteId;
                    existing.Nimi = tuote.Nimi;
                    existing.Kuvaus = tuote.Kuvaus;
                    existing.Lkm = tuote.Lkm;
                    existing.Paivays = tuote.Paivays;
                    existing.Latitude = tuote.Latitude;
                    existing.Longitude = tuote.Longitude;
                    existing.Kuva = tuote.Kuva;
                    existing.BlobstorageLinkki = tuote.BlobstorageLinkki;
                    existing.KayttajaId = tuote.KayttajaId;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        //[EnableCors("AllowOrigins")]

        public void Delete(int id)
        {
            using (KiertomaattiDBContext db = new KiertomaattiDBContext())
            {
                try
                {
                    Tuote toRemove = db.Tuote.Find(id);
                    db.Remove(toRemove);
                    db.SaveChanges();

                }
                catch (Exception e)
                {

                    throw e;
                }
            }

        }
    }
}
