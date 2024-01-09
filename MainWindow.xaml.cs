using System;
using System.Windows;

namespace myFirstWFP
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        InitializeComboBoxItems();
            RadioButtonLength.IsChecked = true;
          UpdateUIforLength();
        }
        private void InitializeComboBoxItems()
        {

            inputType.Items.Add("Centimeter").ToString();
            inputType.Items.Add("Inches").ToString();
            inputType.Items.Add("Feets").ToString();
            inputType.Items.Add("Yards").ToString();

        }
        private void UpdateUIforLength()
        {
            l2.Content = "Enter Length in Meters:";
            l3.Content = "convert to";
            l1.Content = "Length  \r\nConverter ";
            inputType.Items.Clear();
            InitializeComboBoxItems();
            inputType.SelectedItem = "Centimeters";
        }
        private void UpdateUIforTemperature()
        {
            l2.Content = "Enter Temperature in celsius:";
            l3.Content = "convert to";
            l1.Content = "Temperature  \r\nConverter ";
            inputType.Items.Clear();
            inputType.Items.Add("Fahrenheit").ToString();
            inputType.Items.Add("Kelvin").ToString();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButtonLength.IsChecked == true)
            {
                UpdateUIforLength();
            }
            else
            {
                UpdateUIforTemperature();
            }
        }
        
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            inputValue.Clear();
            tb1.Visibility = Visibility.Collapsed;
            RadioButtonLength.IsChecked = true;
            InitializeComboBoxItems() ;
            UpdateUIforLength();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("btn1");

            double input;
            if (double.TryParse(inputValue.Text, out input))
            {
                double convertedvalue = 0.0;
                string result = "";
                if (RadioButtonLength.IsChecked == true)
                {
                    string? unit = inputType.SelectedItem as string;
                    switch (unit)
                    {
                        case "Centimeter":
                            convertedvalue = input * 100;
                            break;

                        case "Inches":
                            convertedvalue = input * 39.37;
                            break;
                            
                        case "Feets":
                            convertedvalue = input * 3.281;
                            break;

                        case "Yards":
                            convertedvalue = input * 1.094;
                            break;
                        default:
                            MessageBox.Show("Please Select the Length", "Information", MessageBoxButton.OK);
                            return;
                    }
                    result = $"{input} Meters is equal to {convertedvalue:f2} {unit}";
                }
                else
                {
                    string? unit = inputType.SelectedItem as string;
                    switch (unit)
                    {
                        case "Fahrenheit":
                            convertedvalue = (input * 9 / 5) + 32;
                            break;

                        case "Kelvin":
                            convertedvalue = input + 273.15;
                            break;
                        default:
                            MessageBox.Show("Please Select the Temperature", "Information", MessageBoxButton.OK);
                            return;
                    }
                    result = $"{input} celsius is equal to {convertedvalue:f2} {unit}";
                }
                tb1.Text = $"{result}";
                tb1.Visibility = Visibility.Visible ;
            }
            else
            {
                MessageBox.Show("Please Enter the value", "Information", MessageBoxButton.OK);

            }
        }

        
    }
}