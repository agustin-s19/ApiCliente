using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Http.Results;

namespace WebApplication1.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }  
        public string Apellido { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string CUIT { get; set; }
        public string Domicilio { get; set; }
        public string TelefonoCelular { get; set; }
        public string Email { get; set; }

        public static IEnumerable<Cliente> ObtenerClientes(ref string sResult)
        {
            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);
            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spObtenerClientes", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);

                List<Models.Cliente> ListaClientes = new List<Models.Cliente>();
                foreach (DataRow row in dt.Rows)
                {
                    var Cliente = new Cliente();
                    Cliente.ID = int.Parse(row["ID"].ToString());
                    Cliente.Nombre = row["Nombres"].ToString();
                    Cliente.Apellido = row["Apellidos"].ToString();
                    Cliente.FechaDeNacimiento = DateTime.Parse(row["FechaDeNacimiento"].ToString());
                    Cliente.CUIT = row["CUIT"].ToString();
                    Cliente.Domicilio = row["Domicilio"].ToString();
                    Cliente.TelefonoCelular = row["TelefonoCelular"].ToString();
                    Cliente.Email = row["Email"].ToString();

                    ListaClientes.Add(Cliente);
                }

                sResult = "";
                return ListaClientes;   

            }catch(Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }
        public static Cliente ObtenerClienteID(int id, out string sResult)
        {
            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);
            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spObtenerClienteID", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@id", id);
                

                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);

                var Cliente = new Cliente();

                if (dt.Rows.Count == 0)
                {
                    sResult = "No se encontró un resultado";
                    return null;
                }

                foreach (DataRow row in dt.Rows)
                {
                    Cliente.ID = int.Parse(row["ID"].ToString());
                    Cliente.Nombre = row["Nombres"].ToString();
                    Cliente.Apellido = row["Apellidos"].ToString();
                    Cliente.FechaDeNacimiento = DateTime.Parse(row["FechaDeNacimiento"].ToString());
                    Cliente.CUIT = row["CUIT"].ToString();
                    Cliente.Domicilio = row["Domicilio"].ToString();
                    Cliente.TelefonoCelular = row["TelefonoCelular"].ToString();
                    Cliente.Email = row["Email"].ToString();

                }

                sResult = "";
                return Cliente;

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }
        public static Cliente ObtenerClientePorNombre(string nombre, out string sResult)
        {
            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);
            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spBuscarPorNombre", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@nombre", nombre);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);

                var Cliente = new Cliente();

                if (dt.Rows.Count == 0)
                {
                    sResult = "No se encontró un resultado";
                    return null;
                }

                foreach (DataRow row in dt.Rows)
                {
                    Cliente.ID = int.Parse(row["ID"].ToString());
                    Cliente.Nombre = row["Nombres"].ToString();
                    Cliente.Apellido = row["Apellidos"].ToString();
                    Cliente.FechaDeNacimiento = DateTime.Parse(row["FechaDeNacimiento"].ToString());
                    Cliente.CUIT = row["CUIT"].ToString();
                    Cliente.Domicilio = row["Domicilio"].ToString();
                    Cliente.TelefonoCelular = row["TelefonoCelular"].ToString();
                    Cliente.Email = row["Email"].ToString();

                }

                sResult = "";
                return Cliente;

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }

        public static string InsertarCliente(Models.Cliente cliente)
        {
            string sResult = "";
            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);
            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spInsertarCliente", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;

                MySqlCommand.Parameters.AddWithValue("@ID", 0);
                MySqlCommand.Parameters.AddWithValue("@Nombres", cliente.Nombre);
                MySqlCommand.Parameters.AddWithValue("@Apellidos", cliente.Apellido);
                MySqlCommand.Parameters.AddWithValue("@FechaDeNacimiento", cliente.FechaDeNacimiento);
                MySqlCommand.Parameters.AddWithValue("@CUIT", cliente.CUIT);
                MySqlCommand.Parameters.AddWithValue("@Domicilio", cliente.Domicilio);
                MySqlCommand.Parameters.AddWithValue("@TelefonoCelular", cliente.TelefonoCelular);
                MySqlCommand.Parameters.AddWithValue("@Email", cliente.Email);
            
                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();

                MyConnection.Close();
                MyConnection.Dispose();
                

                

                sResult = "Cliente Creado con exito";
                

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }
            return sResult;
        }
        public static string ActualizarCliente(Models.Cliente cliente)
        {
            string sResult = "";
            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);
            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spActualizarCliente", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;

                MySqlCommand.Parameters.AddWithValue("@ID", cliente.ID);
                MySqlCommand.Parameters.AddWithValue("@Nombres", cliente.Nombre);
                MySqlCommand.Parameters.AddWithValue("@Apellidos", cliente.Apellido);
                MySqlCommand.Parameters.AddWithValue("@FechaDeNacimiento", cliente.FechaDeNacimiento);
                MySqlCommand.Parameters.AddWithValue("@CUIT", cliente.CUIT);
                MySqlCommand.Parameters.AddWithValue("@Domicilio", cliente.Domicilio);
                MySqlCommand.Parameters.AddWithValue("@TelefonoCelular", cliente.TelefonoCelular);
                MySqlCommand.Parameters.AddWithValue("@Email", cliente.Email);

                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();

                MyConnection.Close();
                MyConnection.Dispose();




                sResult = "Cliente Modificado con exito";


            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }
            return sResult;
        }

    }


}