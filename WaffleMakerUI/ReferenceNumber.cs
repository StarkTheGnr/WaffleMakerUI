using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.IO;

namespace WaffleMakerUI
{
	class ReferenceNumber
	{
		const long MAX_RNO = 999999999999;

		private string lastRNo = "";

		public ReferenceNumber()
		{
			lastRNo = Properties.Settings.Default.LastRNo;
		}
		public ReferenceNumber(string initRNo)
		{
			lastRNo = initRNo;
		}

		public void IncrementRNo()
		{
			long RNo = long.Parse(lastRNo);
			RNo++;

			if (RNo == MAX_RNO)
				RNo = 0;

			lastRNo = string.Format("{0:000000000000}", RNo);
			Properties.Settings.Default.LastRNo = lastRNo;
			Properties.Settings.Default.Save();
		}

		public string GetLastTransactionRNo(bool incrementRNoAfter)
		{
			string oldRNo = lastRNo;

			if (incrementRNoAfter)
				IncrementRNo();

			return oldRNo;
		}

		public string GetNewRNo(bool logTransaction = true)
		{
			long RNo = long.Parse(lastRNo);
			RNo++;

			if (RNo == MAX_RNO)
				RNo = 0;

			return string.Format("{0:000000000000}", RNo); ;
		}

		public void ResetRNo()
		{
			lastRNo = "000000000000";
		}
	}
}
