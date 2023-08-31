namespace MVC
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ClienteControlador controlador = new ClienteControlador();
            ClienteView vista = new ClienteView(controlador); 
            Application.Run(vista);
        }
    }
}
