using System;
using System.Windows;
using System.Windows.Controls;

namespace NadajPrzesylke
{
    public partial class MainWindow : Window
    {
        private string obrazPocztowki = "https://png.pngtree.com/png-vector/20221005/ourmid/pngtree-vintage-postcard-post-card-stamp-png-image_6259122.png";
        private string obrazListu = "https://www.freepnglogos.com/uploads/letter-png/letter-png-transparent-letter-images-pluspng-17.png";
        private string obrazPaczki = "https://cdn.pixabay.com/photo/2014/11/25/21/04/package-545658_960_720.png";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SprawdzCene_Click(object sender, RoutedEventArgs e)
        {
            if (PocztowkaRadioButton.IsChecked == true)
            {
                WyswietlObrazICene(obrazPocztowki, "Cena: 1 zł");
            }
            else if (ListRadioButton.IsChecked == true)
            {
                WyswietlObrazICene(obrazListu, "Cena: 1,5 zł");
            }
            else if (PaczkaRadioButton.IsChecked == true)
            {
                WyswietlObrazICene(obrazPaczki, "Cena: 10 zł");
            }
            else
            {
                MessageBox.Show("Proszę wybrać typ przesyłki.");
            }
        }

        private void WyswietlObrazICene(string obrazUrl, string cena)
        {
            Obraz.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(obrazUrl));
            CenaLabel.Content = cena;
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string kodPocztowy = KodPocztowyTextBox.Text;

            if (string.IsNullOrEmpty(kodPocztowy))
            {
                MessageBox.Show("Proszę wprowadzić kod pocztowy.");
            }
            else if (kodPocztowy.Length != 5)
            {
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym.");
            }
            else if (!czyWszystkieCyfry(kodPocztowy))
            {
                MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
            }
            else
            {
                MessageBox.Show("Dane przesyłki zostały wprowadzone.");
            }
        }

        private bool czyWszystkieCyfry(string text)
        {
            foreach (char znak in text)
            {
                if (!Char.IsDigit(znak))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
