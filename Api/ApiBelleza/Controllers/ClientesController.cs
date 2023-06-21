using ApiBelleza.Models;
using ApiBelleza.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace ApiBelleza.Controllers
{
    public class ClientesController : ApiController
    {
        private SalaBellezaEntities db = new SalaBellezaEntities();

        // GET: api/Clientes
        public IQueryable<ClientesE> GetClientes()
        {
            return db.Clientes;
        }



        [ResponseType(typeof(List<ClienteDto>))]
        [Route("ObtenerListaClientes")]
        public IHttpActionResult GetListClientesE()
        {
            List<ClienteDto> listCliente = new List<ClienteDto>();
            List<ClientesE> clientesE = db.Clientes.ToList();
            if (clientesE == null)
            {
                return NotFound();
            }
            clientesE.ForEach(x =>
            {
                listCliente.Add(new ClienteDto
                {
                    ClienteID = x.ClienteID,
                    Cedula = x.Identificacion,
                    Nombre = x.Nombre,
                });
            });

            return Ok(listCliente);
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(ClientesE))]
        [Route("GetClientesPorIdentificacion")]
        public IHttpActionResult GetClientesPorIdentificacion(int cc)
        {
            ClientesE clientesE = db.Clientes.Select(x => x).Where(x => x.Identificacion == cc).First();
            if (clientesE == null)
            {
                return NotFound();
            }
            ClienteDto cliente = new ClienteDto()
            {
                Cedula = clientesE.Identificacion,
                ClienteID = clientesE.ClienteID,
                Nombre = clientesE.Nombre,
            };


            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        [Route("ActualizarClienteConId")]
        public IHttpActionResult ActualizarClienteConId( ClienteDto clientesE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!ClientesEExists(clientesE.ClienteID))
            {
                return BadRequest();
            }

            try
            {
                ClientesE cl = new ClientesE()
                {
                    ClienteID = clientesE.ClienteID,
                    Identificacion = clientesE.Cedula,
                    Nombre = clientesE.Nombre
                };
                db.Entry(cl).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesEExists(clientesE.ClienteID))
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

        // POST: api/Clientes
        [HttpPost]
        [Route("GuardarCliente")]
        public IHttpActionResult GuardarCliente(ClienteDto clientesE)
        {
            var idInsertado = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ClientesE cl = db.Clientes.Select(x => x).Where(x => x.Identificacion == clientesE.Cedula).First();
            if (clientesE == null)
            {
                return Ok("El usuario ya existe");
            }
            using (SqlConnection connection = new SqlConnection(ConnectionSql.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", clientesE.Nombre);
                    command.Parameters.AddWithValue("@Cedula", clientesE.Cedula);
                    idInsertado = Convert.ToInt32(command.ExecuteScalar());

                }
            }

            return Ok(idInsertado);
        }

        // DELETE: api/Clientes/5
        [Route("BorrarClientePorCedula")]
        [ResponseType(typeof(OkResult))]
        public IHttpActionResult DeleteClientesE(int cc)
        {
            ClientesE cl = db.Clientes.Select(x => x).Where(x => x.Identificacion == cc).First();
            if (cl == null)
            {
                return Ok("El usuario no existe");
            }
            ClientesE clientesE = db.Clientes.Remove(cl);
            if (clientesE == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(clientesE);
            db.SaveChanges();

            return Ok(clientesE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientesEExists(int id)
        {
            return db.Clientes.Count(e => e.ClienteID == id) > 0;
        }
    }
}