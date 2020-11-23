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

namespace Taxi
{
 
    public partial class MainWindow : Window
    {
       private int passengersCount ;
       private string typeTaxi ;
        public MainWindow()
        {
            InitializeComponent();
            passengersCount = 1;
            numberPassengersTextBlock.Text = passengersCount.ToString();
            orderButton.IsEnabled = false;
       
            ((RadioButton)stackPanel.Children[0]).IsChecked = true;
        }
        private bool IsAllFill()
        {
            return !string.IsNullOrEmpty(firstNameTextBlock.Text) && !string.IsNullOrEmpty(lastNameTextBlock.Text) && !string.IsNullOrEmpty(addressTextBlock.Text);
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            firstNameTextBlock.Clear();
            lastNameTextBlock.Clear();
            addressTextBlock.Clear();
            passengersCount = 1;
            agreeCheckBox.IsChecked = false;
            numberPassengersTextBlock.Text = passengersCount.ToString();
            orderButton.IsEnabled = false;
            ((RadioButton)stackPanel.Children[0]).IsChecked = true;
        }

        private void agreeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            orderButton.IsEnabled = false;
        }

        private void agreeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(IsAllFill())
            orderButton.IsEnabled = true;
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
          string res=$"{firstNameTextBlock.Text} {lastNameTextBlock.Text}\n {addressTextBlock.Text}" +
                $"\n{numberPassengersTextBlock.Text} passenger(s)\n {typeTaxi}";
            MessageBox.Show(res, "Order", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = (RadioButton)sender;
            typeTaxi = button.Content.ToString();
        }

        private void addPassengersReeatButton_Click(object sender, RoutedEventArgs e)
        {

            if (passengersCount == 8)
                passengersCount = 0;
            ++passengersCount;
            numberPassengersTextBlock.Text = passengersCount.ToString();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {         
                orderButton.IsEnabled = (agreeCheckBox.IsChecked == true && IsAllFill() == true);
               
        }
    }
}
