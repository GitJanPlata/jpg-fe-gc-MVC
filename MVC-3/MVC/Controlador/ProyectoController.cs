
public class ProyectoControlador
{
    private ProyectoModel modelo = new ProyectoModel();

    public List<Proyecto> ObtenerTodosLosProyectos()
    {
        return modelo.ObtenerProyectos();
    }

    public void AgregarProyecto(Proyecto proyecto)
    {
        modelo.AgregarProyecto(proyecto);
    }

    public void ActualizarProyecto(Proyecto proyecto)
    {
        modelo.ActualizarProyecto(proyecto);
    }

    public void EliminarProyecto(string Id)
    {
        modelo.EliminarProyecto(Id);
    }
}
