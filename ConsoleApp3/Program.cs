using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;
using Microsoft.Win32;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
           
            if (IsConnectedToInternet())
            {
                Thread form = new Thread(formstart);
                form.Start();
              
            }
            else
            {
               
                Thread form = new Thread(errorformstart);
                form.Start();
                bridge.errormessage = "Please Check your intenet connection";
               
            }
            while (!bridge.Connect) ;
            setuserinfo();
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            var spFactory = new DefaultServiceProviderFactory();
            var sc = new ServiceCollection();
            ConfigureServices(sc);
            var spBuilder = spFactory.CreateBuilder(sc);
            var container = spFactory.CreateServiceProvider(spBuilder);
            var loggerFactory = container.GetRequiredService<ILoggerFactory>();
            using (var demo = container.GetRequiredService<FBoxDemo>())
            {
                demo.Go().Wait();
                string ln;
                do
                {
                    ln = "";// Console.ReadLine();
                  //  Console.WriteLine("there  i am");
                } while (ln != "quit");
            }
        }
        public static void setuserinfo()
        {
           
            FBoxClientParameters.UserName = Properties.Settings.Default.username;

            FBoxClientParameters.Password = Properties.Settings.Default.password;
           
            bridge.servername = Properties.Settings.Default.servername;
           
            bridge.serverdbname = Properties.Settings.Default.serverdb;
            
            bridge.servertbname = Properties.Settings.Default.servertb;
           
            bridge.serverusername = Properties.Settings.Default.serverusername;
            
            bridge.serveruserpassword = Properties.Settings.Default.password;
            
        }
        private async static void formstart()
        {
            Task<int> frmst = new Task<int>(logs);
            frmst.Start();
        }

        private static int logs ()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
            return 0;
        }
        private static void errorformstart()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging();
            services.AddOptions();
            //			services.Configure<FBoxClientParameters>(_configuration.GetSection("FBox"));
            services.AddTransient<FBoxDemo>();
        }
        public static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            //	Console.WriteLine($"Unobserved task exception: {e.Exception}");
            e.SetObserved();
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //Creating a function that uses the API function...
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
    }
}
