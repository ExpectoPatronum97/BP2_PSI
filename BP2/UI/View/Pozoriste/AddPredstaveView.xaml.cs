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

namespace UI.View.Pozoriste
{
	/// <summary>
	/// Interaction logic for AddPredstaveView.xaml
	/// </summary>
	public partial class AddPredstaveView : Window
	{
		public AddPredstaveView()
		{

		}
		public AddPredstaveView(int id_pozorista)
		{
			InitializeComponent();
			DataContext = new AddPredstaveViewModel(id_pozorista);
		}
	}
}
