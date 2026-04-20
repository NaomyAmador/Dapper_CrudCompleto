using Dapper_en_C____Creación_de_un_CRUD_funcional.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper_en_C____Creación_de_un_CRUD_funcional.Models;

namespace Dapper_en_C____Creación_de_un_CRUD_funcional
{
    public partial class Form1 : Form
    {
        string CadenadeConexión = "Server=LAPTOP-9G07MQQC\\SQLEXPRESS;Database=InventarioProductosDapper;Trusted_Connection=True;";
        
        //Este es un objeto que se le está creando a la clase ProductoRepository.
        ProductoRepository RepositorioProducto;
        public Form1()
        {
            InitializeComponent();
            RepositorioProducto = new ProductoRepository(CadenadeConexión);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            var Producto = new Producto
            {
                Nombre = TxtBox_Nombre.Text,
                Precio = decimal.Parse(TxtBox_Precio.Text),
                Stock = int.Parse(TxtBox_Stock.Text)
            };

            RepositorioProducto.InsertarProducto(Producto);
            MessageBox.Show("Producto agregado correctamente");
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtBox_Id.Text);
            var Producto = RepositorioProducto.ObtenerProductoporId(id);
            if (Producto != null)
            {
                DataGridView_TablaProductos.DataSource = new List<Producto> {Producto};
            }
            else
            {
                MessageBox.Show("Id no ecnontrado, asegúrese de insetar uno válido");
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            var Producto = new Producto
            {
                //Aquí se le indica al DataGridView que seleccione en la tabla la fila que tenemos seleccionada mediante el Id
                //y que este mismo nos muestre solo los datos pertenecientes al registro con ese Id, y que este nos lo devuelva en texto.
                Id = int.Parse(DataGridView_TablaProductos.CurrentRow.Cells["Id"].Value.ToString()),

                Nombre = TxtBox_Nombre.Text,
                Precio = decimal.Parse(TxtBox_Precio.Text),
                Stock = int.Parse(TxtBox_Stock.Text)
            };

            RepositorioProducto.ActualizarProducto(Producto);
            MessageBox.Show("Producto actualizado correctamente");
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            //Nota: Aquí se toma el Id del producto seleccionado en la tabla (como en el anterior).
            int id = int.Parse(DataGridView_TablaProductos.CurrentRow.Cells["Id"].Value.ToString());

            RepositorioProducto.EliminarProducto(id);
            MessageBox.Show("Producto eliminado correctamente");
        }
    }
}
