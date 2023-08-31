using System.Data.SQLite;
using MVC.Modelo;



public class ClienteModel
{
    private string connectionString = "Data Source=E:\\bootcamp\\BACKEND\\jpg-fe-gc-MVC\\MVC-1\\MVC\\Base de datos\\EmbeddedBD.db";

    private SQLiteConnection conn2;
    public ClienteModel () 
    {
        this.conn2 = new SQLiteConnection (connectionString);
        this.conn2.Open ();
    }

    
   public List<Cliente> ObtenerClientes()
    {
        List<Cliente> clientes = new List<Cliente>();

        SQLiteConnection con = new SQLiteConnection(connectionString);
        
            string query = "SELECT * FROM cliente";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);


                SQLiteDataReader reader = cmd.ExecuteReader();
                
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                           
                            Nombre = reader.GetString(0),
                            Apellido = reader.GetString(1),
                            Direccion = reader.GetString(2),
                            Dni = reader.GetInt32(3),
                            Fecha = reader.GetDateTime(4),
                            Id = reader.GetInt32(5)
                        });
                    }
                
        return clientes;
    }

    public void AgregarCliente(Cliente cliente)
    { 
        string query = "INSERT INTO cliente(Nombre, Apellido, Direccion, Dni, Fecha) VALUES (@nombre, @apellido, @direccion, @dni, @fecha)";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);
                
        cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
        cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
        cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
        cmd.Parameters.AddWithValue("@dni", cliente.Dni);
        cmd.Parameters.AddWithValue("@fecha", cliente.Fecha);
        cmd.ExecuteNonQuery();   
    }

    public void ActualizarCliente(Cliente cliente)
    {
        SQLiteConnection con = new SQLiteConnection(connectionString);
        
            string query = "UPDATE cliente SET Nombre=@nombre, Apellido=@apellido, Direccion=@direccion, Dni=@dni, Fecha=@fecha WHERE Id=@id";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);
            
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                cmd.Parameters.AddWithValue("@fecha", cliente.Fecha);
                cmd.ExecuteNonQuery();
    }

    public void EliminarCliente(int id)
    {
      
            string query = "DELETE FROM cliente WHERE Id=@id";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
       
    }
}
