
public class CientificoControlador
{
    private CientificoModel modelo = new CientificoModel();

    public List<Cientifico> ObtenerTodosLosCientificos()
    {
        return modelo.ObtenerCientificos();
    }

    public bool InsertarCientifico(Cientifico cientifico)
    {
        bool success = modelo.InsertarCientifico(cientifico);
        if (!success)
        {
            return false;
        }
        return true;
    }

    public void ActualizarCientifico(Cientifico cientifico)
    {
        modelo.ActualizarCientifico(cientifico);
    }

    public void EliminarCientifico(string DNI)
    {
        modelo.EliminarCientifico(DNI);
    }

    public void CerrarConexion()
    {
        modelo.CloseConnection();
    }
}
