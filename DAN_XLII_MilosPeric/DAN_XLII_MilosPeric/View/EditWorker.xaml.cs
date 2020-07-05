using System;
using DAN_XLII_MilosPeric.ViewModel;
using System.Collections.Generic;
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

namespace DAN_XLII_MilosPeric.View
{
    /// <summary>
    /// Interaction logic for EditWorker.xaml
    /// </summary>
    public partial class EditWorker : Window
    {
        public EditWorker(vwWorker editWorker)
        {
            InitializeComponent();
            this.DataContext = new EditWorkerViewModel(this, editWorker);
        }
    }
}
