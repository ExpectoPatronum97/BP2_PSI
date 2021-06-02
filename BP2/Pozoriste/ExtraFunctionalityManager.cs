using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
	public class ExtraFunctionalityManager
	{
		#region Singleton
		private ExtraFunctionalityManager() { }
		private static ExtraFunctionalityManager instance = null;
		public static ExtraFunctionalityManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ExtraFunctionalityManager();
				}
				return instance;
			}
		}
		#endregion

		public string FnMostViewedCity()
		{
			using (var dataBase = new PozoristeDbContainer())
			{
				var retval = new SqlParameter 
				{ 
					ParameterName = "@retval", 
					Direction = System.Data.ParameterDirection.Output, 
					SqlDbType = System.Data.SqlDbType.NVarChar,
					Size = -1
				};

				SqlParameter[] parameters = { retval };
				dataBase.Database.ExecuteSqlCommand("exec @retval = MostViewedCity", parameters);

				return retval.Value.ToString();
			}
		}

		public int FnTotalNumberOfViewers(string ime, string prezime)
		{
			using (var dataBase = new PozoristeDbContainer())
			{
				var retval = new SqlParameter
				{
					ParameterName = "@retval",
					Direction = System.Data.ParameterDirection.Output,
					SqlDbType = System.Data.SqlDbType.Int,
				};

				SqlParameter[] parameters = 
				{ 
					new SqlParameter { ParameterName = "@ime", Value = ime, SqlDbType = System.Data.SqlDbType.NVarChar, Size = -1 },
					new SqlParameter { ParameterName = "@prezime", Value = prezime, SqlDbType = System.Data.SqlDbType.NVarChar, Size = -1 },
					retval
				};
				dataBase.Database.ExecuteSqlCommand("exec @retval = TotalNumberOfViewers @ime, @prezime", parameters);

				return (int)retval.Value;
			}
		}

		public List<ViewersPodaci> ProcShowAllFromMesto(string mesto)
		{
			using (var dataBase = new PozoristeDbContainer())
			{
				return dataBase.Database.SqlQuery<ViewersPodaci>("exec [ShowAllFromMesto] @mesto", new SqlParameter { ParameterName = "@mesto", Value = mesto, SqlDbType=System.Data.SqlDbType.NVarChar, Size = -1 }).ToList();
			}
		}

		public List<ViewersPodaciJMBG> ProcShowViewers(string ime_glumca, string prezime_glumca)
		{
			using (var dataBase = new PozoristeDbContainer())
			{
				SqlParameter[] parameters =
				{
					new SqlParameter { ParameterName = "@ime", Value = ime_glumca },
					new SqlParameter { ParameterName = "@prezime", Value = prezime_glumca}
				};
				return dataBase.Database.SqlQuery<ViewersPodaciJMBG>("exec [ShowViewers] @ime, @prezime", parameters).ToList();
			}
		}
	}

}
