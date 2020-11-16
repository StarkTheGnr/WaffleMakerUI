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
		public EndScreen()
		{
			InitializeComponent();
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(20) };
			timer.Tick += (sender, args) =>
			{
				timer.Stop();
				ResetToWelcomeScreen();
			};
			timer.Start();
		}
	}
}
