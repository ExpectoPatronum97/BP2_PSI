using System;
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
using UI.ViewModel;

namespace UI.View.Sala
{
	/// <summary>
	/// Interaction logic for AddPredstavaToSalaView.xaml
	/// </summary>
	public partial class AddPredstavaToSalaView : Window
	{
		public AddPredstavaToSalaView()
		{

		}
		public AddPredstavaToSalaView(int id_sale, int id_pozorista)
		{
			InitializeComponent();
			DataContext = new AddPredstavaToSalaViewModel(id_sale, id_pozorista);
		}
	}
}
