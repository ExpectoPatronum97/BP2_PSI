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
	/// Interaction logic for NewScenaristaView.xaml
	/// </summary>
	public partial class NewScenaristaView : Window
	{
		public NewScenaristaView(DatabaseModel.Scenarista o = null)
		{
			InitializeComponent();
			DataContext = new NewScenaristaViewModel(this, o);
		}
	}
}
