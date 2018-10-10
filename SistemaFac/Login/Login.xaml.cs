using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;
using MahApps.Metro.IconPacks;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace SistemaFac
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        string con = @"Data Source = Data\FAC.db;";
        string ps = string.Empty;
        string us = string.Empty;
        Acesso ac;

        public Login()
        {
            InitializeComponent();
            tboxLogin.Focus();

            ac = new Acesso();
            tboxLogin.DataContext = ac.Login;
            tboxLogin.DataContext = ac;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ac.Login.Length > 0) { 
            using (var conn = new SQLiteConnection(con))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT Login, Senha FROM User where Login=@Login and Senha=@Senha";
                        comm.Parameters.AddWithValue("@Login", string.Format("{0}", tboxLogin.Text));
                        comm.Parameters.AddWithValue("@Senha", string.Format("{0}", tboxSenha.Password));
                        var reader = comm.ExecuteReader();

                        if (reader.HasRows == false)
                            exibiMsgErro();
                        else
                            LoginMainForm();
                    }
                }
            }
            }
        }

        private async void exibiMsgErro() => await this.ShowMessageAsync("Erro de Autenticação!", "Usúario ou Senha inválidos"
                                                                          + Environment.NewLine + "Tente novamente.");

        private void LoginMainForm()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => exibiMsgmExit();

        private async void exibiMsgmExit()
        {
            var opcoes = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Sim",
                NegativeButtonText = "Não",
                ColorScheme = MetroDialogOptions.ColorScheme
            };

            var resultado = await this.ShowMessageAsync("", "Deseja encerra a aplicação ?", MessageDialogStyle.AffirmativeAndNegative, opcoes);

            if (resultado == MessageDialogResult.Affirmative)
                App.Current.MainWindow.Close();
        }

    }


    public class Acesso : IDataErrorInfo
    {
        private string _login;

        public string Login
        {
            get
            {
                return this._login;
            }
            set
            {
                _login = value;
            }
        }


        private string _messageError;
        public string MessageError
        {
            get { return this._messageError; }
            set { _messageError = value; }
        }


        public string _senha;

        public string Senha
        {
            get { return this._senha; }

            set { _senha = value; }
        }

        public string this[string columnName]
        {
            get
            {
                _messageError = string.Empty;

                if (columnName.Equals("Login") && _login != null)
                    if (string.IsNullOrWhiteSpace(_login))
                        _messageError = "Campo não pode ser vazio";

                if (columnName.Equals("Senha") && _senha != null)
                    if (string.IsNullOrWhiteSpace(_senha))
                        _messageError = "Campo não pode ser vazio";

                return _messageError;
            }
        }

        public string Error => null;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
