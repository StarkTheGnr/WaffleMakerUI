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
	/// Interaction logic for EndScreen.xaml
	/// </summary>
	public partial class EndScreen : Window
	{
		private static object lockObj = new object();

		public EndScreen()
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
			await Task.Delay(10000);

			if(IsLoaded)
				ResetToWelcomeScreen();
		}
	}
}
