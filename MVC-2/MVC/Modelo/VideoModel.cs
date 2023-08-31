using System;
using System.Data.SQLite;
using System.Collections.Generic;
using MVC.Modelo;
using System.Windows.Forms;

public class VideoModel
{
    private string connectionString = "Data Source=E:\\bootcamp\\BACKEND\\jpg-fe-gc-MVC\\MVC-2\\MVC\\Base de datos\\EmbeddedBD.db";
    private SQLiteConnection conn2;

    public VideoModel()
    {
        this.conn2 = new SQLiteConnection(connectionString);
        this.conn2.Open();
    }

    public List<Video> ObtenerVideos()
    {
        List<Video> videos = new List<Video>();
        string query = "SELECT * FROM videos";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                videos.Add(new Video
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Director = reader.GetString(2),
                    CliId = reader.GetInt32(3)
                });
            }
        }
        return videos;
    }

    public void AgregarVideo(Video video)
    {
        string query = "INSERT INTO videos(Title, Director, CliId) VALUES (@title, @director, @cliId)";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            cmd.Parameters.AddWithValue("@title", video.Title);
            cmd.Parameters.AddWithValue("@director", video.Director);
            cmd.Parameters.AddWithValue("@cliId", video.CliId);
            cmd.ExecuteNonQuery();
        }
    }

    public void ActualizarVideo(Video video)
    {
        string query = "UPDATE videos SET Title=@title, Director=@director, CliId=@cliId WHERE Id=@id";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            cmd.Parameters.AddWithValue("@id", video.Id);
            cmd.Parameters.AddWithValue("@title", video.Title);
            cmd.Parameters.AddWithValue("@director", video.Director);
            cmd.Parameters.AddWithValue("@cliId", video.CliId);
            cmd.ExecuteNonQuery();
        }
    }

    public void EliminarVideo(int id)
    {
        string query = "DELETE FROM videos WHERE Id=@id";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn2))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
