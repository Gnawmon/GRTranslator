using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace GRTranslator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

      
        public void Abd3base32input_KeyPressUp(object sender, KeyEventArgs e)
        {
            
            string output = "";

            try
            {
                 output = System.Text.Encoding.UTF8.GetString(Base32.FromBase32String(abd3base32input.Text));
            }
            catch (Exception c)
            {
                abd3base32output.Text = c.Message;
            }

            abd3base32output.Text = output;
            e.Handled = true;


        }
        public void Pluralhexinput_KeyPressUp(object sender, KeyEventArgs e)
        {

            string output = "";

            try
            {
                output = HexToString(pluralhexinput.Text);
            }
            catch (Exception c)
            {
                pluralhexoutput.Text = c.Message;
            }

            pluralhexoutput.Text = output;
            e.Handled = true;


        }

        public static string HexToString(string hex)
        {
            var sb = new StringBuilder();//to hold our result;
            for (int i = 0; i < hex.Length; i += 2)//chunks of two - I'm just going to let an exception happen if there is an odd-length input, or any other error
            {
                string hexdec = hex.Substring(i, 2);//string of one octet in hex
                int number = int.Parse(hexdec, NumberStyles.HexNumber);//the number the hex represented
                char charToAdd = (char)number;//coerce into a character
                sb.Append(charToAdd);//add it to the string being built
            }
            return sb.ToString();//the string we built up.
        }
    }
}