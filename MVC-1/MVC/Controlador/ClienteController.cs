using MVC.Modelo;

public class ClienteControlador
{
    private ClienteModel modelo = new ClienteModel();

    public List<Cliente> ObtenerTodosLosClientes()
    {
        return modelo.ObtenerClientes();
    }
    public void AgregarCliente(Cliente cliente)
    {
        modelo.AgregarCliente(cliente);
    }

    public void ActualizarCliente(Cliente cliente)
    {
        modelo.ActualizarCliente(cliente);
    }

    public void EliminarCliente(int id)
    {
        modelo.EliminarCliente(id);
    }
}
