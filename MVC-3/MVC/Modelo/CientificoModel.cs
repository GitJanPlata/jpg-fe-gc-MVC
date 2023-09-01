using System.Data.SQLite;

public class Cientifico
{
    public string DNI { get; set; }
    public string NomApels { get; set; }

}
public class CientificoModel
{
    private string connectionString = "Data Source=E:\\bootcamp\\BACKEND\\jpg-fe-gc-MVC\\MVC-3\\MVC\\Base de datos\\EmbeddedBD.db";
    private SQLiteConnection conn2;

    public CientificoModel()
    {
        this.conn2 = new SQLiteConnection(connectionString);
        this.conn2.Open();
    }

    public List<Cientifico> ObtenerCientificos()
    {
        List<Cientifico> cientificos = new List<Cientifico>();

        string query = "SELECT * FROM cientificos";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cientificos.Add(new Cientifico
                    {
                        DNI = reader.GetString(0),
                        NomApels = reader.GetString(1)
                    });
                }
            }
        }

        return cientificos;
    }

    public bool InsertarCientifico(Cientifico cientifico)
    {
        try
        {
            string query = "INSERT INTO cientificos (DNI, NomApels) VALUES (@DNI, @NomApels)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
            {
                cmd.Parameters.AddWithValue("@DNI", cientifico.DNI);
                cmd.Parameters.AddWithValue("@NomApels", cientifico.NomApels);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        catch (SQLiteException ex)
        {
            if (ex.ResultCode == SQLiteErrorCode.Constraint) 
            {
                return false;
            }
            throw; 
        }
    }

    public void ActualizarCientifico(Cientifico cientifico)
    {
        string query = "UPDATE cientificos SET NomApels = @NomApels WHERE DNI = @DNI";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            cmd.Parameters.AddWithValue("@NomApels", cientifico.NomApels);
            cmd.Parameters.AddWithValue("@DNI", cientifico.DNI);
            cmd.ExecuteNonQuery();
        }
    }

    public void EliminarCientifico(string DNI)
    {
        string query = "DELETE FROM cientificos WHERE DNI = @DNI";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            cmd.Parameters.AddWithValue("@DNI", DNI);
            cmd.ExecuteNonQuery();
        }
    }

    public void CloseConnection()
    {
        if (this.conn2 != null && this.conn2.State == System.Data.ConnectionState.Open)
        {
            this.conn2.Close();
        }
    }
}
