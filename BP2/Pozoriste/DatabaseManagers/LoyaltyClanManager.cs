using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class LoyaltyClanManager
	{
		#region Singleton
		private LoyaltyClanManager() { }
		private static LoyaltyClanManager instance = null;
		public static LoyaltyClanManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LoyaltyClanManager();
				}
				return instance;
			}
		}
		#endregion
		
		// Create
		public bool AddLoyaltyClan(LoyaltyClan s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.LoyaltyClanovi.Add(s);
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
		public LoyaltyClan RetrieveLoyaltyClan(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.LoyaltyClanovi.FirstOrDefault(x => x.ID_Clana == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		
		public bool UpdateLoyaltyClan(LoyaltyClan s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					LoyaltyClan temp = db.LoyaltyClanovi.FirstOrDefault(x => x.ID_Clana == s.ID_Clana);
					if (temp != null)
					{
						temp.Ime = s.Ime;
						temp.Prezime = s.Prezime;
						temp.JMBG = s.JMBG;
						if (temp is VIP)
						{
							((VIP)temp).Popust = ((VIP)s).Popust;
						}
						else if (temp is Senior)
						{
							((Senior)temp).BPO = ((Senior)s).BPO;
						}
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
		public bool DeleteLoyaltyClan(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					LoyaltyClan temp = db.LoyaltyClanovi.SingleOrDefault(x => x.ID_Clana == id);
					if (temp != null)
					{
						db.LoyaltyClanovi.Remove(temp);
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

		public BindingList<LoyaltyClan> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<LoyaltyClan>(db.LoyaltyClanovi.ToList());
				}
				catch
				{
					return null;
				}
			}
		}
	}

}
