using System;
using System.Windows.Forms;
using System.Collections.Generic;

public class ProyectoView : Form
{
    private ProyectoControlador controlador;
    private DataGridView dgvProyectos;
    private Label lblId, lblNombre, lblHoras;
    private TextBox txtId, txtNombre, txtHoras;
    private Button btnAgregar, btnActualizar, btnEliminar;

    public ProyectoView(ProyectoControlador controller)
    {
        this.controlador = controller;
        InitializeComponents();
        ListarProyectos();
    }

    private void InitializeComponents()
    {
        this.Text = "CRUD Proyectos";
        this.Size = new Size(600, 500);

        lblId = new Label() { Text = "ID:", Location = new Point(10, 10) };
        txtId = new TextBox() { Location = new Point(110, 10), Width = 100 };

        lblNombre = new Label() { Text = "Nombre:", Location = new Point(10, 40) };
        txtNombre = new TextBox() { Location = new Point(110, 40), Width = 250 };

        lblHoras = new Label() { Text = "Horas:", Location = new Point(10, 70) };
        txtHoras = new TextBox() { Location = new Point(110, 70), Width = 100 };

        btnAgregar = new Button() { Text = "Agregar", Location = new Point(10, 100) };
        btnAgregar.Click += BtnAgregar_Click;

        btnActualizar = new Button() { Text = "Actualizar", Location = new Point(90, 100) };
        btnActualizar.Click += BtnActualizar_Click;

        btnEliminar = new Button() { Text = "Eliminar", Location = new Point(180, 100) };
        btnEliminar.Click += BtnEliminar_Click;

        dgvProyectos = new DataGridView()
        {
            Location = new Point(10, 140),
            Size = new Size(560, 300)
        };
        dgvProyectos.SelectionChanged += DgvProyectos_SelectionChanged;

        this.Controls.AddRange(new Control[] { lblId, txtId, lblNombre, txtNombre, lblHoras, txtHoras, btnAgregar, btnActualizar, btnEliminar, dgvProyectos });
    }

    private void ListarProyectos()
    {
        List<Proyecto> proyectos = controlador.ObtenerTodosLosProyectos();
        dgvProyectos.DataSource = proyectos;
    }

    private void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtHoras.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Proyecto proyecto = new Proyecto()
            {
                Id = txtId.Text,
                Nombre = txtNombre.Text,
                Horas = int.Parse(txtHoras.Text) 
            };

            controlador.AgregarProyecto(proyecto);
            MessageBox.Show("Proyecto añadido con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListarProyectos();
        }
        catch (FormatException)
        {
            MessageBox.Show("Por favor, ingrese un número válido en el campo 'Horas'.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void BtnActualizar_Click(object sender, EventArgs e)
    {
        Proyecto proyecto = new Proyecto()
        {
            Id = txtId.Text,
            Nombre = txtNombre.Text,
            Horas = int.Parse(txtHoras.Text)
        };
        controlador.ActualizarProyecto(proyecto);
        ListarProyectos();
    }

    private void BtnEliminar_Click(object sender, EventArgs e)
    {
        controlador.EliminarProyecto(txtId.Text);
        ListarProyectos();
    }

    private void DgvProyectos_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProyectos.CurrentRow != null)
        {
            Proyecto proyectoSeleccionado = (Proyecto)dgvProyectos.CurrentRow.DataBoundItem;
            txtId.Text = proyectoSeleccionado.Id;
            txtNombre.Text = proyectoSeleccionado.Nombre;
            txtHoras.Text = proyectoSeleccionado.Horas.ToString();
        }
    }
}

