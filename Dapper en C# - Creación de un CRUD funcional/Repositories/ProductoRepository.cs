using Dapper;
using Dapper_en_C____Creación_de_un_CRUD_funcional.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        //Buscar Productos en la tabla por Id (read)
        public Producto ObtenerProductoporId(int id)
        {
            //El QueryFirstOrDefault<Producto> le pide a Dapper que devuelva
            //el primer resultado y que lo conviérta en un objeto Producto.
            //si lo encuentra devuelve el objeto Producto, sino devuelve null.
            using (var Conexión = CrearConexión())
            {
                string BuscarPorIdConsulta = "SELECT * FROM Producto WHERE Id = @Id";
                return Conexión.QueryFirstOrDefault<Producto>(BuscarPorIdConsulta, new { Id = id });
            }
            //Importante: En esta línea "new {Id = id}" se crea un objeto temporal con el valor del
            //Id para pasarlo al SQL.
        }

        //Actualizar Productos en la tabla (Update)
        public int ActualizarProducto(Producto producto)
        {
            using (var Conexión = CrearConexión())
            {
                string ActualizarConsulta = @"UPDATE Producto SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock
                                            WHERE Id = @Id";
                return Conexión.Execute(ActualizarConsulta, producto);
            }
        }

        //Eliminar Productos en la tabla (delete)
        //Aquí se hace algo similar a lo hecho en el método para buscar, colo que aquí se le pone
        //otro nombre a la variable a comparar: Idproducto.
        public int EliminarProducto(int Idproducto)
        {
            using (var Conexión = CrearConexión())
            {
                string EliminarConsulta = "DELETE FROM Producto WHERE Id = @Id";
                return Conexión.Execute(EliminarConsulta, new { Id = Idproducto });
            }
        }

        public List<Producto> VerProductos()
        {
            using (var Conexión = CrearConexión())
            {
                string ListarConsulta = "SELECT * FROM Producto";
                return Conexión.Query<Producto>(ListarConsulta).ToList();
            }
        }
    }
}
