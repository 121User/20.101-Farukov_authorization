using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._101_Farukov_authorization
{
	public class Connection
	{
		private static Model.EntitiesAuthorization DBEntities;
		public static Model.EntitiesAuthorization getContex()
		{
			if (DBEntities == null)
			{
				DBEntities = new Model.EntitiesAuthorization();
			}
			return DBEntities;
		}
	}
}
