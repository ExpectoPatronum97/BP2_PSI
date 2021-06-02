using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class GlumacManager
	{
		#region Singleton
		private GlumacManager() { }
		private static GlumacManager instance = null;
		public static GlumacManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new GlumacManager();
				}
				return instance;
			}
		}
		#endregion

		public bool AddGlumac(Glumac s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Glumci.Add(s);
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
		public Glumac RetrieveGlumac(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Glumci.FirstOrDefault(x => x.ID_Glumca == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		public bool UpdateGlumac(Glumac s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Glumac temp = db.Glumci.FirstOrDefault(x => x.ID_Glumca == s.ID_Glumca);
					if (temp != null)
					{
						temp.Ime = s.Ime;
						temp.Prezime = s.Prezime;
						temp.Ime_lika = s.Ime_lika;
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
		public bool DeleteGlumac(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Glumac temp = db.Glumci.SingleOrDefault(x => x.ID_Glumca == id);
					if (temp != null)
					{
						db.Glumci.Remove(temp);
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

		public BindingList<Glumac> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Glumac>(db.Glumci.ToList());
				}
				catch
				{
					return null;
				}
			}
		}

		public bool AddUloga(int id_glumca, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Glumi o = new Glumi
					{
						ID_Glumca = id_glumca,
						ID_Predstave = id_predstave
					};
					db.GlumioN.Add(o);
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


		public bool IsUloga(int id_glumca, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.GlumioN.Any(x => x.ID_Predstave == id_predstave && x.ID_Glumca == id_glumca);
				}
				catch
				{
					return false;
				}
			}
		}

		public bool DeleteUloga(int id_glumca, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Glumi temp = db.GlumioN.SingleOrDefault(x => x.ID_Predstave == id_predstave && x.ID_Glumca == id_glumca);
					if (temp != null)
					{
						db.GlumioN.Remove(temp);
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

		public int GetUlogaCount(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				var q = db.GlumioN.Where(x => x.ID_Glumca == id);
				return q.Count();
			}
		}
		public BindingList<Predstava> RetrieveAllUlogeFrom(int id_glumca)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where db.GlumioN.Any(x => x.ID_Glumca == id_glumca && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}

		public BindingList<Predstava> RetrieveAllUlogeNOTFrom(int id_glumca)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where !db.GlumioN.Any(x => x.ID_Glumca == id_glumca && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}
	}

}
