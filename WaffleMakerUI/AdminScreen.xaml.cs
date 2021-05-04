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

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			//TODO Password Check
			string password = txtPass.Password;
			if(password == WaffleMachine.password)
			{
				AdminControlScreen acs = new AdminControlScreen();
				acs.Show();
				Close();
			}
			else
			{
				txtPass.Clear();
				lblError.Visibility = Visibility.Visible;
				txtPass.Focus();
			}
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (IsLoaded)
			{
				if (e.WidthChanged)
				{
					double diff = e.NewSize.Width - e.PreviousSize.Width;
					lblWarning.Margin = new Thickness(lblWarning.Margin.Left + (diff / 2), lblWarning.Margin.Top, lblWarning.Margin.Right, lblWarning.Margin.Bottom);
					lblPass.Margin = new Thickness(lblPass.Margin.Left + (diff / 2), lblPass.Margin.Top, lblPass.Margin.Right, lblPass.Margin.Bottom);
					txtPass.Margin = new Thickness(txtPass.Margin.Left + (diff / 2), txtPass.Margin.Top, txtPass.Margin.Right, txtPass.Margin.Bottom);
				}
			}
		}
	}
}
