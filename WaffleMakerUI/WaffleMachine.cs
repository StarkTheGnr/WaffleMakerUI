using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaffleMakerUI
{
	class WaffleMachine
	{
		public static WaffleMachine wm_instance;

		private int waffles = 0;
		private int chocolateWaffles = 0;

		private WaffleMachine() { }

		public static WaffleMachine Get_Instance()
		{
			if(wm_instance != null)
			{
				lock (wm_instance)
				{
					wm_instance ??= new WaffleMachine();
				}
			}

			return wm_instance;
		}
	}
}
