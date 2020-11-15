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
	/// Interaction logic for AdminControlSceen.xaml
	/// </summary>
	public partial class AdminControlScreen : Window
	{
		public AdminControlScreen()
		{
			InitializeComponent();

			WaffleMachine wm = WaffleMachine.Get_Instance();
			txtWafflePrice.Text = String.Format("{0:0.00}", wm.WafflePrice);
			txtChocolatePrice.Text = String.Format("{0:0.00}", wm.ChocolatePrice);
		}

		void ResetToWelcomeScreen()
		{
			WaffleMachine.Get_Instance().Reset();
			WelcomeScreen ws = new WelcomeScreen();
			ws.Show();
			Close();
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			ResetToWelcomeScreen();
		}

		private void btnDiscard_Click(object sender, RoutedEventArgs e)
		{
			ResetToWelcomeScreen();
		}

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			WaffleMachine wm = WaffleMachine.Get_Instance();

			float newWafflePrice, newChocolatePrice;
			if(float.TryParse(txtWafflePrice.Text, out newWafflePrice) && float.TryParse(txtChocolatePrice.Text, out newChocolatePrice))
			{
				wm.WafflePrice = newWafflePrice;
				wm.ChocolatePrice = newChocolatePrice;

				ResetToWelcomeScreen();
			}
			else
			{
				lblError.Visibility = Visibility.Visible;
				txtWafflePrice.Clear();
				txtChocolatePrice.Clear();
			}
		}
	}
}
