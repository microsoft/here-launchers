using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullDemo
{
    public class LatLongInput : TextBox
    {
        public bool IsLongitude { get; set; }

        public LatLongInput()
            : base()
        {
            TextChanged += TextChangedEvent;
            this.InputScope = new InputScope()
            {
                Names = { new InputScopeName() { NameValue = InputScopeNameValue.Number } }
            };

            IsLongitude = false;
        }

        void LatLongInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        String ParseDouble(string input)
        {

            if (input.Length > 0)
            {
                String outBut = "";
                bool foundSeparator = false;

                for (int i = 0; i < input.Length; i++)
                {
                    if ((input[i] >= '0' && input[i] <= '9') || ((i == 0) && input[0] == '-'))
                    {
                        outBut = outBut + input[i];
                    }
                    else if (foundSeparator == false)
                    {
                        string Sepa = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                        if (Sepa.Length > 0)
                        {
                            if (Sepa[0] == input[i] || '.' == input[i] || ',' == input[i])
                            {
                                outBut = outBut + Sepa[0];
                                foundSeparator = true;
                            }
                        }
                    }
                }

                return outBut;
            }
            else
            {
                return "";
            }
        }



        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {

            this.Text = ParseDouble(this.Text);
            this.SelectionStart = this.Text.Length;

            int maxAllowed = 90;
            int minAllowed = -90;

            if (IsLongitude)
            {
                maxAllowed = 180;
                minAllowed = -180;
            }
            double d;
            if (double.TryParse(this.Text, out d))
            {
                if (d < minAllowed || d > maxAllowed)
                {
                    this.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    this.Foreground = new SolidColorBrush(Colors.Black);
                }
            }

        }

    }
}