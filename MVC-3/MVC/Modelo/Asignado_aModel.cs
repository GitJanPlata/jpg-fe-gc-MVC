using System.Data.SQLite;
using System.Collections.Generic;

public class Asignado_a
{
    public string Cientifico { get; set; }
    public string Proyecto { get; set; }
}

public class AsignadoModel
{
    private string connectionString = "Data Source=E:\\bootcamp\\BACKEND\\jpg-fe-gc-MVC\\MVC-3\\MVC\\Base de datos\\EmbeddedBD.db";
    private SQLiteConnection conn2;

    public AsignadoModel()
    {
        this.conn2 = new SQLiteConnection(connectionString);
        this.conn2.Open();
    }

    public List<Asignado_a> ObtenerAsignaciones()
    {
        List<Asignado_a> asignaciones = new List<Asignado_a>();

        string query = "SELECT * FROM Asignado_a";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);
        SQLiteDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            asignaciones.Add(new Asignado_a
            {
                Cientifico = reader.GetString(0),
                Proyecto = reader.GetString(1)
            });
        }

        return asignaciones;
    }

    public void AgregarAsignacion(Asignado_a asignacion)
    {
        string query = "INSERT INTO Asignado_a (Cientifico, Proyecto) VALUES (@Cientifico, @Proyecto)";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);
        cmd.Parameters.AddWithValue("@Cientifico", asignacion.Cientifico);
        cmd.Parameters.AddWithValue("@Proyecto", asignacion.Proyecto);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarAsignacion(Asignado_a asignacionAnterior, Asignado_a asignacionNueva)
    {
        string query = "UPDATE Asignado_a SET Cientifico = @CientificoNuevo, Proyecto = @ProyectoNuevo WHERE Cientifico = @CientificoAnterior AND Proyecto = @ProyectoAnterior";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);
        cmd.Parameters.AddWithValue("@CientificoAnterior", asignacionAnterior.Cientifico);
        cmd.Parameters.AddWithValue("@ProyectoAnterior", asignacionAnterior.Proyecto);
        cmd.Parameters.AddWithValue("@CientificoNuevo", asignacionNueva.Cientifico);
        cmd.Parameters.AddWithValue("@ProyectoNuevo", asignacionNueva.Proyecto);
        cmd.ExecuteNonQuery();
    }

    public void EliminarAsignacion(Asignado_a asignacion)
    {
        string query = "DELETE FROM Asignado_a WHERE Cientifico = @Cientifico AND Proyecto = @Proyecto";
        SQLiteCommand cmd = new SQLiteCommand(query, conn2);
        cmd.Parameters.AddWithValue("@Cientifico", asignacion.Cientifico);
        cmd.Parameters.AddWithValue("@Proyecto", asignacion.Proyecto);
        cmd.ExecuteNonQuery();
    }
}
