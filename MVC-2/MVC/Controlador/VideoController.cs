using MVC;

public class VideoControlador
{
    private VideoModel modelo;
    private VideoView vista;

    public VideoControlador()
    {
        this.modelo = new VideoModel();
        this.vista = new VideoView(this);
    }

    public void MostrarVista()
    {
        this.vista.ShowDialog();
    }

    public List<Video> ObtenerTodosLosVideos()
    {
        return modelo.ObtenerVideos();
    }

    public void AgregarVideo(Video video)
    {
        modelo.AgregarVideo(video);
    }

    public void ActualizarVideo(Video video)
    {
        modelo.ActualizarVideo(video);
    }

    public void EliminarVideo(int id)
    {
        modelo.EliminarVideo(id);
    }
}
