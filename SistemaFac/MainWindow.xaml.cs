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

namespace SistemaFac
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
 

            InitializeComponent();
            dpTipoArquivo.ItemsSource = Enum.GetValues(typeof(TipoArquivo)).Cast<TipoArquivo>();


            //Leitor.Ler.Arquivo()
      

            //DataContext = new TesteMVVM();
        }

        private void dpTipoArquivo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selecionado = dpTipoArquivo.SelectedIndex;

            switch (selecionado)
            {
                case 0:
                    ExibiControlesDel();
                    OcultaControlesMult();
                    OcultaControlesFixo();
                    break;
                case 1:
                    ExibiControlesFixo();
                    OcultaControlesDel();
                    OcultaControlesMult();
                    break;
                case 2:
                    ExibiControlesMult();
                    ExibiControlesFixo();
                    OcultaControlesDel();
                    break;
            }

            stkHeaderTrailler.Visibility = Visibility.Visible;
        }

        private void ExibiControlesFixo()
        {
            tblckFixoPos.Visibility = Visibility.Visible;
            tblckFixoTamanho.Visibility = Visibility.Visible;
            tboxFixoPosCep.Visibility = Visibility.Visible;
            tboxFixoTamanho.Visibility = Visibility.Visible;
        }

        private void OcultaControlesFixo()
        {
            tblckFixoPos.Visibility = Visibility.Collapsed;
            tblckFixoTamanho.Visibility = Visibility.Collapsed;
            tboxFixoPosCep.Visibility = Visibility.Collapsed;
            tboxFixoTamanho.Visibility = Visibility.Collapsed;
        }

        private void ExibiControlesMult()
        {
            tblckMultRegMultChave.Visibility = Visibility.Visible;
            tblckMultRegPosChave.Visibility = Visibility.Visible;
            tboxMultRegChave.Visibility = Visibility.Visible;
            tboxMultRegPosChave.Visibility = Visibility.Visible;
        }

        private void OcultaControlesMult()
        {
            tblckMultRegMultChave.Visibility = Visibility.Collapsed;
            tblckMultRegPosChave.Visibility = Visibility.Collapsed;
            tboxMultRegChave.Visibility = Visibility.Collapsed;
            tboxMultRegPosChave.Visibility = Visibility.Collapsed;
        }

        private void OcultaControlesDel()
        {
            tblckDelDelimitador.Visibility = Visibility.Collapsed;
            tblckDelCep.Visibility = Visibility.Collapsed;
            tblckDelInicio.Visibility = Visibility.Collapsed;
            tblckDelTamanho.Visibility = Visibility.Collapsed;
            cboxDelDelimitador.Visibility = Visibility.Collapsed;
            tboxDelCep.Visibility = Visibility.Collapsed;
            tboxDelInicio.Visibility = Visibility.Collapsed;
            tboxDelTamanho.Visibility = Visibility.Collapsed;
        }


        private void ExibiControlesDel()
        {
            tblckDelDelimitador.Visibility = Visibility.Visible;
            tblckDelCep.Visibility = Visibility.Visible;
            tblckDelInicio.Visibility = Visibility.Visible;
            tblckDelTamanho.Visibility = Visibility.Visible;
            cboxDelDelimitador.Visibility = Visibility.Visible;
            tboxDelCep.Visibility = Visibility.Visible;
            tboxDelInicio.Visibility = Visibility.Visible;
            tboxDelTamanho.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http:siteprinter.com.br");
        }

        private void btnText_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Arquivos|*.txt";


            StringBuilder builder = new StringBuilder();

            Nullable<bool> result = dlg.ShowDialog();

            //if (result == true)
            //{
            //    builder = new StringBuilder();
            //    Debug.WriteLine(Leitor.Ler.Arquivo(dlg.FileName, char.Parse(tboxDelDelimitador.Text), int.Parse(tboxDelCep.Text), 
            //        int.Parse(tboxDelInicio.Text), int.Parse(tboxDelTamanho.Text)));

            //}

         
        }

        private void btnGerenciamento_Click(object sender, RoutedEventArgs e)
        {
            var gerenciamento = new Gerenciamento();
            gerenciamento.Show();
        }

        private void cboxExibicaoEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //txBoxProcessEmpresa.Content = cboxExibicaoEmpresa.Items[cboxExibicaoEmpresa.SelectedIndex];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Msgm();
        }

        private async void Msgm()
        {
           var CONTROLLER = await this.ShowMessageAsync("teste", "Processando", MessageDialogStyle.Affirmative, new MetroDialogSettings
           {
               AnimateHide = false
           });

            var controll = await this.ShowProgressAsync("Processando", "Aguarde ...", true);

            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(2000);
                controll.SetProgress(.25);

            }
            await controll.CloseAsync();
        } 
    }
}
