using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.Sala
{
	public class EditSalaCommand : ICommand
	{
		private NewSalaViewModel viewModel;

		public EditSalaCommand(NewSalaViewModel viewModel)
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
			return viewModel.CanAddSala;
		}

		public void Execute(object parameter)
		{
			viewModel.EditSala();
		}
	}

}
