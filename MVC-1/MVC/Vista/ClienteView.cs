using MVC.Modelo;

public class ClienteView : Form
{
    // Controles
    private Label lblNombre, lblApellido, lblDireccion, lblDni, lblFecha;
    private TextBox txtNombre, txtApellido, txtDireccion, txtDni;
    private DateTimePicker dtpFecha;
    private Button btnInsertar, btnActualizar, btnEliminar;

    private ClienteControlador controlador;
    private DataGridView dgvClientes;
    private int selectedClienteId;

    public ClienteView(ClienteControlador controller)
    {
        this.controlador = controller;
        InitializeComponents();
        List<Cliente> clientes = controlador.ObtenerTodosLosClientes();
        MostrarClientes(clientes);
    }

    private void InitializeComponents()
    {
        this.Text = "CRUD Clientes";
        this.Size = new Size(600, 500);

        lblNombre = new Label() { Text = "Nombre:", Location = new Point(10, 10) };
        txtNombre = new TextBox() { Location = new Point(110, 10), Size = new Size(110, 20) };

        lblApellido = new Label() { Text = "Apellido:", Location = new Point(10, 40) };
        txtApellido = new TextBox() { Location = new Point(110, 40), Size = new Size(110, 20) };

        lblDireccion = new Label() { Text = "Dirección:", Location = new Point(10, 70) };
        txtDireccion = new TextBox() { Location = new Point(110, 70), Size = new Size(110, 20) };

        lblDni = new Label() { Text = "DNI:", Location = new Point(10, 100) };
        txtDni = new TextBox() { Location = new Point(110, 100), Size = new Size(110, 20) };

        lblFecha = new Label() { Text = "Fecha:", Location = new Point(10, 130) };
        dtpFecha = new DateTimePicker() { Location = new Point(110, 130) };

        btnInsertar = new Button() { Text = "Insertar", Location = new Point(10, 170) };
        btnInsertar.Click += (sender, e) =>
        {
            Cliente cliente = GetCliente();
            controlador.AgregarCliente(cliente);
            MessageBox.Show("Cliente insertado correctamente!");
            ActualizarDgvClientes();
        };

        btnActualizar = new Button() { Text = "Actualizar", Location = new Point(90, 170) };
        btnActualizar.Click += (sender, e) =>
        {
            Cliente cliente = GetCliente();
            controlador.ActualizarCliente(cliente);
            MessageBox.Show("Cliente actualizado correctamente!");
            ActualizarDgvClientes();
        };

        btnEliminar = new Button() { Text = "Eliminar", Location = new Point(170, 170) };
        btnEliminar.Click += (sender, e) =>
        {
            Cliente cliente = GetCliente();
            controlador.EliminarCliente(cliente.Id);  // Asumiendo que tienes un ID en tu vista para trabajar con él.
            MessageBox.Show("Cliente eliminado correctamente!");
            ActualizarDgvClientes();
        };

        dgvClientes = new DataGridView()
        {
            Location = new Point(10, 200),
            Size = new Size(360, 200)
        };

        dgvClientes.SelectionChanged += dgvClientes_SelectionChanged; 


        this.Controls.Add(dgvClientes);
        this.Controls.Add(lblNombre);
        this.Controls.Add(txtNombre);
        this.Controls.Add(lblApellido);
        this.Controls.Add(txtApellido);
        this.Controls.Add(lblDireccion);
        this.Controls.Add(txtDireccion);
        this.Controls.Add(lblDni);
        this.Controls.Add(txtDni);
        this.Controls.Add(lblFecha);
        this.Controls.Add(dtpFecha);
        this.Controls.Add(btnInsertar);
        this.Controls.Add(btnActualizar);
        this.Controls.Add(btnEliminar);
    }
    public void MostrarClientes(List<Cliente> clientes)
    {
        dgvClientes.DataSource = clientes;
    }

    public Cliente GetCliente()
    {
        return new Cliente()
        {
            Id = selectedClienteId,
            Nombre = txtNombre.Text,
            Apellido = txtApellido.Text,
            Direccion = txtDireccion.Text,
            Dni = Convert.ToInt32(txtDni.Text),
            Fecha = dtpFecha.Value
        };
    }
    private void dgvClientes_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvClientes.CurrentRow != null)
        {
            Cliente selectedCliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            selectedClienteId = selectedCliente.Id;

            txtNombre.Text = selectedCliente.Nombre;
            txtApellido.Text = selectedCliente.Apellido;
            txtDireccion.Text = selectedCliente.Direccion;
            txtDni.Text = selectedCliente.Dni.ToString();
            dtpFecha.Value = selectedCliente.Fecha;
        }
    }
    public void ActualizarDgvClientes()
    {
        List<Cliente> clientes = controlador.ObtenerTodosLosClientes();
        MostrarClientes(clientes);
    }

}
