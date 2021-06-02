using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands.Glumac;

namespace UI.ViewModel
{
	public class AddUlogeViewModel : BindableBase
	{
		private int ID_Glumca;

		private BindingList<Predstava> dostupnePredstave;
		public BindingList<Predstava> DostupnePredstave
		{
			get { return dostupnePredstave; }
			set { SetProperty(ref dostupnePredstave, value); }
		}

		private BindingList<Predstava> trenutnePredstave;
		public BindingList<Predstava> TrenutnePredstave
		{
			get { return trenutnePredstave; }
			set { SetProperty(ref trenutnePredstave, value); }
		}

		public Predstava SelectedTrenutnaPredstava { get; set; }
		public Predstava SelectedDostupnaPredstava { get; set; }


		public ICommand AddUlogaToGlumacCommand { get; set; }
		public ICommand RemoveUlogaFromGlumacCommand { get; set; }

		public bool CanAddUloga { get => SelectedDostupnaPredstava != null; }
		public bool CanDeleteUloga { get => SelectedTrenutnaPredstava != null; }

		public AddUlogeViewModel(int id_glumca)
		{
			ID_Glumca = id_glumca;
			TrenutnePredstave = GlumacManager.Instance.RetrieveAllUlogeFrom(id_glumca);
			DostupnePredstave = GlumacManager.Instance.RetrieveAllUlogeNOTFrom(id_glumca);

			AddUlogaToGlumacCommand = new AddUlogaToGlumacCommand(this);
			RemoveUlogaFromGlumacCommand = new RemoveUlogaFromGlumacCommand(this);
		}

		internal void AddUloga()
		{
			GlumacManager.Instance.AddUloga(ID_Glumca, SelectedDostupnaPredstava.ID_Predstave);
			TrenutnePredstave.Add(SelectedDostupnaPredstava);
			DostupnePredstave.Remove(SelectedDostupnaPredstava);
			//SelectedDostupnaPredstava = DostupnePredstave.Count > 0 ? DostupnePredstave[0] : null;
			SelectedDostupnaPredstava = null;
		}

		internal void DeleteUloga()
		{
			GlumacManager.Instance.DeleteUloga(ID_Glumca, SelectedTrenutnaPredstava.ID_Predstave);
			DostupnePredstave.Add(SelectedTrenutnaPredstava);
			TrenutnePredstave.Remove(SelectedTrenutnaPredstava);
			//SelectedTrenutnaPredstava = TrenutnePredstave.Count > 0 ? TrenutnePredstave[0] : null;
			SelectedTrenutnaPredstava = null;
		}
	}

}
