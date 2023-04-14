using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3GUI
{
    /*
    * The purpose of this application is to validate user entry fields on the application.
    * The application will validate product code, name, version, release date.
    * Created on Apr 7, 2023
    * Author: Peter Thiel
    */
    /// <summary>
    /// a repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// checks if text box has text in it
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsPresent(TextBox textBox) 
        {
            bool isValid = true;

            if (textBox.Text == "")  // bad
            {
                MessageBox.Show(textBox.Tag + " is required");
                isValid = false;
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// checks if combobox has value selected
        /// </summary>
        /// <param name="comboBox">combo box to check (Tag property is set)</param>
        /// <returns>returns true if valid and false if not</returns>
        public static bool IsSelected(ComboBox comboBox)
        {
            bool isValid = true;

            if (comboBox.SelectedIndex == -1)  // bad
            {
                MessageBox.Show(comboBox.Tag + " must be selected");
                isValid = false;
                comboBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        ///  checks if text box contains a non-negative int value
        /// </summary>
        /// <param name="textBox">Text box to check (Tag property is set)</param>
        /// <returns>true if value false if not</returns>
        public static bool IsNonNegativeInt(TextBox textBox)
        {
            bool isValid = true;
            int result;

            if (!Int32.TryParse(textBox.Text, out result)) // not an int
            {
                MessageBox.Show(textBox.Tag + " has to be a whole number.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus(); 
            }
            else if (result < 0)  // it is an int but negative
            {
                MessageBox.Show(textBox.Tag + " has to be a positive or zero.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains an int value within range
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <param name="minValue">minimum value for the range</param>
        /// <param name="maxValue">maximum value for the range</param>
        /// <returns>returns true if valid false if not</returns>
        public static bool IsIntInRange(TextBox textBox, int minValue, int maxValue)
        {
            bool isValid = true;
            int result;

            if (!Int32.TryParse(textBox.Text, out result)) // not a int
            {
                MessageBox.Show(textBox.Tag + " has to be a number.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            else if (result < minValue || result > maxValue) // it is a int but outside the range
            {
                MessageBox.Show(textBox.Tag + " has to be a between " + minValue + " and " + maxValue);
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        ///  checks if text box contains a non-negative double value
        /// </summary>
        /// <param name="textBox">Text box to check (Tag property is set)</param>
        /// <returns>true if value false if not</returns>
        public static bool IsNonNegativeDouble(TextBox textBox)
        {
            bool isValid = true;
            double result;

            if (!Double.TryParse(textBox.Text, out result)) // not a double
            {
                MessageBox.Show(textBox.Tag + " has to be a number.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            else if (result < 0) // it is a double but negative 
            {
                MessageBox.Show(textBox.Tag + " has to be a positive or zero.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        ///  checks if text box contains a non-negative decimal value
        /// </summary>
        /// <param name="textBox">Text box to check (Tag property is set)</param>
        /// <returns>true if value false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            bool isValid = true;
            decimal result;

            if (!Decimal.TryParse(textBox.Text, out result)) // not a decimal
            {
                MessageBox.Show(textBox.Tag + " has to be a number.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            else if (result < 0) // it is a decimal but negative 
            {
                MessageBox.Show(textBox.Tag + " has to be a positive or zero.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            return isValid;
        }
        /// <summary>
        /// checks if text box contains a decimal value within range
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <param name="minValue">minimum value for the range</param>
        /// <param name="maxValue">maximum value for the range</param>
        /// <returns>returns true if valid false if not</returns>
        public static bool IsDecimalInRange(TextBox textBox, decimal minValue, decimal maxValue)
        {
            bool isValid = true;
            decimal result;

            if (!Decimal.TryParse(textBox.Text, out result)) // not a decimal
            {
                MessageBox.Show(textBox.Tag + " has to be a number.");
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            else if (result < minValue || result > maxValue) // it is a decimal but outside the range
            {
                MessageBox.Show(textBox.Tag + " has to be a between " + minValue + " and " + maxValue);
                textBox.SelectAll(); // select all text in the box for replacement 
                isValid = false;
                textBox.Focus();
            }
            return isValid;
        }

        public static bool IsDateInRange(DateTimePicker date, DateTime minDateTime, DateTime maxDateTime)
        {
            bool isValid = true;
            DateTime result = date.Value;
            if (result < minDateTime || result > maxDateTime)
            {
                MessageBox.Show(date.Tag + " has to be between " + minDateTime.ToString("d") + " and " + maxDateTime.ToString("d"));
                isValid = false;
                date.Focus();
            }

            return isValid;
        }
    }
}
