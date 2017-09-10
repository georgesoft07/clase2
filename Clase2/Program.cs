using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Clase2.DAL;

namespace Clase2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioDeProductos servicioProducto = new ServicioDeProductos();
            NuevoProducto nuevoProducto = new NuevoProducto();
            nuevoProducto.Name = "jorge";
            nuevoProducto.Password = "george001";
            nuevoProducto.Enable = true;
            servicioProducto.CrearUnNuevoProducto(nuevoProducto);

           
            ProductoGenerico nuevoProducto2 = new ProductoGenerico();
            nuevoProducto2.Id = 7;
            servicioProducto.EliminarProducto(nuevoProducto2);



            servicioProducto.ListarTodosLosProductos().ForEach(producto => Console.WriteLine(producto.Name));

            Console.ReadKey();
        }
    }
}
