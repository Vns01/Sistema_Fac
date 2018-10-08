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
        string con = @"Data Source = Fac.db;";
        string ps = string.Empty;
        string us = string.Empty;

        public Login() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new SQLiteConnection(con))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT Nome, Senha FROM User where Nome=@Nome and Senha=@Senha";
                        comm.Parameters.AddWithValue("@Nome", string.Format("{0}", tboxLogin.Text));
                        comm.Parameters.AddWithValue("@Senha", string.Format("{0}",tboxSenha.Password));
                        var reader = comm.ExecuteReader();

                        if (reader.HasRows == false)
                            exibiMsgErro();
                        else
                            LoginMainForm();
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

        private void Button_Click_1(object sender, RoutedEventArgs e) =>  exibiMsgmExit();

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
                this.Close();
        }
    }
}
