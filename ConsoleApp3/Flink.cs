using FBoxClientDriver;
using FBoxClientDriver.Contract;
using FBoxClientDriver.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using ServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
namespace ConsoleApp3
{
    public class FBoxClientParameters
    {
        public static string ClientId { get; set; } = "ebae";
        public static string ClientSecret { get; set; } = "2def71770779de31ba196d9423735368";
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string IdServer { get; set; } = "https://account.flexem.com/core";
        public static string MainServer { get; set; } = "http://fbox360.com";
        public static string HdataServer { get; set; } = "http://fbhs1.fbox360.com";
    }
    public class FBoxDemo : IDisposable
    {
        private readonly IFBoxClientManager _fbox;
        private readonly ILogger<FBoxDemo> _logger;
        public FBoxDemo(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FBoxDemo>();
            ICredentialProvider provider =
            new DefaultCredentialProvider(FBoxClientParameters.ClientId, FBoxClientParameters.ClientSecret, FBoxClientParameters.UserName, FBoxClientParameters.Password);
            _fbox = new FBoxClientManager(FBoxClientParameters.IdServer, FBoxClientParameters.MainServer, FBoxClientParameters.HdataServer, provider, Guid.NewGuid().ToString("N"), loggerFactory);
            _fbox.BoxConnectStateChanged += _fbox_BoxConnectStateChanged;
            _fbox.DataMonitorValueChanged += _fbox_DataMonitorValueChanged;
        }
        int intro = 0;
        private void _fbox_DataMonitorValueChanged(object sender, IList<DataMonitorValueChangedArgs> e)
        {
            switch (intro)
            {
                case 0:
                    foreach (var item in e)
                    {
                        bridge.uid = item.Uid.ToString();
                        bridge.value = item.Value.ToString();
                        bridge.boxno = item.BoxNo.ToString();
                        bridge.status = item.Status.ToString();
                        bridge.boxid = item.BoxId.ToString();
                        bridge.sqlstatus = "SQL server not using";
                    }
                    if (intro == 0) intro++;
                    break;
                default:
                    if (bridge.sqloffline == false)
                    {
                        switch (bridge.databasename)
                        {
                            case "MICROSOFT OFFICE ACCESS":
                                try
                                {
                                    OleDbConnection connection = new OleDbConnection();
                                    OleDbCommand insertCommand = new OleDbCommand();
                                    // TODO: Modify the connection string and include any
                                    // additional required properties for your database.
                                    connection.ConnectionString = @"Provider= Microsoft.ACE.OLEDB.10.0; Data Source=" + bridge.servername + "; Persist Security Info=False;";
                                    connection.Open();
                                    foreach (var item in e)
                                    {
                                        insertCommand.Connection = connection;
                                        insertCommand.CommandText = "insert into tblrehber (deviceID,value, datetime) values (@p1, @p2, @p3)";
                                        insertCommand.Parameters.AddWithValue("@p1", item.Uid);
                                        insertCommand.Parameters.AddWithValue("@p2", item.Value);
                                        insertCommand.Parameters.AddWithValue("@p3", DateTime.Now);
                                        insertCommand.ExecuteNonQuery();
                                    }
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    bridge.sqlstatus = "ACCESS server connect error\nplease check configurations ";
                                }
                                break;
                            case "MYSQL":
                                try
                                {
                                    MySqlConnection connection;
                                    string connectionString;
                                    string[] serverinfo = bridge.servername.Split('/');
                                    connectionString = "Server = " + serverinfo[0] + "; Port = " + serverinfo[1] + "; Database = " + bridge.serverdbname + "; Uid = " +
                                    bridge.serverusername + "; Pwd = " + bridge.serveruserpassword + ";";
                                    //"SERVER=" + bridge.servername + ";" + "DATABASE=" +
                                    //bridge.serverdbname + ";" + "UID=" + bridge.serverusername + ";" + "PASSWORD=" + bridge.serveruserpassword + ";";
                                    connection = new MySqlConnection(connectionString);
                                    connection.Open();
                                    foreach (var item in e)
                                    {
                                        string query = "INSERT INTO " + bridge.servertbname + "(deviceID, value, datetime)VALUES(@0, @1, @2)";
                                        MySqlCommand insertCommand = new MySqlCommand(query, connection);
                                        insertCommand.Parameters.Add("@0", MySqlDbType.Int64).Value = item.Uid;
                                        insertCommand.Parameters.Add("@1", MySqlDbType.VarChar).Value = item.Value;
                                        insertCommand.Parameters.Add("@2", MySqlDbType.VarChar).Value = DateTime.Now;
                                        insertCommand.ExecuteNonQuery();
                                        bridge.uid = item.Uid.ToString();
                                        bridge.value = item.Value.ToString();
                                        bridge.boxno = item.BoxNo.ToString();
                                        bridge.status = item.Status.ToString();
                                        bridge.boxid = item.BoxId.ToString();
                                        bridge.datachanged = true;
                                        while (bridge.datachanged) ;
                                        bridge.sqlstatus = "MYSQL server connected";
                                    }
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    bridge.sqlstatus = "MYSQL server connect error\nplease check configurations ";
                                }
                                break;
                            case "MSSQL":
                                using (SqlConnection conn = new SqlConnection())
                                {
                                    try
                                    {
                                        if (bridge.serverusername != "")
                                        {
                                            conn.ConnectionString = "Data Source=" + bridge.servername + ";" +
                                                "User ID=" + bridge.serverusername + ";" + "Password=" + bridge.serveruserpassword + ";"
                                                 + "Initial Catalog=" + bridge.serverdbname;
                                        }
                                        else
                                        {
                                            conn.ConnectionString = "Server=" + bridge.servername + "; Database=" + bridge.serverdbname + "; Trusted_Connection=true";
                                        }
                                        conn.Open();
                                        foreach (var item in e)
                                        {
                                            SqlCommand insertCommand = new SqlCommand("INSERT INTO " + bridge.servertbname + "(deviceID, value, datetime)VALUES(@0, @1, @2)", conn);
                                            insertCommand.Parameters.Add(new SqlParameter("0", item.Uid));
                                            insertCommand.Parameters.Add(new SqlParameter("1", item.Value));
                                            insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                                            insertCommand.ExecuteNonQuery();
                                            bridge.uid = item.Uid.ToString();
                                            bridge.value = item.Value.ToString();
                                            bridge.boxno = item.BoxNo.ToString();
                                            bridge.status = item.Status.ToString();
                                            bridge.boxid = item.BoxId.ToString();
                                            bridge.datachanged = true;
                                            while (bridge.datachanged) ;
                                            bridge.sqlstatus = "SQL server connected";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        bridge.sqlstatus = "SQL server connect error\nplease check configurations ";
                                    }
                                }
                                break;
                            default: bridge.sqlstatus = "database not chosed"; break;
                        }
                    }
                    else
                    {
                        foreach (var item in e)
                        {
                            bridge.uid = item.Uid.ToString();
                            bridge.value = item.Value.ToString();
                            bridge.boxno = item.BoxNo.ToString();
                            bridge.status = item.Status.ToString();
                            bridge.boxid = item.BoxId.ToString();
                            bridge.sqlstatus = "SQL server not using";
                            bridge.datachanged = true;
                            while (bridge.datachanged) ;
                        }
                    }
                    break;
            }
        }
        public string returntoform(string message)
        {
            return message;
        }
        private void _fbox_BoxConnectStateChanged(object sender, IList<BoxConnectionStateItem> e)
        {
            Task.Run(async () =>
            {
                foreach (var stateItem in e)
                {
                    if (stateItem.NewState == BoxConnectionState.Connected || stateItem.NewState == BoxConnectionState.TimedOut)
                    {
                        try
                        {
                            await _fbox.StartAllDataMonitorPointsOnBox(new BoxArgs(stateItem.BoxNo));
                        }
                        catch (Exception ex)
                        {
                            switch (ex.Message)
                            {
                                case "Box server not found.":
                                    bridge.status = stateItem.NewState.ToString() + ex.Message; break;
                                case "Not Found": bridge.status = stateItem.NewState.ToString() + ex.Message; break;
                                default: bridge.status = stateItem.NewState.ToString() + ex.Message; break;
                            }

                            Program.setuserinfo();
                        }
                    }
                    else
                    {
                        bridge.status = stateItem.NewState.ToString(); break;
                    }
                }
            });
        }
        public async Task Go()
        {
            try
            {
                await _fbox.Restart();
            }
            catch (LoginFailedException)
            {
                MessageBox.Show("please check your username or password", "login faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reconnect();
            }
            catch (Exception)
            { };
            await WriteDmonValueAsync();
        }
        public async Task WriteDmonValueAsync()
        {
            try
            {
                await _fbox.WriteValue(new DataMonitorWriteValueArgsV2()
                {

                    BoxNo = bridge.boxid_bridge,
                    DataMonitorUid = 1,
                    Type = WriteValueType.String,
                    Value = "1"

                });
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Not Found":
                        MessageBox.Show("Not found BOX-ID please set on settings");
                        reconnect();

                        break;

                    case "监控点条目不存在":
                        bridge.Userconnecterror = false;
                        bridge.Connect = false;
                        break;
                    case "监控点不可写入": MessageBox.Show("监控点不可写入"); break;
                    case "FBox会话不存在":
                        MessageBox.Show("FBox会话不存在"); break;
                    case "参数格式不正确": MessageBox.Show("参数格式不正确"); break;
                    default: break;
                }


            }
        }

        private void reconnect()
        {

            bridge.Userconnecterror = true;
            while (bridge.Userconnecterror == true) ;
            Program.setuserinfo();
            TaskScheduler.UnobservedTaskException += Program.TaskScheduler_UnobservedTaskException;
            var spFactory = new DefaultServiceProviderFactory();
            var sc = new ServiceCollection();
            Program.ConfigureServices(sc);
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
                } while (ln != "quit");
            }


        }
        public void Dispose()
        {
            _fbox.BoxConnectStateChanged -= _fbox_BoxConnectStateChanged;
            _fbox.DataMonitorValueChanged -= _fbox_DataMonitorValueChanged;
            _fbox?.Dispose();
        }
    }
}
