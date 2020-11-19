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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WaffleMakerUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class WelcomeScreen : Window
	{
		WaffleMachine wm = WaffleMachine.Get_Instance();

		public WelcomeScreen()
		{
			InitializeComponent();

			lblWaffleNum.Content = wm?.GetWaffleCount();
			lblChocolateNum.Content = wm?.GetChocolateWaffleCount();

			lblWafflePrice.Content = wm.WafflePrice + " EGP each";
			lblChocolatePrice.Content = wm.ChocolatePrice + " EGP each";
		}

		private void btnWafflesPlus_Click(object sender, RoutedEventArgs e)
		{
			int waffles = wm.AddWaffle();
			lblWaffleNum.Content = waffles;
		}

		private void btnWafflesMinus_Click(object sender, RoutedEventArgs e)
		{
			int waffles = wm.RemoveWaffle();
			lblWaffleNum.Content = waffles;
			lblChocolateNum.Content = wm.GetChocolateWaffleCount();
		}

		private void btnChocolatePlus_Click(object sender, RoutedEventArgs e)
		{
			int chocoAddOn = wm.AddChocolate();
			lblChocolateNum.Content = chocoAddOn;
		}

		private void btnChocolateMinus_Click(object sender, RoutedEventArgs e)
		{
			int chocoAddOn = wm.RemoveChocolate();
			lblChocolateNum.Content = chocoAddOn;
		}

		private void btnAdmin_Click(object sender, RoutedEventArgs e)
		{
			AdminScreen adminScreen = new AdminScreen();
			adminScreen.Show();
			Close();
		}

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			if (wm.GetWaffleCount() > 0)
			{
				PaymentScreen ps = new PaymentScreen();
				ps.Visibility = Visibility.Visible;
				Close();
			}
		}
	}
}
