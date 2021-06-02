using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands.Pozoriste;

namespace UI.ViewModel
{
	public class AddPredstaveViewModel : BindableBase
	{
		private int ID_Pozorista;

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


		public ICommand AddPredstavaToPozoristeCommand { get; set; }
		public ICommand RemovePredstavaFromPozoristeCommand { get; set; }

		public bool CanAddPredstava { get => SelectedDostupnaPredstava != null; }
		public bool CanDeletePredstava { get => SelectedTrenutnaPredstava != null; }

		public AddPredstaveViewModel(int id_pozorista)
		{
			ID_Pozorista = id_pozorista;
			TrenutnePredstave = PozoristeManager.Instance.RetrieveAllPredstaveFrom(id_pozorista);
			DostupnePredstave = PozoristeManager.Instance.RetrieveAllPredstaveNOTFrom(id_pozorista);

			AddPredstavaToPozoristeCommand = new AddPredstavaToPozoristeCommand(this);
			RemovePredstavaFromPozoristeCommand = new RemovePredstavaFromPozoristeCommand(this);
		}

		internal void AddPredstava()
		{
			PozoristeManager.Instance.AddOrganizuje(ID_Pozorista, SelectedDostupnaPredstava.ID_Predstave);
			TrenutnePredstave.Add(SelectedDostupnaPredstava);
			DostupnePredstave.Remove(SelectedDostupnaPredstava);
			//SelectedDostupnaPredstava = DostupnePredstave.Count > 0 ? DostupnePredstave[0] : null;
			SelectedDostupnaPredstava = null;
		}

		internal void DeletePredstava()
		{
			PozoristeManager.Instance.DeleteOrganizuje(ID_Pozorista, SelectedTrenutnaPredstava.ID_Predstave);
			DostupnePredstave.Add(SelectedTrenutnaPredstava);
			TrenutnePredstave.Remove(SelectedTrenutnaPredstava);
			//SelectedTrenutnaPredstava = TrenutnePredstave.Count > 0 ? TrenutnePredstave[0] : null;
			SelectedTrenutnaPredstava = null;
		}
	}
}
