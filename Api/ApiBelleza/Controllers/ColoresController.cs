using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiBelleza.Models;
using ApiBelleza.Models.Dto;

namespace ApiBelleza.Controllers
{
    public class ColoresController : ApiController
    {
        private SalaBellezaEntities db = new SalaBellezaEntities();

        // GET: api/Colores
        [Route("ObtenerLista")]
        public IHttpActionResult GetColores()
        {
            List<ColorDto> resultDto = new List<ColorDto>();
            List<Colores> listColores = db.Colores.ToList();
            listColores.ForEach(x => { 
                resultDto.Add(new ColorDto { Color = x.Color, ColorID = x.ColorID});            
            });
            return Ok( resultDto);
        }

        // GET: api/Colores/5
        [ResponseType(typeof(Colores))]
        [Route("ObtenerPorId")]
        public IHttpActionResult GetColores(int id)
        {
            Colores colores = db.Colores.Find(id);
            if (colores == null)
            {
                return NotFound();
            }
            ColorDto color = new ColorDto() { ColorID = colores.ColorID, Color = colores.Color };
            return Ok(color);
        }

        // PUT: api/Colores/5
        [ResponseType(typeof(void))]
        [Route("ActualizarColor")]
        public IHttpActionResult PutColores(int id, Colores colores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colores.ColorID)
            {
                return BadRequest();
            }

            db.Entry(colores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColoresExists(id))
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

        // POST: api/Colores
        [Route("GuardarColor")]
        [ResponseType(typeof(Colores))]
        public IHttpActionResult PostColores(ColorDto colores)
        {
            var idInsertado = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Colores cl = db.Colores.Select(x => x).Where(x => x.Color == colores.Color).FirstOrDefault();
                if (cl != null)
                {
                    return Ok("El color ya existe");
                }
                using (SqlConnection connection = new SqlConnection(ConnectionSql.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InsertarColor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Nombre", colores.Color);
                        idInsertado = Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok(idInsertado);
        }

        // DELETE: api/Colores/5
        [ResponseType(typeof(Colores))]
        [Route("BuscarPorId")]
        public IHttpActionResult DeleteColores(int id)
        {
            Colores colores = db.Colores.Find(id);
            if (colores == null)
            {
                return NotFound();
            }

            db.Colores.Remove(colores);
            db.SaveChanges();

            return Ok(colores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColoresExists(int id)
        {
            return db.Colores.Count(e => e.ColorID == id) > 0;
        }
    }
}