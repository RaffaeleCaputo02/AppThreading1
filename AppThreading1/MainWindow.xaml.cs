using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AppThreading1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Task_Click(object sender, RoutedEventArgs e)
        {
            //DoWork();
            Task.Factory.StartNew(DoWork);

        }

        private void DoWork()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {

                }
            }
            Dispatcher.Invoke(AggiornamentoInterfaccia);
        }

        private void AggiornamentoInterfaccia()
        {
            lbl_risultato.Content = "Finito";
        }

        private void Btn_Conta_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(DoCount);
        }

        private void DoCount()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    Dispatcher.Invoke(()=>AggiornamentoInterfaccia(j));
                    Thread.Sleep(1000);
                }
            }
        }
        private void AggiornamentoInterfaccia(int j)
        {
            lbl_Conta.Content = j.ToString();
        }
    }
}
