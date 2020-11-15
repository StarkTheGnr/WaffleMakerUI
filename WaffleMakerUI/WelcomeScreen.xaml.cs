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
	public partial class MainWindow : Window
	{
		WaffleMachine wm = WaffleMachine.Get_Instance();

		public MainWindow()
		{
			InitializeComponent();
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
			lblChocolateNum.Content = wm.GetChocolateWaffles();
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
	}
}
