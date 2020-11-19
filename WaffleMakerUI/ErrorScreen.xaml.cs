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
using System.Windows.Threading;

namespace WaffleMakerUI
{
	/// <summary>
	/// Interaction logic for ErrorScreen.xaml
	/// </summary>
	public partial class ErrorScreen : Window
	{
		private const int RETURN_TIMEOUT = 20000;

		private static object lockObj = new object();

		public ErrorScreen()
		{
			InitializeComponent();
		}

		void ResetToWelcomeScreen()
		{
			lock (lockObj)
			{
				WaffleMachine.Get_Instance().Reset();
				WelcomeScreen ws = new WelcomeScreen();
				ws.Show();
				Close();
			}
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			ResetToWelcomeScreen();
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await Task.Delay(RETURN_TIMEOUT);

			if (IsLoaded)
				ResetToWelcomeScreen();
		}
	}
}
