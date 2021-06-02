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

namespace UI.View.Scenarista
{
	/// <summary>
	/// Interaction logic for AddScenarioView.xaml
	/// </summary>
	public partial class AddScenarioView : Window
	{
		public AddScenarioView()
		{

		}
		public AddScenarioView(int id_scenariste)
		{
			InitializeComponent();
			DataContext = new AddScenarioViewModel(id_scenariste);
		}
	}
}
