using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeaShopHuilanManagerWPF.Models.Integrations;
using TeaShopHuilanManagerWPF.Views.Windows;

namespace TeaShopHuilanManagerWPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, INotifyPropertyChanged
    {
        private MainWindow _mvInst;
        private string _code = "****";

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal(string? prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public string UserCode { get => _code; set { _code = value; Signal(); } }

        public LoginPage(MainWindow inst)
        {
            DataContext = this;
            InitializeComponent();
            _mvInst = inst;
        }

        private async void EnterClick_Handler(object sender, RoutedEventArgs e)
        {
            //if (await DataBaseApiService.Instance.Authorize(UserCode))
            _mvInst.SetPage(new TablesPage());
            //else MessageBox.Show("Unhandled exception!");
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
                return;
            }

            string current = textBox.Text;
            int firstZeroIndex = current.IndexOf('*');

            if (firstZeroIndex == -1)
            {
                e.Handled = true;
                return;
            }

            string newText = current.Substring(0, firstZeroIndex) +
                             e.Text[0] +
                             current.Substring(firstZeroIndex + 1);

            textBox.Text = newText;

            int nextZeroIndex = textBox.Text.IndexOf('*');
            textBox.CaretIndex = nextZeroIndex == -1 ? 4 : nextZeroIndex;

            e.Handled = true;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (e.Key == Key.Back)
            {
                string current = textBox.Text;

                int lastNonZeroIndex = -1;
                for (int i = current.Length - 1; i >= 0; i--)
                {
                    if (current[i] != '*')
                    {
                        lastNonZeroIndex = i;
                        break;
                    }
                }

                if (lastNonZeroIndex != -1)
                {
                    string newText = current.Substring(0, lastNonZeroIndex) +
                                     '*' +
                                     current.Substring(lastNonZeroIndex + 1);

                    textBox.Text = newText;

                    textBox.CaretIndex = lastNonZeroIndex;
                }

                e.Handled = true;
            }
        }
    }
}
