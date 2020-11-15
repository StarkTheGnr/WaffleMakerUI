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
		POSHandler posHandler = new POSHandler();

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

		void RepositionDescriptionLabel()
		{
			double marginLeft = lblTotalPriceDesc.Margin.Left + lblTotalPriceDesc.ActualWidth;
			lblDesc2.Margin = new Thickness(marginLeft, lblDesc2.Margin.Top, 0, 0);
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			RepositionDescriptionLabel();

			float totalToPay = WaffleMachine.Get_Instance().CalculateTotal();
			Task<int> transactionTask = posHandler.DoTransaction(totalToPay, "01", false);

			
			int transResult = await transactionTask;
			if(transResult == 0 && posHandler.response != null && posHandler.response.transStatus == PaxPOSECR.POSTransStatus.APPROVED)
			{
				WaitingScreen ws = new WaitingScreen();
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
	}
}
