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
using System.Windows.Shapes;
using TeaShopHuilanManagerWPF.Views.Pages;

namespace TeaShopHuilanManagerWPF.Views.Windows
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Page _value;
        public Page Value { get => _value; set { _value = value;} }
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SetPage(new LoginPage());
        }

        public void SetPage(Page value)
        { 
            Value = value;
            Signal();
        }

        private void Signal(string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
