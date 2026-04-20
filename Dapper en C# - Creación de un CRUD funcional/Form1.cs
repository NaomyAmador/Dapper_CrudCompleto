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
    }
}
