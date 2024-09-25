using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Currency_Converter_realValues
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Root val = new Root();

        public class Root
        {
            public Rate rates { get; set; }
            public long timestamp;
            public string license;

        }

        public class Rate
        {
            public double USD { get; set; }
            public double JPY { get; set; }
            public double EUR { get; set; }
            public double CAD { get; set; }
            public double CZK { get; set; }
            public double UAH { get; set; }
            public double PLN { get; set; }
            public double AED { get; set; }
            public double BTC { get; set; }
            public double CHF { get; set; }
            public double GBP { get; set; }
            public double HKD { get; set; }
            public double KZT { get; set; }

        }

        public MainWindow()
        {
            InitializeComponent();
            ClearControl();
            GetValue();
        }

        private async void GetValue()
        {
            string apiKey = File.ReadAllText("C:\\Users\\artem\\source\\repos\\Currency_Converter_realValues\\Currency_Converter_realValues\\ApiKey.txt");
            string url = $"https://openexchangerates.org/api/latest.json?app_id={apiKey}";
            val = await GetData<Root>(url);
            BindCurrency();
        }


        public static async Task<Root> GetData<T>(string url)
        {
            var myRoot = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString);

                        MessageBox.Show("License: " + ResponseObject.license, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                        return ResponseObject;
                    }
                    return myRoot;
                }
            }
            catch
            {
                return myRoot;
            }
        }

        private void BindCurrency()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            dt.Rows.Add("--SELECT", 0);
            dt.Rows.Add("USD", val.rates.USD);
            dt.Rows.Add("JPY", val.rates.JPY);
            dt.Rows.Add("EUR", val.rates.EUR);
            dt.Rows.Add("CAD", val.rates.CAD);
            dt.Rows.Add("CZK", val.rates.CZK);
            dt.Rows.Add("UAH", val.rates.UAH);
            dt.Rows.Add("PLN", val.rates.PLN);
            dt.Rows.Add("AED", val.rates.AED);
            dt.Rows.Add("BTC", val.rates.BTC);
            dt.Rows.Add("CHF", val.rates.CHF);
            dt.Rows.Add("GBP", val.rates.GBP);
            dt.Rows.Add("HKD", val.rates.HKD);
            dt.Rows.Add("KZT", val.rates.KZT);

            cmbFromCurrency.ItemsSource = dt.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dt.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;

        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double convertedValue;

            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                txtCurrency.Focus();
                return;
            }
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                cmbFromCurrency.Focus();
                return;
            }
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                cmbToCurrency.Focus();
                return;
            }

            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                convertedValue = double.Parse(cmbFromCurrency.Text);

                lblCurrency.Content = cmbToCurrency.Text + " " + convertedValue.ToString("N3");
            }
            else
            {
                convertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text))
                   / double.Parse(cmbFromCurrency.SelectedValue.ToString());

                lblCurrency.Content = cmbToCurrency.Text + " " + convertedValue.ToString("N3");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControl();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string fullText = (sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text);

            Regex regex = new Regex(@"^\d{1,7}([.,]\d{1,2})?$");

            e.Handled = !regex.IsMatch(fullText);
        }

        private void ClearControl()
        {
            lblCurrency.Content = "";
            txtCurrency.Text = string.Empty;
            txtCurrency.Focus();
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
        }
    }
}