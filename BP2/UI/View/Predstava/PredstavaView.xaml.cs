﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.ViewModel;

namespace UI.View.Predstava
{
	/// <summary>
	/// Interaction logic for PredstavaView.xaml
	/// </summary>
	public partial class PredstavaView : UserControl
	{
		public PredstavaView()
		{
			InitializeComponent();
			DataContext = new PredstavaViewModel();
		}
	}
}
