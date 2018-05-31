using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WAGreenLeaf;

namespace WAGreenLeaf.Controllers
{
    public class StationsController : ApiController
    {
        private GreenLeafContext db = new GreenLeafContext();

        // GET: api/Stations
        public IQueryable<Station> GetStation()
        {
            return db.Station;
        }

        // GET: api/Stations/5
        [ResponseType(typeof(Station))]
        public IHttpActionResult GetStation(int id)
        {
            Station station = db.Station.Find(id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        // PUT: api/Stations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStation(int id, Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != station.StationID)
            {
                return BadRequest();
            }

            db.Entry(station).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Stations
        [ResponseType(typeof(Station))]
        public IHttpActionResult PostStation(Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Station.Add(station);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = station.StationID }, station);
        }

        // DELETE: api/Stations/5
        [ResponseType(typeof(Station))]
        public IHttpActionResult DeleteStation(int id)
        {
            Station station = db.Station.Find(id);
            if (station == null)
            {
                return NotFound();
            }

            db.Station.Remove(station);
            db.SaveChanges();

            return Ok(station);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationExists(int id)
        {
            return db.Station.Count(e => e.StationID == id) > 0;
        }
    }
}