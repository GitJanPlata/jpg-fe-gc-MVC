using System;
using System.Windows.Forms;

namespace MVC
{
    public class MainMenu : Form
    {
        private Button btnCientificos, btnProyectos, btnAsignaciones;

        public MainMenu()
        {
            this.Text = "Menú Principal";
            this.Size = new Size(250, 200);

            btnCientificos = new Button() { Text = "CRUD Científicos", Location = new Point(50, 30), Size = new Size(150, 30) };
            btnCientificos.Click += (sender, e) =>
            {
                CientificoControlador controlador = new CientificoControlador();
                CientificoView cientificoVista = new CientificoView(controlador);
                cientificoVista.ShowDialog();
            };

            btnProyectos = new Button() { Text = "CRUD Proyectos", Location = new Point(50, 80), Size = new Size(150, 30) };
            btnProyectos.Click += (sender, e) =>
            {
                ProyectoControlador proyectoControlador = new ProyectoControlador();
                ProyectoView proyectoVista = new ProyectoView(proyectoControlador);
                proyectoVista.ShowDialog();
            };

            btnAsignaciones = new Button() { Text = "CRUD Asignaciones", Location = new Point(50, 130), Size = new Size(150, 30) };
            btnAsignaciones.Click += (sender, e) =>
            {
                AsignadoControlador controladorAsignaciones = new AsignadoControlador();
                AsignadoView asignadoVista = new AsignadoView(controladorAsignaciones);
                asignadoVista.ShowDialog();
            };

            this.Controls.Add(btnAsignaciones);
            this.Controls.Add(btnCientificos);
            this.Controls.Add(btnProyectos);
        }
    }
}
