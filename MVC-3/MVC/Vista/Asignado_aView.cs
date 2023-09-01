using System;
using System.Windows.Forms;
using System.Collections.Generic;

public class AsignadoView : Form
{
    private AsignadoControlador controlador;
    private DataGridView dgvAsignaciones;
    private ComboBox cmbCientificos, cmbProyectos;
    private Button btnAgregar,btnEliminar;

    public AsignadoView(AsignadoControlador controller)
    {
        this.controlador = controller;
        InitializeComponents();
        ListarAsignaciones();
    }

    private void InitializeComponents()
    {
        this.Text = "Asignaciones";
        this.Size = new Size(400, 300);

        dgvAsignaciones = new DataGridView()
        {
            Location = new Point(10, 10),
            Size = new Size(370, 150)
        };

        cmbCientificos = new ComboBox()
        {
            Location = new Point(10, 170),
            Size = new Size(180, 20)
        };

        cmbProyectos = new ComboBox()
        {
            Location = new Point(200, 170),
            Size = new Size(180, 20)
        };

        btnAgregar = new Button()
        {
            Text = "Agregar Asignación",
            Location = new Point(10, 210),
            Size = new Size(120, 30)
        };
        btnAgregar.Click += BtnAgregar_Click;

        btnEliminar = new Button()
        {
            Text = "Eliminar Asignación",
            Location = new Point(140, 210),
            Size = new Size(120, 30)
        };
        btnEliminar.Click += BtnEliminar_Click;

        this.Controls.Add(btnEliminar);

        this.Controls.Add(dgvAsignaciones);
        this.Controls.Add(cmbCientificos);
        this.Controls.Add(cmbProyectos);
        this.Controls.Add(btnAgregar);

        CargarDatosEnComboBoxes(); 

    }

    private void ListarAsignaciones()
    {
        List<Asignado_a> asignaciones = controlador.ObtenerTodasLasAsignaciones();
        dgvAsignaciones.DataSource = asignaciones;
    }

    private void BtnAgregar_Click(object sender, EventArgs e)
    {
        if (cmbCientificos.SelectedItem != null && cmbProyectos.SelectedItem != null)
        {
            Cientifico cientificoSeleccionado = cmbCientificos.SelectedItem as Cientifico;
            Proyecto proyectoSeleccionado = cmbProyectos.SelectedItem as Proyecto;

            if (cientificoSeleccionado != null && proyectoSeleccionado != null)
            {
                Asignado_a asignacion = new Asignado_a()
                {
                    Cientifico = cientificoSeleccionado.DNI, 
                    Proyecto = proyectoSeleccionado.Id 
                };
                controlador.AgregarAsignacion(asignacion);
                ListarAsignaciones();
            }
        }
        else
        {
            MessageBox.Show("Seleccione tanto un científico como un proyecto antes de agregar la asignación.");
        }
    }
    private void BtnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvAsignaciones.CurrentRow != null)
        {
            Asignado_a asignacionSeleccionada = dgvAsignaciones.CurrentRow.DataBoundItem as Asignado_a;
            if (asignacionSeleccionada != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar esta asignación?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    controlador.EliminarAsignacion(asignacionSeleccionada);
                    ListarAsignaciones();
                }
            }
        }
        else
        {
            MessageBox.Show("Por favor, selecciona una asignación para eliminar.");
        }
    }


    private void CargarDatosEnComboBoxes()
    {
        List<Cientifico> cientificos = controlador.ObtenerCientificos();
        cmbCientificos.DataSource = cientificos;
        cmbCientificos.DisplayMember = "NomApels"; 

        List<Proyecto> proyectos = controlador.ObtenerProyectos();
        cmbProyectos.DataSource = proyectos;
        cmbProyectos.DisplayMember = "Nombre"; 
    }

}
