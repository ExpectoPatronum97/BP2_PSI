using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.Pozoriste
{
	public class DeletePozoristeCommand : ICommand
	{
		private PozoristeViewModel viewModel;

		public DeletePozoristeCommand(PozoristeViewModel viewModel)
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
			return viewModel.CanDeletePozoriste;
		}

		public void Execute(object parameter)
		{
			viewModel.DeletePozoriste();
		}
	}
}
