using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Dapper_en_C____Creación_de_un_CRUD_funcional.Models;

namespace Dapper_en_C____Creación_de_un_CRUD_funcional.Repository
{
    public class ProductoRepository
    {
        //readonly significa que el contenido de esa variable NO se podrá modificar.
        private readonly string CadenaConexión;

        //El constructor debe de tener el mismo nombre que la clase para que VS
        //lo reconozca como tal y no como un método común.
        public ProductoRepository(string CadenaConexión)
        {
            this.CadenaConexión = CadenaConexión;
        }

        //Método para crear una conexión a la base de datos
        private SqlConnection CrearConexión()
        {
            return new SqlConnection(CadenaConexión);
        }

        //Insertar Productos a la tabla (create)
        public void InsertarProducto(Producto producto)
        {
            using (var Conexión = CrearConexión())
            {
                string InsertarConsulta = "INSERT INTO Producto (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)";
                Conexión.Execute(InsertarConsulta, producto);
            }
        }
    }
}
