using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        public IEnumerable<Cliente> ObtenerClientes()
        {
            string sRet = "";
            List<Models.Cliente> ListaClientes = (List<Cliente>)Cliente.ObtenerClientes(ref sRet);

            return ListaClientes;
        }

        [HttpGet]
        public Cliente ObtenerClienteID(int id)
        {   
            
            string sRet = "";
            Models.Cliente cliente = (Cliente)Cliente.ObtenerClienteID(id, out sRet);

            return cliente;
        }

        [HttpGet]
        public Cliente ObtenerClientePorNombre(string nombre)
        {

            string sResult = "";
            Models.Cliente cliente = (Cliente)Cliente.ObtenerClientePorNombre(nombre, out sResult);

            return cliente;
        }

        [HttpPost]

        [Route("api/Cliente/insertar")]
        public IHttpActionResult InsertarCliente([FromBody] Models.Cliente cliente)
        {

            
            string mensaje = Cliente.InsertarCliente(cliente);


            return Ok(mensaje);
        }
        [HttpPost]
        [Route("api/Cliente/actualizar")]
        public IHttpActionResult ActualizarCliente([FromBody] Models.Cliente cliente)
        {
            string mensaje = Cliente.ActualizarCliente(cliente);
            return Ok(mensaje);
        }
    }
}
