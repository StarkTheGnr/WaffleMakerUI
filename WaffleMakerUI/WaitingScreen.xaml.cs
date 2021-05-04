using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WaffleMakerUI
{
	/// <summary>
	/// Interaction logic for WaitingScreen.xaml
	/// </summary>
	public partial class WaitingScreen : Window
	{
		private const int RETURN_TIMEOUT = 10000;

		private WaffleApiIntegrator integrator = new WaffleApiIntegrator();
		private int orderId = -1;

		public WaitingScreen(int newOrderId)
		{
			orderId = newOrderId;
			InitializeComponent();
		}
		public WaitingScreen()
		{
			InitializeComponent();
		}

		public async Task<bool?> TrackOrderStatus_Server()
		{
			bool? orderDone = false;
			while (orderDone == false)
			{
				await Task.Delay(RETURN_TIMEOUT);
				if (!IsLoaded)
					return false;

				orderDone = await integrator.TrackWaffleOrder(orderId);
			}

			return true;
		}

		public async Task<bool?> TrackOrderStatus()
		{
			bool? orderDone = false;
			while (orderDone == false)
			{
				await Task.Delay(RETURN_TIMEOUT);
				if (!IsLoaded)
					return false;

				orderDone = (WaffleMachine.Get_Instance().pm.State == PhysicalMachine.MachineState.OrderReady);
			}

			return true;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			bool? done = await TrackOrderStatus();
			if(done == true)
			{
				EndScreen es = new EndScreen();
				es.ShowActivated = true;
				es.Show();
				Close();
			}
		}
	}
}
