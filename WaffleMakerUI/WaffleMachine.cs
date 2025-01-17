﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaffleMakerUI.Properties;

namespace WaffleMakerUI
{
	class WaffleMachine
	{
		private static object lockVar = new object();
		private static WaffleMachine wm_instance;

		private int waffles = 0;
		private int chocolateWaffles = 0;

		public float WafflePrice { get; set; } = 0.00f;
		public float ChocolatePrice { get; set; } = 0.00f;

		private WaffleMachine() 
		{
			LoadPrices();
		}

		private void LoadPrices()
		{
			WafflePrice = Settings.Default.WafflePrice;
			ChocolatePrice = Settings.Default.ChocolatePrice;
		}

		public void SavePrices()
		{
			Settings.Default.WafflePrice = WafflePrice;
			Settings.Default.ChocolatePrice = ChocolatePrice;
			Settings.Default.Save();
		}

		public static WaffleMachine Get_Instance()
		{
			if(wm_instance == null)
			{
				lock (lockVar)
				{
					wm_instance ??= new WaffleMachine();
				}
			}

			return wm_instance;
		}

		public int GetWaffleCount()
		{
			return waffles;
		}
		public int GetChocolateWaffleCount()
		{
			return chocolateWaffles;
		}
		public int AddWaffle()
		{
			return ++waffles;
		}
		public int RemoveWaffle()
		{
			if (waffles > 0)
			{
				if (waffles == chocolateWaffles)
					chocolateWaffles--;
				return --waffles;
			}

			return waffles;
		}
		public int AddChocolate()
		{
			if (chocolateWaffles < waffles)
				return ++chocolateWaffles;

			return chocolateWaffles;
		}
		public int RemoveChocolate()
		{
			if (chocolateWaffles > 0)
				return --chocolateWaffles;

			return chocolateWaffles;
		}

		public void Reset()
		{
			waffles = 0;
			chocolateWaffles = 0;
		}

		public float CalculateWaffleTotal()
		{
			return waffles * WafflePrice;
		}
		public float CalculateChocolateTotal()
		{
			return chocolateWaffles * ChocolatePrice;
		}
		public float CalculateTotal()
		{
			return CalculateWaffleTotal() + CalculateChocolateTotal();
		}
	}
}
