using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Media.Media3D;

namespace Tulolaskin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal[] numbers = new decimal[12]; // määritellään taulukko
        public MainWindow()
        {
            InitializeComponent(); // käynnistetään käyttöliittymä
        }

        //public bool CheckboxChecked(object sender, RoutedEventArgs e)
        //{
        //   CheckBox Sunnuntai = sender as CheckBox;
        //    var isChecked = false;
        //
        //    if (Sunnuntai.IsChecked == true)
        //    {
        //        isChecked = true;
        //        return isChecked;
        //    }
        //   else
        //    {
        //        return isChecked;
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = 0; // alustetaan laskuri
            foreach (TextBox textBox in FindVisualChildren<TextBox>(this))
            {
                decimal number;
                if (decimal.TryParse(textBox.Text, out number)) // yritetään muuntaa teksti numeroksi
                {
                    numbers[i] = number; // tallennetaan numero taulukkoon
                }
                else
                {
                    numbers[i] = 0; // jos muuntaminen epäonnistuu, tallennetaan 0
                }
                i++; // kasvatetaan laskuria
            }
            string tuloste = ""; // alustetaan tyhjä merkkijono
            foreach (var item in numbers)
            {
                Debug.WriteLine(item.ToString()); // tulostetaan debuggausta varten
                tuloste += "[ ";
                tuloste += item.ToString();
                tuloste += " ] ";
            }
            //MessageBox.Show("tulos: \n" + tuloste, "Tulolaskin", MessageBoxButton.OK); // näytetään tulos

            

            //var isChecked = CheckboxChecked.isChecked;
            double paiva = Convert.ToDouble(numbers[0]) * Convert.ToDouble(numbers[5]);
            double ilta = Convert.ToDouble(numbers[1]) * Convert.ToDouble(numbers[6]);
            double yo = Convert.ToDouble(numbers[2]) * Convert.ToDouble(numbers[7]);
            double lauantai = Convert.ToDouble(numbers[3]) * Convert.ToDouble(numbers[8]);

            //if (isChecked == true)
            //{
            //    double summaTunnit = paiva + ilta + yo;
            //}
            //else
            //{
            //   double summaTunnit = (paiva + ilta + yo) * Convert.ToDouble(2);
            //}

            double summaTunnit = paiva + ilta + yo + lauantai;
            double kela = Convert.ToDouble(numbers[10]);
            double muutTuet = Convert.ToDouble(numbers[11]);

            double Tuloraja = Convert.ToDouble(numbers[9]);

            double summa1 = Tuloraja - (summaTunnit + kela + muutTuet);   //summa1 = Tulorajan alle jäävä summa, josta laskemme paljon voi vielä tehdä töitä

            MessageBox.Show("Näin paljon voit vielä tienata: \n" + summa1 + "e", "Tulolaskin", MessageBoxButton.OK); // näytetään tulos

        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            return; // ei tehdä mitään
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i); // haetaan kontrolli
                    if (child is T t) // jos kontrolli on haluttua tyyppiä
                    {
                        yield return t; // palautetaan kontrolli
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child)) // haetaan kontrollin lapsikontrollit
                    {
                        yield return childOfChild; // palautetaan lapsikontrollit
                    }
                }
            }
        }
    }
}