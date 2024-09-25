using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Currency_Converter_realValues
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
        }

        private void BindCurrency()
        {
            DataTable dtCurrecny = new DataTable();
            dtCurrecny.Columns.Add("Text");
            dtCurrecny.Columns.Add("Value");
            dtCurrecny.Rows.Add("--SELECT", 0);
            dtCurrecny.Rows.Add("INR", 1);
            dtCurrecny.Rows.Add("USD", 75);
            dtCurrecny.Rows.Add("EUR", 85);
            dtCurrecny.Rows.Add("POUND", 5);
            dtCurrecny.Rows.Add("UAH", 100);
            dtCurrecny.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dtCurrecny.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrecny.DefaultView;
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
                convertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text))
                   / double.Parse(cmbToCurrency.SelectedValue.ToString());

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