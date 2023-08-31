using System;
using System.Windows.Forms;

namespace MVC
{
    public class MainMenu : Form
    {
        private Button btnClientes, btnVideos;

        public MainMenu()
        {
            this.Text = "Menú Principal";
            this.Size = new Size(250, 200);

            btnClientes = new Button() { Text = "CRUD Clientes", Location = new Point(50, 30), Size = new Size(150, 30) };
            btnClientes.Click += (sender, e) =>
            {
                ClienteControlador controlador = new ClienteControlador();
                ClienteView clienteVista = new ClienteView(controlador);
                clienteVista.ShowDialog();
            };

            btnVideos = new Button() { Text = "CRUD Videos", Location = new Point(50, 80), Size = new Size(150, 30) };
            btnVideos = new Button() { Text = "CRUD Videos", Location = new Point(50, 80), Size = new Size(150, 30) };
            btnVideos.Click += (sender, e) =>
            {
                VideoControlador videoControlador = new VideoControlador();
                videoControlador.MostrarVista();
            };



            this.Controls.Add(btnClientes);
            this.Controls.Add(btnVideos);
        }
    }
}
