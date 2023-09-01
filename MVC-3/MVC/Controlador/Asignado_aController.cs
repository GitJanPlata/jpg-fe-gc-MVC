using System.Collections.Generic;

public class AsignadoControlador
{
    private AsignadoModel modelo;
    private CientificoModel cientificoModel; 
    private ProyectoModel proyectoModel;     

    public AsignadoControlador()
    {
        modelo = new AsignadoModel();
        cientificoModel = new CientificoModel();
        proyectoModel = new ProyectoModel();
    }

    public List<Asignado_a> ObtenerTodasLasAsignaciones()
    {
        return modelo.ObtenerAsignaciones();
    }

    public bool AgregarAsignacion(Asignado_a asignacion)
    {
        try
        {
            modelo.AgregarAsignacion(asignacion);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool ActualizarAsignacion(Asignado_a asignacionAnterior, Asignado_a asignacionNueva)
    {
        try
        {
            modelo.ActualizarAsignacion(asignacionAnterior, asignacionNueva);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool EliminarAsignacion(Asignado_a asignacion)
    {
        try
        {
            modelo.EliminarAsignacion(asignacion);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public List<Cientifico> ObtenerCientificos()
    {
        return cientificoModel.ObtenerCientificos();
    }

    public List<Proyecto> ObtenerProyectos()
    {
        return proyectoModel.ObtenerProyectos();
    }
}
