using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class SalaManager
	{
		#region Singleton
		private SalaManager() { }
		private static SalaManager instance = null;
		public static SalaManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SalaManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddSala(Sala s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Sale.Add(s);
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
		public Sala RetrieveSala(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Sale.FirstOrDefault(x => x.ID_Sale == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdateSala(Sala s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Sala temp = db.Sale.SingleOrDefault(x => x.ID_Sale == s.ID_Sale);
					if (temp != null)
					{
						temp.Broj_sedista = s.Broj_sedista;
						temp.ID_Pozorista = s.ID_Pozorista;
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
		public bool DeleteSala(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Sala temp = db.Sale.SingleOrDefault(x => x.ID_Sale == id);
					if (temp != null)
					{
						db.Sale.Remove(temp);
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

		public BindingList<Sala> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Sala>(db.Sale.ToList());
				}
				catch
				{
					return null;
				}
			}
		}

		public bool AddPredstava(int id_sale, int id_pozorista, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Igra o = new Igra
					{
						ID_Sale = id_sale,
						ID_Pozorista = id_pozorista,
						ID_Predstave = id_predstave
					};
					db.IgraN.Add(o);
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

		public bool IsPredstava(int id_sale, int id_pozorista, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.IgraN.Any(x => x.ID_Sale == id_sale && x.ID_Pozorista == id_pozorista &&  x.ID_Predstave == id_predstave);
				}
				catch
				{
					return false;
				}
			}
		}

		public bool DeletePredstava(int id_sale, int id_pozorista, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Igra temp = db.IgraN.SingleOrDefault(x => x.ID_Sale == id_sale 
							&& x.ID_Pozorista == id_pozorista && x.ID_Predstave == id_predstave);
					if (temp != null)
					{
						db.IgraN.Remove(temp);
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
		public BindingList<Predstava> RetrieveAllPredstaveFrom(int id_sale, int id_pozorista)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where db.IgraN.Any(x => x.ID_Sale == id_sale && x.ID_Pozorista == id_pozorista && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}

		public BindingList<Predstava> RetrieveAllPredstaveNOTFrom(int id_sale, int id_pozorista)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where !db.IgraN.Any(x => x.ID_Sale == id_sale && x.ID_Pozorista == id_pozorista && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}
	}
}
