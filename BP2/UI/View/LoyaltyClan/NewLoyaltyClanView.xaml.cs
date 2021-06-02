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

namespace UI.View.LoyaltyClan
{
	/// <summary>
	/// Interaction logic for NewLoyaltyClanView.xaml
	/// </summary>
	public partial class NewLoyaltyClanView : Window
	{
		public NewLoyaltyClanView(bool shouldWriteGledalac, DatabaseModel.LoyaltyClan o = null)
		{
			InitializeComponent();
			DataContext = new NewLoyaltyClanViewModel(this, o, shouldWriteGledalac);
		}
	}
}
