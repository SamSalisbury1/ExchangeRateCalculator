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
using System.Xml.Linq;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for AuditLogWindow.xaml
    /// </summary>
    public partial class AuditLogWindow : Window
    {
        public AuditLogWindow()
        {
            InitializeComponent();

            List<XElement> conversionList = GetConversionList();
            PopulateExchangesListBox(conversionList);

        }

        private void PopulateExchangesListBox(List<XElement> conversionsToShow)
        {
            ExchangesListBox.Items.Clear();

            foreach (XElement conversion in conversionsToShow)
            {
                string dateTime = conversion.Attribute("DateTime").Value;
                string amount = conversion.Attribute("Amount").Value;
                string currency = conversion.Attribute("Currency").Value;
                string exchangedAmount = conversion.Attribute("ExchangedAmount").Value;

                string exchangeInfo = "Exchanged GDP " + amount + " to " + currency + " " + exchangedAmount + " at " + dateTime;
                ExchangesListBox.Items.Add(exchangeInfo);
            }
        }

        private void FilterAuditLogByDate(object sender, RoutedEventArgs e)
        {
            List<DateTime?> dateTimeFilter = GetFilterRange();
            if (dateTimeFilter.Count == 0)
            {
                WarnUserOfBadSearch();
                return;
            }


            List<XElement> filteredConversions = GetFilteredConversions(dateTimeFilter);
            PopulateExchangesListBox(filteredConversions);
        }

        private List<XElement> GetFilteredConversions(List<DateTime?> dateTimeFilter)
        {
            List<XElement> conversionList = GetConversionList();
            List<XElement> filteredConversions = new List<XElement>();
            foreach (XElement conversion in conversionList)
            {
                string dateOfRequest = conversion.Attribute("DateTime").Value.Split(' ')[0];

                foreach (DateTime? dateTime in dateTimeFilter)
                {
                    string filteredDateTime = dateTime.ToString().Split(' ')[0];

                    if (dateOfRequest == filteredDateTime)
                    {
                        filteredConversions.Add(conversion);
                    }
                }
            }

            return filteredConversions;
        }

        private List<DateTime?> GetFilterRange()
        {
            DateTime? startDate = CalandarFrom.SelectedDate;
            DateTime? endDate = CalandarTo.SelectedDate;

            List<DateTime?> dateRange = new List<DateTime?>();
            for (var date = startDate; date <= endDate; date = date.Value.AddDays(1))
            {
                dateRange.Add(date);
            }

            return dateRange;
        }

        private List<XElement> GetConversionList()
        {
            LogBuilder logBuilder = new LogBuilder();
            XDocument auditLog = logBuilder.GetAuditLog("AuditLog.xml");

            return auditLog.Descendants("Conversion").ToList();
        }

        private void WarnUserOfBadSearch()
        {
            MessageBox.Show("No Conversions Found");
            ExchangesListBox.Items.Clear();
        }
    }
}
