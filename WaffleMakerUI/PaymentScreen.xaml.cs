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
		POSHandler posHandler = new POSHandler("COM1");

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

				lblWafflesCount.Content = "Waffles x" + wm.GetWaffles();
				lblWafflesPrice.Content = wafflePrice + " EGP";
			}
			if (chocolatePrice > 0)
			{
				lblChocolateCount.Visibility = Visibility.Visible;
				lblChocolatePrice.Visibility = Visibility.Visible;

				lblChocolateCount.Content = "Chocolate x" + wm.GetChocolateWaffles();
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			RepositionDescriptionLabel();

			int? port = posHandler.TestConnection("COM1");
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
