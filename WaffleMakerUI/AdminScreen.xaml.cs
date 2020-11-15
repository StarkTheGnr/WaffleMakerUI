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
	/// Interaction logic for AdminScreen.xaml
	/// </summary>
	public partial class AdminScreen : Window
	{
		public AdminScreen()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ResetToWelcomeScreen();
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
	}
}
