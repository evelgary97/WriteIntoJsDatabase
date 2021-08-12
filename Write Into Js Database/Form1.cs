using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Write_Into_Js_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FileChooser(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tbImagen.Text = fileDialog.FileName;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!tbImagen.Text.Equals(""))
            {
                var nombre = tbNombre.Text;
                var categoria = tbCategoria.Text;
                var descripcion = tbDescripcion.Text;
                var cantidad = tbCantidad.Text;
                var modelo = tbModelo.Text;
                var imagen = tbImagen.Text;
                var imagenPrint = SelectName(imagen);
                var precioUsd = tbPrecioUsd.Text;
                var precioCup = tbPrecioCup.Text;
                var prioridad = tbPriodidad.Text;

                var sw = new StreamWriter("database.js", true);
                sw.WriteLine($"productos.push(new Product('{nombre}', categorias[{categoria}], '{descripcion}', {cantidad}, '{modelo}', 'static/prod-img/{imagenPrint}', {precioUsd}, {precioCup}, {prioridad}));");
                sw.Close();

                var source = new FileInfo(imagen);
                //C:\Users\evelgary97\Documents\Untitled-1.cs

                source.CopyTo($"static\\prod-img\\{imagenPrint}", true);

                tbNombre.Text = "";
                tbCategoria.Text = "";
                tbDescripcion.Text = "";
                tbCantidad.Text = "1";
                tbModelo.Text = "";
                tbImagen.Text = "";
                tbPrecioUsd.Text = "0";
                tbPrecioCup.Text = "0";
                tbPriodidad.Text = "100";
                MessageBox.Show(this, "En talla");

            }
            else {
                MessageBox.Show(this, "Añade una imagen idiota");
            }
        }

        private string SelectName(string s)
        {
            var t = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\\')
                {
                    t = i;
                }
            }
            return s.Substring(t + 1);
        }
    }
}
