using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class PozoristeManager
	{
		#region Singleton
		private PozoristeManager() { }
		private static PozoristeManager instance = null;
		public static PozoristeManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new PozoristeManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddPozoriste(Pozoriste p)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Pozorista.Add(p);
					db.SaveChanges();
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
		}
		// Read
		public Pozoriste RetrievePozoriste(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Pozorista.FirstOrDefault(x => x.ID_Pozorista == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdatePozoriste(Pozoriste p)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Pozoriste temp = db.Pozorista.Find(p.ID_Pozorista);
					if (temp != null)
					{
						temp.Mesto = p.Mesto;
						temp.Naziv = p.Naziv;
						temp.Ulica = p.Ulica;
						db.SaveChanges();
						return true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		// Delete
		public bool DeletePozoriste(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Pozoriste temp = db.Pozorista.Find(id);
					if (temp != null)
					{
						db.Pozorista.Remove(temp);
						db.SaveChanges();
						return true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		public BindingList<Pozoriste> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Pozoriste>(db.Pozorista.ToList());
				}
				catch
				{
					return null;
				}
			}
		}


		public bool AddOrganizuje(int id_pozorista, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Organizuje o = new Organizuje
					{
						ID_Pozorista = id_pozorista,
						ID_Predstave = id_predstave
					};
					db.OrganizujeN.Add(o);
					db.SaveChanges();
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
		}


		public bool IsOrganizuje(int id_pozorista, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.OrganizujeN.Any(x => x.ID_Predstave == id_predstave && x.ID_Pozorista == id_pozorista);
				}
				catch
				{
					return false;
				}
			}
		}

		public bool DeleteOrganizuje(int id_pozorista, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Organizuje temp = db.OrganizujeN.SingleOrDefault(x => x.ID_Predstave == id_predstave && x.ID_Pozorista == id_pozorista);
					if (temp != null)
					{
						db.OrganizujeN.Remove(temp);
						db.SaveChanges();
						return true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		public BindingList<Predstava> RetrieveAllPredstaveFrom(int id_pozorista)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where db.OrganizujeN.Any(x => x.ID_Pozorista == id_pozorista && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}

		public BindingList<Predstava> RetrieveAllPredstaveNOTFrom(int id_pozorista)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where !db.OrganizujeN.Any(x => x.ID_Pozorista == id_pozorista && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}

		public BindingList<Sala> RetrieveAllSaleFrom(int id_pozorista)
		{
			using (var db = new PozoristeDbContainer())
			{

				return new BindingList<Sala>(SalaManager.Instance.RetrieveAll().Where(x => x.ID_Pozorista == id_pozorista).ToList());
			}
		}
	}
}
