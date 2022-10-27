using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hash_Bruteforce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public static string ToSHA256(string s)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static string ToSHA512(string s)
        {
            var sha256 = SHA512.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static string ToMd5(string s)
        {
            var sha256 = MD5.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (radioButton5.Checked)
                {
                    textBox2.Text = ToMd5(textBox1.Text);

                }
                if (radioButton6.Checked)
                {
                    textBox2.Text = ToSHA256(textBox1.Text);

                }


                if (radioButton7.Checked)
                {
                    textBox2.Text = ToSHA512(textBox1.Text);

                }
                
            }
            if (radioButton2.Checked)
            {
                if (radioButton5.Checked)
                {
                    textBox2.Text = rockyoumd5(textBox1.Text);

                }
                if (radioButton6.Checked)
                {
                    textBox2.Text = rockyou(textBox1.Text);

                }


                if (radioButton7.Checked)
                {
                    textBox2.Text = rockyou512(textBox1.Text);

                }




            }
            if (radioButton1.Checked)
            {
                if (radioButton5.Checked)
                {
                    textBox2.Text = BruteforceMd5(textBox1.Text);
                    

                }
                if (radioButton6.Checked)
                {
                    textBox2.Text = Bruteforcesha512(textBox1.Text);


                }


                if (radioButton7.Checked)
                {
                    textBox2.Text = rockyou512(textBox1.Text);

                }



            }
            if (radioButton4.Checked)
            {
                textBox2.Text = rockyou2md5(textBox1.Text);



            }
            if (radioButton8.Checked)
            {
                textBox2.Text = password();
            }

        }
        public string rockyou512(string t1)
        {


            bool pwd = true;

            StreamReader sr = new StreamReader(@"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt");

            string FileToRead = @"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead))
            {
                string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null && pwd)
                {
                    string H = ToSHA512(Line);
                    if (H == t1)
                    {

                        pwd = false;
                        return Line;

                    }



                }
                if (pwd)
                {

                    return "No Password found";
                }
                else
                {

                    return "error";
                }


            }
        }
        public string rockyoumd5(string t1)
        {


            bool pwd = true;

            StreamReader sr = new StreamReader(@"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt");

            string FileToRead = @"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead))
            {
                string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null && pwd)
                {
                    string H = ToMd5(Line);
                    if (H == t1)
                    {

                        pwd = false;
                        return Line;

                    }



                }
                if (pwd)
                {

                    return "No Password found";
                }
                else
                {

                    return "error";
                }


            }
        }

        public string rockyou(string t1)
        {
            

            bool pwd = true;
            
            StreamReader sr = new StreamReader(@"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt");

            string FileToRead = @"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead))
            {
                string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null&& pwd)
                {
                    string H = ToSHA256(Line);
                    if (H == t1)
                    {
                        
                        pwd = false;
                        return Line;

                    }



                }
                if (pwd)
                {
                    
                    return "No Password found";
                }
                else
                {
                    
                    return "error";
                }
                

            }
        }
        public string rockyou2md5(string t1)
        {
            string h1 = "";
            string h2= "";
            List<char> letters = new List<char>();
            foreach (char i in t1)
            {
                letters.Add(i);
            }
            int kk = letters.Count/2;
            for (int o = 0; o<kk; kk++)
            {
                h1 += letters[o];

            }
            for (int p = kk; p < letters.Count; p++)
            {
                h2 += letters[p];

            }
            string p2= "";
            string p1 = "";
            bool pwd = true;
            bool pwd2 = true;
            string a = t1.Substring(8);
            TextBox textbox1 = new TextBox();
            StreamReader sr = new StreamReader(@"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt");

            string FileToRead = @"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead))
            using (StreamReader ReaderObject2 = new StreamReader(FileToRead))
            {
                string Line;
                string Line2;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null && pwd)
                {
                    string H = ToMd5(Line);
                    if (H == h1)
                    {

                        pwd = false;
                        p1 = Line;
                        

                    }



                }
                while ((Line = ReaderObject.ReadLine()) != null && pwd)
                {
                    string H = ToMd5(Line);
                    if (H == h2)
                    {

                        pwd2 = false;
                        p2 = Line;
                        


                    }



                }
                if (pwd&&pwd2)
                {

                    return "No Password found";
                }

                else
                {
                    p1 = p1 + p2;
                    return p1;

                   
                }
                


            }

        }
        public string rockyou2(string t1)
        {
            bool pwd = true;
            TextBox textbox1 = new TextBox();
            StreamReader sr = new StreamReader(@"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt");

            string FileToRead = @"C:\Users\LeonS\OneDrive\Programieren\C#\Übungen\Hash-Bruteforce\Hash-Bruteforce\Properties\rockyou.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead))
            using (StreamReader ReaderObject2 = new StreamReader(FileToRead))
            {
                string Line;
                string Line2;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null && pwd)
                {
                    while ((Line2 = ReaderObject2.ReadLine()) != null && pwd)
                    {
                        string k = ToSHA256(Line+Line2);
                        Console.WriteLine(Line+Line2);
                        if (k == t1)
                        {
                            
                          
                            pwd = false;
                            return Line+Line2;

                        }





                    }




                }
                if (pwd)
                {

                    return "No Password found";
                }
                else
                {

                    return "error";
                }


            }

        }
        public string Bruteforce(string t1)
        {
            string[] a = new string[67];
            a[0] = ".";
            a[1] = "a";
            a[2] = "b";
            a[3] = "c";
            a[4] = "d";

            a[5] = "e";
            a[6] = "f";
            a[7] = "g";

            a[8] = "h";
            a[9] = "i";
            a[10] = "j";
            a[11] = "k";


            a[12] = "l";
            a[13] = "m";
            a[14] = "n";
            a[15] = "o";
            a[16] = "p";

            a[17] = "q";
            a[18] = "r";
            a[19] = "s";
            a[20] = "t";
            a[21] = "u";
            a[22] = "v";
            a[23] = "w";
            a[24] = "x";
            a[25] = "y";

            a[26] = "z";
            a[27] = "A";

            a[28] = "B"; 
            a[29] = "C"; 
            a[30] = "D"; 
            a[31] = "E"; 
            a[32] = "F";
            a[33] = "G";
            a[34] = "H";
            a[35] = "I";
            a[36] = "J";
            a[37] = "K";

            a[38] = "L";
            a[39] = "M";
            a[40] = "N";
            a[41] = "O";
            a[42] = "P";
            a[43] = "Q";
            a[44] = "R";
            a[45] = "S";
            a[46] = "T";
            a[47] = "U";

            a[48] = "V";
            a[49] = "W";
            a[50] = "X";
            a[51] = "Y";
            a[51] = "Z";
            a[52] = "1";
            a[53] = "2";
            a[54] = "3";
            a[55] = "4";
            a[56] = "5";

            a[57] = "6";
            a[58] = "7";
            a[59] = "8";
            a[60] = "9";
            a[61] = "0";
            a[62] = "_";
            a[63] = "?";
            a[64] = "!";
            a[65] = "#";
            a[66] = ",";
            
            bool pwd = true;

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int p4 = 0;
            int p5 = 0;

            int p6 = 0;
            int p7 = 0;
            int p8 = 0;
            int p9 = 0;
            for (int i = 3; i <9;i++)
            {
                string PWD= "";
                foreach (string l1 in a)
                {
                    foreach (string l2 in a)
                    {
                        foreach (string l3 in a)
                        {
                            foreach (string l4 in a)
                            {
                                foreach (string l5 in a)
                                {
                                    foreach (string l6 in a)
                                    {
                                        foreach (string l7 in a)
                                        {
                                            foreach (string l8 in a)
                                            {
                                                foreach (string l9 in a)
                                                {
                                                    if (i == 3)
                                                    {
                                                        PWD = l9 + l8 + l7;
                                                       
                                                    }
                                                    if (i == 4)
                                                    {
                                                        PWD = l9 + l8 + l7+ l6;


                                                    }
                                                    if (i == 5)
                                                    {
                                                        PWD = l9 + l8 + l7+l6+l5;


                                                    }
                                                    if (i == 6)
                                                    {
                                                        PWD = l9 + l8 + l7+l6+l5+l4;


                                                    }
                                                    if (i == 7)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4+l3;
                                                       


                                                    }
                                                    if (i == 8)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4+l3+l2;


                                                    }
                                                    if (i == 9)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3 + l2+ l1;



                                                    }
                                                    string PWDhash = ToSHA256(PWD);
                                                    if (t1 == PWDhash)
                                                    {
                                                        pwd = false;
                                                        return PWD;
                                                    }

                                                    


                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }
                        

                    }
                    

                }
                




            }






            if (pwd)
            {
                return "No Password found!";
            }

            return "error";





        }
        public string password()
        {
            string[] a = new string[67];
            a[0] = ".";
            a[1] = "a";
            a[2] = "b";
            a[3] = "c";
            a[4] = "d";

            a[5] = "e";
            a[6] = "f";
            a[7] = "g";

            a[8] = "h";
            a[9] = "i";
            a[10] = "j";
            a[11] = "k";


            a[12] = "l";
            a[13] = "m";
            a[14] = "n";
            a[15] = "o";
            a[16] = "p";

            a[17] = "q";
            a[18] = "r";
            a[19] = "s";
            a[20] = "t";
            a[21] = "u";
            a[22] = "v";
            a[23] = "w";
            a[24] = "x";
            a[25] = "y";

            a[26] = "z";
            a[27] = "A";

            a[28] = "B";
            a[29] = "C";
            a[30] = "D";
            a[31] = "E";
            a[32] = "F";
            a[33] = "G";
            a[34] = "H";
            a[35] = "I";
            a[36] = "J";
            a[37] = "K";

            a[38] = "L";
            a[39] = "M";
            a[40] = "N";
            a[41] = "O";
            a[42] = "P";
            a[43] = "Q";
            a[44] = "R";
            a[45] = "S";
            a[46] = "T";
            a[47] = "U";

            a[48] = "V";
            a[49] = "W";
            a[50] = "X";
            a[51] = "Y";
            a[51] = "Z";
            a[52] = "1";
            a[53] = "2";
            a[54] = "3";
            a[55] = "4";
            a[56] = "5";

            a[57] = "6";
            a[58] = "7";
            a[59] = "8";
            a[60] = "9";
            a[61] = "0";
            a[62] = "_";
            a[63] = "?";
            a[64] = "!";
            a[65] = "#";
            a[66] = ",";
            var andom = new Random();
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i <16; i++)
            {
                int ranNum = andom.Next(0, a.Length);
                sb.Append(a[ranNum]);

            }
            

            return sb.ToString(); 
        }
        public string BruteforceMd5(string t1)
        {
            string[] a = new string[67];
            a[0] = ".";
            a[1] = "a";
            a[2] = "b";
            a[3] = "c";
            a[4] = "d";

            a[5] = "e";
            a[6] = "f";
            a[7] = "g";

            a[8] = "h";
            a[9] = "i";
            a[10] = "j";
            a[11] = "k";


            a[12] = "l";
            a[13] = "m";
            a[14] = "n";
            a[15] = "o";
            a[16] = "p";

            a[17] = "q";
            a[18] = "r";
            a[19] = "s";
            a[20] = "t";
            a[21] = "u";
            a[22] = "v";
            a[23] = "w";
            a[24] = "x";
            a[25] = "y";

            a[26] = "z";
            a[27] = "A";

            a[28] = "B";
            a[29] = "C";
            a[30] = "D";
            a[31] = "E";
            a[32] = "F";
            a[33] = "G";
            a[34] = "H";
            a[35] = "I";
            a[36] = "J";
            a[37] = "K";

            a[38] = "L";
            a[39] = "M";
            a[40] = "N";
            a[41] = "O";
            a[42] = "P";
            a[43] = "Q";
            a[44] = "R";
            a[45] = "S";
            a[46] = "T";
            a[47] = "U";

            a[48] = "V";
            a[49] = "W";
            a[50] = "X";
            a[51] = "Y";
            a[51] = "Z";
            a[52] = "1";
            a[53] = "2";
            a[54] = "3";
            a[55] = "4";
            a[56] = "5";

            a[57] = "6";
            a[58] = "7";
            a[59] = "8";
            a[60] = "9";
            a[61] = "0";
            a[62] = "_";
            a[63] = "?";
            a[64] = "!";
            a[65] = "#";
            a[66] = ",";

            bool pwd = true;

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int p4 = 0;
            int p5 = 0;

            int p6 = 0;
            int p7 = 0;
            int p8 = 0;
            int p9 = 0;
            for (int i = 3; i < 9; i++)
            {
                string PWD = "";
                foreach (string l1 in a)
                {
                    foreach (string l2 in a)
                    {
                        foreach (string l3 in a)
                        {
                            foreach (string l4 in a)
                            {
                                foreach (string l5 in a)
                                {
                                    foreach (string l6 in a)
                                    {
                                        foreach (string l7 in a)
                                        {
                                            foreach (string l8 in a)
                                            {
                                                foreach (string l9 in a)
                                                {
                                                    if (i == 3)
                                                    {
                                                        PWD = l9 + l8 + l7;

                                                    }
                                                    if (i == 4)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6;


                                                    }
                                                    if (i == 5)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5;


                                                    }
                                                    if (i == 6)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4;


                                                    }
                                                    if (i == 7)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3;



                                                    }
                                                    if (i == 8)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3 + l2;


                                                    }
                                                    if (i == 9)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3 + l2 + l1;



                                                    }
                                                    string PWDhash = ToMd5(PWD);
                                                    if (t1 == PWDhash)
                                                    {
                                                        pwd = false;
                                                        return PWD;
                                                    }




                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }


                    }


                }





            }






            if (pwd)
            {
                return "No Password found!";
            }

            return "error";




        }
        public string Bruteforcesha512(string t1)
        {
            string[] a = new string[67];
            a[0] = ".";
            a[1] = "a";
            a[2] = "b";
            a[3] = "c";
            a[4] = "d";

            a[5] = "e";
            a[6] = "f";
            a[7] = "g";

            a[8] = "h";
            a[9] = "i";
            a[10] = "j";
            a[11] = "k";


            a[12] = "l";
            a[13] = "m";
            a[14] = "n";
            a[15] = "o";
            a[16] = "p";

            a[17] = "q";
            a[18] = "r";
            a[19] = "s";
            a[20] = "t";
            a[21] = "u";
            a[22] = "v";
            a[23] = "w";
            a[24] = "x";
            a[25] = "y";

            a[26] = "z";
            a[27] = "A";

            a[28] = "B";
            a[29] = "C";
            a[30] = "D";
            a[31] = "E";
            a[32] = "F";
            a[33] = "G";
            a[34] = "H";
            a[35] = "I";
            a[36] = "J";
            a[37] = "K";

            a[38] = "L";
            a[39] = "M";
            a[40] = "N";
            a[41] = "O";
            a[42] = "P";
            a[43] = "Q";
            a[44] = "R";
            a[45] = "S";
            a[46] = "T";
            a[47] = "U";

            a[48] = "V";
            a[49] = "W";
            a[50] = "X";
            a[51] = "Y";
            a[51] = "Z";
            a[52] = "1";
            a[53] = "2";
            a[54] = "3";
            a[55] = "4";
            a[56] = "5";

            a[57] = "6";
            a[58] = "7";
            a[59] = "8";
            a[60] = "9";
            a[61] = "0";
            a[62] = "_";
            a[63] = "?";
            a[64] = "!";
            a[65] = "#";
            a[66] = ",";

            bool pwd = true;

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int p4 = 0;
            int p5 = 0;

            int p6 = 0;
            int p7 = 0;
            int p8 = 0;
            int p9 = 0;
            for (int i = 3; i < 9; i++)
            {
                string PWD = "";
                foreach (string l1 in a)
                {
                    foreach (string l2 in a)
                    {
                        foreach (string l3 in a)
                        {
                            foreach (string l4 in a)
                            {
                                foreach (string l5 in a)
                                {
                                    foreach (string l6 in a)
                                    {
                                        foreach (string l7 in a)
                                        {
                                            foreach (string l8 in a)
                                            {
                                                foreach (string l9 in a)
                                                {
                                                    if (i == 3)
                                                    {
                                                        PWD = l9 + l8 + l7;

                                                    }
                                                    if (i == 4)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6;


                                                    }
                                                    if (i == 5)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5;


                                                    }
                                                    if (i == 6)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4;


                                                    }
                                                    if (i == 7)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3;



                                                    }
                                                    if (i == 8)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3 + l2;


                                                    }
                                                    if (i == 9)
                                                    {
                                                        PWD = l9 + l8 + l7 + l6 + l5 + l4 + l3 + l2 + l1;



                                                    }
                                                    string PWDhash = ToSHA512(PWD);
                                                    if (t1 == PWDhash)
                                                    {
                                                        pwd = false;
                                                        return PWD;
                                                    }




                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }


                    }


                }





            }






            if (pwd)
            {
                return "No Password found!";
            }

            return "error";




        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
