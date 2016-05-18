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
using MVCApiDemo.Models;

namespace MVCApiDemo.Controllers
{
    public class JobsApiController : ApiController
    {
        private pubs2012Entities db = new pubs2012Entities();

        // GET api/JobsApi
        public IQueryable<job> Getjobs()
        {
            return db.jobs;
        }

        // GET api/JobsApi/5
        [ResponseType(typeof(job))]
        public IHttpActionResult Getjob(short id)
        {
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT api/JobsApi/5
        public IHttpActionResult Putjob(short id, job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.job_id)
            {
                return BadRequest();
            }

            db.Entry(job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobExists(id))
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

        // POST api/JobsApi
        [ResponseType(typeof(job))]
        public IHttpActionResult Postjob(job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.jobs.Add(job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = job.job_id }, job);
        }

        // DELETE api/JobsApi/5
        [ResponseType(typeof(job))]
        public IHttpActionResult Deletejob(short id)
        {
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            db.jobs.Remove(job);
            db.SaveChanges();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool jobExists(short id)
        {
            return db.jobs.Count(e => e.job_id == id) > 0;
        }
    }
}