using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using ApiBelleza.Models;
using ApiBelleza.Models.Dto;

namespace ApiBelleza.Controllers
{
    public class PlanSepareController : ApiController
    {
        private SalaBellezaEntities db = new SalaBellezaEntities();

        // GET: api/PlanSepare
        public IQueryable<PlanSepareE> GetPlanSepare()
        {
            return db.PlanSepare;
        }

        // GET: api/PlanSepare/5
        [ResponseType(typeof(List<PlanSepareDetalleDto>))]
        [Route("PlanSeparePorCedula")]
        public IHttpActionResult PlanSeparePorCedula(int cc)
        {
            ClientesE clientesE = db.Clientes.Select(x => x).Where(x => x.Identificacion == cc).First();
            List<PlanSepareDetalleDto> listPlanSepare = new List<PlanSepareDetalleDto>();
            if (clientesE == null)
            {
                return NotFound();
            }

            var planSepareE = db.PlanSepare.Select(x => x).Where(x => x.ClienteID == clientesE.ClienteID).ToList();
            if (planSepareE == null)
            {
                return NotFound();
            }


            using (SqlConnection connection = new SqlConnection(ConnectionSql.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SeleccionarPlanSepare", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros si es necesario
                    command.Parameters.AddWithValue("@Cedula", clientesE.ClienteID);

                    //SqlDataAdapter da = new SqlDataAdapter(command);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlanSepareDetalleDto pls = new PlanSepareDetalleDto();
                            pls.ClienteID = Convert.ToInt32(reader["ClienteID"]);
                            pls.FechaSepare = Convert.ToDateTime(reader["FechaSepare"]);
                            pls.TotalPrecioSepare = Convert.ToDouble( reader["TotalPrecioSepare"]);//revisar esta conver
                            pls.ValorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                            pls.PlanSepareID = (int)reader["PlanSepareID"];
                            pls.Cantidad = (int)reader["Cantidad"];
                            pls.CantidadStock = (int)reader["CantidadStock"];
                            pls.PrecioUnidad = Convert.ToDouble(reader["PrecioUnidad"]);
                            pls.Referencia = reader["Referencia"].ToString();
                            pls.ProductoXColorID = (int)reader["ProductoXColorID"];
                            listPlanSepare.Add(pls);                           
                        }
                    }
                }
            }
            return Ok(listPlanSepare);
        }

        // PUT: api/PlanSepare/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlanSepareE(int id, PlanSepareE planSepareE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planSepareE.PlanSepareID)
            {
                return BadRequest();
            }

            db.Entry(planSepareE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanSepareEExists(id))
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

        // POST: api/PlanSepare
        [ResponseType(typeof(PlanSepareE))]
        public IHttpActionResult PostPlanSepareE(PlanSepareE planSepareE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlanSepare.Add(planSepareE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = planSepareE.PlanSepareID }, planSepareE);
        }

        // DELETE: api/PlanSepare/5
        [ResponseType(typeof(PlanSepareE))]
        public IHttpActionResult DeletePlanSepareE(int id)
        {
            PlanSepareE planSepareE = db.PlanSepare.Find(id);
            if (planSepareE == null)
            {
                return NotFound();
            }

            db.PlanSepare.Remove(planSepareE);
            db.SaveChanges();

            return Ok(planSepareE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanSepareEExists(int id)
        {
            return db.PlanSepare.Count(e => e.PlanSepareID == id) > 0;
        }
    }
}