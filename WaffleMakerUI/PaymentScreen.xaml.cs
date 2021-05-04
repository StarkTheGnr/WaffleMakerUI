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
using System.IO.Ports;

namespace WaffleMakerUI
{
	/// <summary>
	/// Interaction logic for PaymentScreen.xaml
	/// </summary>
	public partial class PaymentScreen : Window
	{
		//POSHandler posHandler = new POSHandler();
		public ReferenceNumber referenceNumber = new ReferenceNumber();

		public PaymentScreen()
		{
			InitializeComponent();

			LoadReceipt();
		}

		void LoadReceipt()
		{
			WaffleMachine wm = WaffleMachine.Get_Instance();
			float wafflePrice = wm.CalculateWaffleTotal();
			float chocolatePrice = wm.CalculateChocolateTotal();
			float total = wm.CalculateTotal();

			if (wafflePrice > 0)
			{
				lblWafflesCount.Visibility = Visibility.Visible;
				lblWafflesPrice.Visibility = Visibility.Visible;

				lblWafflesCount.Content = "Waffles x" + wm.GetWaffleCount();
				lblWafflesPrice.Content = wafflePrice + " EGP";
			}
			if (chocolatePrice > 0)
			{
				lblChocolateCount.Visibility = Visibility.Visible;
				lblChocolatePrice.Visibility = Visibility.Visible;

				lblChocolateCount.Content = "Chocolate x" + wm.GetChocolateWaffleCount();
				lblChocolatePrice.Content = chocolatePrice + " EGP";
			}

			lblTotalPrice.Content = total + " EGP";
			lblTotalPriceDesc.Content = total + " EGP";
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			RepositionDescriptionLabel();

			//InitiateNewOrder();
		}

		private async void InitiateNewOrder()
		{
			//await Task.Delay(10); //This is to allow time for the UI to be loaded before starting. (Prevents white screen on showing window)

			float totalToPay = WaffleMachine.Get_Instance().CalculateTotal();
			string refNum = referenceNumber.GetLastTransactionRNo(true);

			WaffleMachine wm = WaffleMachine.Get_Instance();

			int result = await wm.pm.SendOrder(refNum, wm.GetWaffleCount(), wm.GetChocolateWaffleCount());

			if (result == 0)
			{
				WaitingScreen ws = new WaitingScreen();
				ws.ShowActivated = true;
				ws.Show();
				Close();
			}
			else
			{
				ErrorScreen es = new ErrorScreen();
				es.ShowActivated = true;
				es.Show();
				Close();
			}	

			#region POS Code
			/*//Task<int> transactionTask = posHandler.DoTransaction(totalToPay, false);
			//int transResult = await transactionTask;
			//testing
			lblDebug.Content += " " + transResult;
			//testing remove True to stop simulating PoS
			if (true || transResult == 0 && posHandler.response != null && posHandler.response.transStatus == PaxPOSECR.POSTransStatus.APPROVED)
			{
				RequestNewOrder(posHandler.referenceNumber.GetLastTransactionRNo(false), totalToPay);
			}
			else
			{
				ErrorScreen es = new ErrorScreen();
				es.ShowActivated = true;
				es.Show();
				Close();
			}*/
			#endregion
		}

		void RepositionDescriptionLabel()
		{
			double marginLeft = lblTotalPriceDesc.Margin.Left + lblTotalPriceDesc.ActualWidth;
			lblDesc2.Margin = new Thickness(marginLeft, lblDesc2.Margin.Top, 0, 0);
		}

		private async void RequestNewOrder(string referenceNum, float amount)
		{
			WaffleApiIntegrator integrator = new WaffleApiIntegrator();
			WaffleMachine wm = WaffleMachine.Get_Instance();

			WaffleApiIntegrator.NewOrderResponse response = await integrator.RequestWaffleOrder(wm.GetWaffleCount(), wm.GetChocolateWaffleCount(), referenceNum, amount);
			if (response.statusCode != System.Net.HttpStatusCode.OK || !response.accepted || response.orderId == -1)
			{
				ErrorScreen es = new ErrorScreen();
				es.ShowActivated = true;
				es.Show();
				Close();
			}
			else
			{
				WaitingScreen ws = new WaitingScreen(response.orderId);
				ws.ShowActivated = true;
				ws.Show();
				Close();
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			//TODO cancel payment on POS
			WelcomeScreen ws = new WelcomeScreen();
			ws.Show();
			Close();
		}

		private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (txtPass.Password == WaffleMachine.password)
				btnConfirm.IsEnabled = true;
			else
				btnConfirm.IsEnabled = false;
		}

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			InitiateNewOrder();
			btnConfirm.IsEnabled = false;
		}
	}
}
