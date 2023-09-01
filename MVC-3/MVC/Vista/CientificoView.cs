
public class CientificoView : Form
{
    // Controles
    private Label lblDni, lblNomApels;
    private TextBox txtDni, txtNomApels;
    private Button btnInsertar, btnActualizar, btnEliminar;

    private CientificoControlador controlador;
    private DataGridView dgvCientificos;

    public CientificoView(CientificoControlador controller)
    {
        this.controlador = controller;
        InitializeComponents();
        List<Cientifico> cientificos = controlador.ObtenerTodosLosCientificos();
        MostrarCientificos(cientificos);
    }

    private void InitializeComponents()
    {
        this.Text = "CRUD Científicos";
        this.Size = new Size(600, 500);

        lblDni = new Label() { Text = "DNI:", Location = new Point(10, 10) };
        txtDni = new TextBox() { Location = new Point(110, 10), Size = new Size(110, 20) };

        lblNomApels = new Label() { Text = "NomApels:", Location = new Point(10, 40) };
        txtNomApels = new TextBox() { Location = new Point(110, 40), Size = new Size(250, 20) };

        btnInsertar = new Button() { Text = "Insertar", Location = new Point(10, 280) };
        btnInsertar.Click += BtnInsertar_Click;

        btnActualizar = new Button() { Text = "Actualizar", Location = new Point(100, 280) };
        btnActualizar.Click += BtnActualizar_Click;

        btnEliminar = new Button() { Text = "Eliminar", Location = new Point(200, 280) };
        btnEliminar.Click += BtnEliminar_Click;

        dgvCientificos = new DataGridView()
        {
            Location = new Point(10, 70),
            Size = new Size(360, 200)
        };
        dgvCientificos.SelectionChanged += dgvCientificos_SelectionChanged;

        this.Controls.Add(dgvCientificos);
        this.Controls.Add(lblDni);
        this.Controls.Add(txtDni);
        this.Controls.Add(lblNomApels);
        this.Controls.Add(txtNomApels);
        this.Controls.Add(btnInsertar);
        this.Controls.Add(btnActualizar);
        this.Controls.Add(btnEliminar);
    }

    private void BtnInsertar_Click(object sender, EventArgs e)
    {
        Cientifico cientifico = GetCientifico();
        bool success = controlador.InsertarCientifico(cientifico);
        if (!success)
        {
            MessageBox.Show("Ya existe un científico con el mismo DNI. Por favor, introduce un DNI diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MostrarCientificos(controlador.ObtenerTodosLosCientificos());
        }
    }

    private void BtnActualizar_Click(object sender, EventArgs e)
    {
        // Lógica para actualizar un científico usando el controlador
        // Se asume que el DNI es inmutable
        Cientifico cientificoActualizado = GetCientifico();
        controlador.ActualizarCientifico(cientificoActualizado);

        // Actualiza la vista
        MostrarCientificos(controlador.ObtenerTodosLosCientificos());
    }

    private void BtnEliminar_Click(object sender, EventArgs e)
    {
        // Lógica para eliminar un científico usando el controlador
        Cientifico cientificoAEliminar = GetCientifico();
        controlador.EliminarCientifico(cientificoAEliminar.DNI);

        // Actualiza la vista
        MostrarCientificos(controlador.ObtenerTodosLosCientificos());
    }

    public void MostrarCientificos(List<Cientifico> cientificos)
    {
        dgvCientificos.DataSource = cientificos;
    }

    public Cientifico GetCientifico()
    {
        return new Cientifico()
        {
            DNI = txtDni.Text,
            NomApels = txtNomApels.Text
        };
    }

    private void dgvCientificos_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvCientificos.CurrentRow != null)
        {
            Cientifico selectedCientifico = (Cientifico)dgvCientificos.CurrentRow.DataBoundItem;

            txtDni.Text = selectedCientifico.DNI;
            txtNomApels.Text = selectedCientifico.NomApels;
        }
    }
}
