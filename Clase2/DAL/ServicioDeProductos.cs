using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.DAL
{
    public class ServicioDeProductos
    {
        public void CrearUnNuevoProducto(NuevoProducto producto) {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("CrearUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Name", producto.Name));
            comando.Parameters.Add(new SqlParameter("@Password", producto.Password));
            comando.Parameters.Add(new SqlParameter("@Enable", producto.Enable));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }

        public List<ProductoGenerico> ListarTodosLosProductos() {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("ListarUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            SqlDataReader lectorDeDatos = comando.ExecuteReader();
            List<ProductoGenerico> productos = new List<ProductoGenerico>();
            while (lectorDeDatos.Read())
            {
                ProductoGenerico producto = new ProductoGenerico();
                producto.Id = (int)lectorDeDatos.GetInt32(0);
                producto.Name = lectorDeDatos.GetString(1);
                producto.Password = lectorDeDatos.GetString(2);
                producto.Enable = lectorDeDatos.GetBoolean(3);
                productos.Add(producto);
            }
            conection.Close();
            return productos;
        }


        public void EliminarProducto(ProductoGenerico producto)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("BorrarUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", producto.Id));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }



        private SqlConnection iniciarConexion() {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;
            return conection;
        }


    }
}
