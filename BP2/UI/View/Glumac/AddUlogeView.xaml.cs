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
using UI.ViewModel;

namespace UI.View.Glumac
{
	/// <summary>
	/// Interaction logic for AddUlogeView.xaml
	/// </summary>
	public partial class AddUlogeView : Window
	{
		public AddUlogeView()
		{

		}
		public AddUlogeView(int id_glumca)
		{
			InitializeComponent();
			DataContext = new AddUlogeViewModel(id_glumca);
		}
	}
}
