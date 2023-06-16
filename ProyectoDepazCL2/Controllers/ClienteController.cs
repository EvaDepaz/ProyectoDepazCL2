using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProyectoDepazCL2.Models;

namespace ProyectoDepazCL2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        private string Cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        #region Métodos

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlConnection cnn = new SqlConnection(Cadena);
            SqlCommand cmd = new SqlCommand("usp_Clientes_Listar", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente oCliente = new Cliente()
                {
                    IdCliente = dr["IdCliente"].ToString(),
                    NombreCia = dr["NombreCia"].ToString(),
                    Direccion = dr["Direccion"].ToString(),
                    Idpais = dr["idpais"].ToString(),
                    Telefono = dr["Telefono"].ToString()



                };
                lista.Add(oCliente);

            }
            cnn.Close();
            return lista;

        }

        public Cliente Seleccionar(string IdCliente)
        {
            Cliente oCliente = new Cliente();
            SqlConnection cnn = new SqlConnection(Cadena);
            SqlCommand cmd = new SqlCommand("usp_Categoria_Clientes_Seleccionar", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                oCliente.IdCliente = dr["IdCliente"].ToString();
                oCliente.NombreCia = dr["NombreCia"].ToString();
                oCliente.Direccion = dr["Direccion"].ToString();
                oCliente.Idpais= dr["idpais"].ToString();
                oCliente.Telefono = dr["Telefono"].ToString();
            }
            cnn.Close();

            return oCliente;


        }

        public bool Registrar(Cliente oCliente)
        {
            bool rpta = false;
            try
            {
                SqlConnection cnn = new SqlConnection(Cadena);
                SqlCommand cmd = new SqlCommand("usp_Clientes_Registrar", cnn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", oCliente.IdCliente);
                cmd.Parameters.AddWithValue("@NombreCia", oCliente.NombreCia);
                cmd.Parameters.AddWithValue("@Direccion", oCliente.Direccion);
                cmd.Parameters.AddWithValue("@idpais", oCliente.Idpais);
                cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                rpta = true;
            }
            catch(Exception)
            {
                rpta = false;
            }
            return rpta;
        }
        
        #endregion



        public ActionResult Index()
        {
            return View(Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente oCliente)
        {
            //Realizar el registro del cliente
            Registrar(oCliente);
            //Redireccionar a la acción Index
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id) 
        {
            return View(Seleccionar(id)); 
        }

        public ActionResult Details (string id)
        {
            return View(Seleccionar(id));
        }

        public ActionResult Delete(string id)
        { 
            return View(Seleccionar(id));
        }



    }
}