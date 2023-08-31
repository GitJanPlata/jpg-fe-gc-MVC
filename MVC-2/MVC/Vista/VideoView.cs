

namespace MVC
{
    public class VideoView : Form
    {
        private Label lblTitle, lblDirector, lblCliId;
        private TextBox txtTitle, txtDirector, txtCliId;
        private Button btnInsertar, btnActualizar, btnEliminar;
        private VideoControlador controlador;
        private DataGridView dgvVideos;
        private int selectedVideoId;

        public VideoView(VideoControlador controller)
        {
            this.controlador = controller;
            InitializeComponents();
            List<Video> videos = controlador.ObtenerTodosLosVideos();
            MostrarVideos(videos);
        }

        private void InitializeComponents()
        {
            this.Text = "CRUD Videos";
            this.Size = new Size(600, 500);

            lblTitle = new Label() { Text = "Título:", Location = new Point(10, 10) };
            txtTitle = new TextBox() { Location = new Point(110, 10), Size = new Size(110, 20) };

            lblDirector = new Label() { Text = "Director:", Location = new Point(10, 40) };
            txtDirector = new TextBox() { Location = new Point(110, 40), Size = new Size(110, 20) };

            lblCliId = new Label() { Text = "ID Cliente:", Location = new Point(10, 70) };
            txtCliId = new TextBox() { Location = new Point(110, 70), Size = new Size(110, 20) };

            btnInsertar = new Button() { Text = "Insertar", Location = new Point(10, 110) };
            btnInsertar.Click += (sender, e) =>
            {
                Video video = GetVideo();
                controlador.AgregarVideo(video);
                MessageBox.Show("Video insertado correctamente!");
                ActualizarDgvVideos();
            };

            btnActualizar = new Button() { Text = "Actualizar", Location = new Point(90, 110) };
            btnActualizar.Click += (sender, e) =>
            {
                Video video = GetVideo();
                controlador.ActualizarVideo(video);
                MessageBox.Show("Video actualizado correctamente!");
                ActualizarDgvVideos();
            };

            btnEliminar = new Button() { Text = "Eliminar", Location = new Point(170, 110) };
            btnEliminar.Click += (sender, e) =>
            {
                Video video = GetVideo();
                controlador.EliminarVideo(video.Id);
                MessageBox.Show("Video eliminado correctamente!");
                ActualizarDgvVideos();
            };

            dgvVideos = new DataGridView()
            {
                Location = new Point(10, 150),
                Size = new Size(360, 200)
            };
            dgvVideos.SelectionChanged += dgvVideos_SelectionChanged;

            this.Controls.Add(dgvVideos);
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblDirector);
            this.Controls.Add(txtDirector);
            this.Controls.Add(lblCliId);
            this.Controls.Add(txtCliId);
            this.Controls.Add(btnInsertar);
            this.Controls.Add(btnActualizar);
            this.Controls.Add(btnEliminar);
        }
        public void SetController(VideoControlador controller)
        {
            this.controlador = controller;
        }
        public void MostrarVideos(List<Video> videos)
        {
            dgvVideos.DataSource = videos;
        }

        public Video GetVideo()
        {
            return new Video()
            {
                Id = selectedVideoId,
                Title = txtTitle.Text,
                Director = txtDirector.Text,
                CliId = Convert.ToInt32(txtCliId.Text)
            };
        }

        private void dgvVideos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVideos.CurrentRow != null)
            {
                Video selectedVideo = (Video)dgvVideos.CurrentRow.DataBoundItem;
                selectedVideoId = selectedVideo.Id;

                txtTitle.Text = selectedVideo.Title;
                txtDirector.Text = selectedVideo.Director;
                txtCliId.Text = selectedVideo.CliId.ToString();
            }
        }

        public void ActualizarDgvVideos()
        {
            List<Video> videos = controlador.ObtenerTodosLosVideos();
            MostrarVideos(videos);
        }    
    }
}
