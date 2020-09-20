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
using System.Text.RegularExpressions;
using System.IO;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Currency> currencies = new List<Currency>();
        private LogBuilder logBuilder = new LogBuilder();

        public MainWindow()
        {
            InitializeComponent();
            Parser parser = new Parser();

            if (!parser.InitialiseCurrencies(out currencies))
            {
                CloseWithErrorMessage("There was an error parsing your data");
            }

            PopulateCurrencyComboBox();
        }

        private void PopulateCurrencyComboBox()
        {
            foreach (var currency in currencies)
            {
                currencyComboBox.Items.Add(currency.Name);
            }
        }

        private void HandleConversion(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "";

            if (IsInputValid())
            {
                CalculateConversion();
            }
        }

        private bool IsInputValid()
        {
            if (double.TryParse(poundInputBox.Text, out double pounds))
            {
                pounds = Math.Round(double.Parse(poundInputBox.Text), 2);
                poundInputBox.Text = pounds.ToString();
                return true;
            }

            errorLabel.Content = "Input must be a valid number";
            return false;
        }

        private void CalculateConversion()
        {
            Currency currency = currencies[currencyComboBox.SelectedIndex];
            char symbol = currency.Symbol;
            double pounds = double.Parse(poundInputBox.Text);
            double selectedCurrency = currency.ValueAgainstPound;
            double result = selectedCurrency < 1 ?
               pounds / selectedCurrency :
               pounds * selectedCurrency;
            result = Math.Round(result, 2);

            resultBox.Text = symbol + result.ToString();
            logBuilder.CreateNewLog(pounds, result, currency);
        }

        private void CloseWithErrorMessage(string message)
        {
            MessageBox.Show(message);
            System.Environment.Exit(0);
        }

        private void ViewLogButtonClicked(object sender, RoutedEventArgs e)
        {
            AuditLogWindow auditLogWindow = new AuditLogWindow();
            auditLogWindow.Show();
        }
    }
}
