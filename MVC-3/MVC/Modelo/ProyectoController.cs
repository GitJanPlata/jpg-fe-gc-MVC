using System.Data.SQLite;
public class Proyecto
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public int Horas { get; set; }
}
public class ProyectoModel
{
    private string connectionString = "Data Source=E:\\bootcamp\\BACKEND\\jpg-fe-gc-MVC\\MVC-3\\MVC\\Base de datos\\EmbeddedBD.db";
    private SQLiteConnection conn;

    public ProyectoModel()
    {
        this.conn = new SQLiteConnection(connectionString);
        this.conn.Open();
    }

    public List<Proyecto> ObtenerProyectos()
    {
        List<Proyecto> proyectos = new List<Proyecto>();

        string query = "SELECT * FROM Proyecto";
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        SQLiteDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            proyectos.Add(new Proyecto
            {
                Id = reader.GetString(0),
                Nombre = reader.GetString(1),
                Horas = reader.GetInt32(2)
            });
        }

        reader.Close();
        return proyectos;
    }

    public void AgregarProyecto(Proyecto proyecto)
    {
        try
        {
            string query = "INSERT INTO Proyecto (Id, Nombre, Horas) VALUES (@Id, @Nombre, @Horas)";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", proyecto.Id);
            cmd.Parameters.AddWithValue("@Nombre", proyecto.Nombre);
            cmd.Parameters.AddWithValue("@Horas", proyecto.Horas);

            cmd.ExecuteNonQuery();
        }
        catch (SQLiteException ex)
        {
            if (ex.ResultCode == SQLiteErrorCode.Constraint) 
            {
                throw new Exception("El ID del proyecto ya está en uso.");
            }
            throw; 
        }
    }

    public void ActualizarProyecto(Proyecto proyecto)
    {
        string query = "UPDATE Proyecto SET Nombre = @Nombre, Horas = @Horas WHERE Id = @Id";
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", proyecto.Id);
        cmd.Parameters.AddWithValue("@Nombre", proyecto.Nombre);
        cmd.Parameters.AddWithValue("@Horas", proyecto.Horas);

        cmd.ExecuteNonQuery();
    }

    public void EliminarProyecto(string Id)
    {
        string query = "DELETE FROM Proyecto WHERE Id = @Id";
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.ExecuteNonQuery();
    }
}