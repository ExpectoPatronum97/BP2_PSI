using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.Karta
{
	public class UpdateKartaCommand : ICommand
	{
		private KartaViewModel viewModel;

		public UpdateKartaCommand(KartaViewModel viewModel)
		{
			this.viewModel = viewModel;
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		public bool CanExecute(object parameter)
		{
			return viewModel.CanUpdateKarta;
		}

		public void Execute(object parameter)
		{
			viewModel.UpdateKarta();
		}
	}
}
