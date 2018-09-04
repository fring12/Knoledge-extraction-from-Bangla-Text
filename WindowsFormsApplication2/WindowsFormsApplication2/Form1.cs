using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            knowledge(input);
        }
        public void knowledge(string input)
            {
            string[] ua = new string[1];
            string[] ua2 = new string[1];
            int verbPosition = -1 ;
            string[] token = Regex.Split(input, " ");
            int sizeOfArray = token.Length;
            XmlDocument doc = new XmlDocument();
            doc.Load("pronoun.xml");
            XmlNode node = doc.SelectSingleNode("/root");
            string[] printPof = new string[sizeOfArray];
            string[] tokenAttribute = new string[sizeOfArray];
            string[] tokenAtt = new string[sizeOfArray];
            string[] printPof2 = new string[sizeOfArray];
            string[] tokenAttribute2 = new string[sizeOfArray];
            string[] tokenAtt2 = new string[sizeOfArray];
            string[] grammar = new string[1];
            char[] shortPof = new char[sizeOfArray];
            char[] shortPofTemp = new char[sizeOfArray];
            char[] shortPof2 = new char[sizeOfArray];
            char[] shortPofTemp2 = new char[sizeOfArray];
            int numOfVerb = 0;
            int flag = 0;
            int flagg = 0;
            int j = 0;
            int z = 0;
            int NounPhraseCount = 0;
            bool CounjunctionFound = false;

                                                           /**************************************/

            foreach (string word in token)//token array er prottek word loop kora
            {
                flag = 0;
                foreach (XmlNode nodes in node.SelectNodes("pos"))// root er vitore pos from xml
                {
                    flag = 0;
                    foreach (XmlNode nodess in nodes.SelectNodes("pronoun"))//finding pronouns from xml
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Pronoun";
                                tokenAttribute2[z] = nodess.InnerText + "(iof>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt2[z] = nodess.Attributes["category"].Value;
                                grammar[0] += "Pronoun+";//grammar
                                shortPof2[z] = 'p';
                                shortPofTemp2[z] = 'p';
                                z++;
                                flag = 1;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Pronoun";
                                tokenAttribute[j] = nodess.InnerText + "(iof>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt[j] = nodess.Attributes["category"].Value;
                                grammar[0] += "Pronoun+";//grammar
                                shortPof[j] = 'p';
                                shortPofTemp[j] = 'p';
                                j++;
                                flag = 1;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("verb"))
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Verb";
                                tokenAttribute2[z] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt2[z] = nodess.Attributes["category"].Value;
                                if (nodess.Attributes["attribute"].Value == "present")
                                {
                                    tokenAttribute2[z] += ".@entry.@present";
                                }
                                grammar[0] += "Verb+";
                                shortPof2[z] = 'v';
                                shortPofTemp2[z] = 'v';
                                verbPosition = z;
                                z++;
                                flag = 1;
                                numOfVerb++;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Verb";
                                tokenAttribute[j] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt[j] = nodess.Attributes["category"].Value;
                                if (nodess.Attributes["attribute"].Value == "present")
                                {
                                    tokenAttribute[j] += ".@entry.@present";
                                }
                                grammar[0] += "Verb+";
                                shortPof[j] = 'v';
                                shortPofTemp[j] = 'v';
                                verbPosition = j;
                                j++;
                                flag = 1;
                                numOfVerb++;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("adjective"))
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Adjective";
                                tokenAttribute2[z] = nodess.InnerText + "(aoj>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt2[z] = nodess.Attributes["category"].Value;
                                grammar[0] += "Adjective+";
                                shortPof2[z] = 'a';
                                shortPofTemp2[z] = 'a';
                                z++;
                                flag = 1;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Adjective";
                                tokenAttribute[j] = nodess.InnerText + "(aoj>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt[j] = nodess.Attributes["category"].Value;
                                grammar[0] += "Adjective+";
                                shortPof[j] = 'a';
                                shortPofTemp[j] = 'a';
                                j++;
                                flag = 1;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("adverb"))
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Adverb";
                                tokenAttribute2[z] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt2[z] = nodess.Attributes["category"].Value;
                                grammar[0] += "Adverb+";
                                shortPof2[z] = 'd';
                                shortPofTemp2[z] = 'd';
                                z++;
                                flag = 1;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Adverb";
                                tokenAttribute[j] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt[j] = nodess.Attributes["category"].Value;
                                grammar[0] += "Adverb+";
                                shortPof[j] = 'd';
                                shortPofTemp[j] = 'd';
                                j++;
                                flag = 1;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("interjection"))
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Intejection";
                                tokenAttribute2[z] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt2[z] = nodess.Attributes["category"].Value;
                                grammar[0] += "Intejection+";
                                shortPof2[z] = 'c';
                                shortPofTemp2[z] = 'c';
                                z++;
                                flag = 1;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Intejection";
                                tokenAttribute[j] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt[j] = nodess.Attributes["category"].Value;
                                grammar[0] += "Intejection+";
                                shortPof[j] = 'c';
                                shortPofTemp[j] = 'c';
                                j++;
                                flag = 1;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("conjunction"))
                    {
                        if (word == nodess.InnerText)
                        {
                            CounjunctionFound = true;
                            printPof[j] = nodess.InnerText + " : Conjunction";
                            tokenAttribute[j] = nodess.InnerText + "(aoj>" + nodess.Attributes["category"].Value + ")";
                            tokenAtt[j] = nodess.Attributes["category"].Value;
                            grammar[0] += "Conjunction+";
                            shortPof[j] = 'a';
                            shortPofTemp[j] = 'a';
                            j++;
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("condition"))
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Condition";
                                tokenAttribute2[z] = nodess.InnerText + "(aoj>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt2[z] = nodess.Attributes["category"].Value;
                                grammar[0] += "Condition+";
                                shortPof2[z] = 'a';
                                shortPofTemp2[z] = 'a';
                                z++;
                                flag = 1;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Condition";
                                tokenAttribute[j] = nodess.InnerText + "(aoj>" + nodess.Attributes["category"].Value + ")";
                                tokenAtt[j] = nodess.Attributes["category"].Value;
                                grammar[0] += "Condition+";
                                shortPof[j] = 'a';
                                shortPofTemp[j] = 'a';
                                j++;
                                flag = 1;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    foreach (XmlNode nodess in nodes.SelectNodes("noun"))
                    {
                        if (word == nodess.InnerText)
                        {
                            if (CounjunctionFound)
                            {
                                printPof2[z] = nodess.InnerText + " : Noun";
                                if (nodess.Attributes["category"].Value == "মানুষ" || nodess.Attributes["category"].Value == "জায়গা" || nodess.Attributes["category"].Value == "প্রতিষ্ঠান" || nodess.Attributes["category"].Value == "মহাদেশ" || nodess.Attributes["category"].Value == "দেশ" || nodess.Attributes["category"].Value == "শহর" || nodess.Attributes["category"].Value == "নদী" || nodess.Attributes["category"].Value == "মানুষ" || nodess.Attributes["category"].Value == "পাহাড়")
                                {
                                    tokenAttribute2[z] = nodess.InnerText + "(iof>" + nodess.Attributes["category"].Value + ")";
                                    tokenAtt2[z] = nodess.Attributes["category"].Value;
                                }
                                else
                                {

                                    tokenAttribute2[z] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";

                                    tokenAtt2[z] = nodess.Attributes["category"].Value;
                                }



                                grammar[0] += "Noun+";
                                shortPof2[z] = 'n';
                                shortPofTemp2[z] = 'n';
                                z++;
                                flag = 1;
                            }
                            else
                            {
                                printPof[j] = nodess.InnerText + " : Noun";
                                if (nodess.Attributes["category"].Value == "মানুষ" || nodess.Attributes["category"].Value == "জায়গা" || nodess.Attributes["category"].Value == "প্রতিষ্ঠান" || nodess.Attributes["category"].Value == "মহাদেশ" || nodess.Attributes["category"].Value == "দেশ" || nodess.Attributes["category"].Value == "শহর" || nodess.Attributes["category"].Value == "নদী" || nodess.Attributes["category"].Value == "মানুষ" || nodess.Attributes["category"].Value == "পাহাড়")
                                {
                                    tokenAttribute[j] = nodess.InnerText + "(iof>" + nodess.Attributes["category"].Value + ")";
                                    tokenAtt[j] = nodess.Attributes["category"].Value;
                                }
                                else
                                {

                                    tokenAttribute[j] = nodess.InnerText + "(icl>" + nodess.Attributes["category"].Value + ")";

                                    tokenAtt[j] = nodess.Attributes["category"].Value;
                                }



                                grammar[0] += "Noun+";
                                shortPof[j] = 'n';
                                shortPofTemp[j] = 'n';
                                j++;
                                flag = 1;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                    if (printPof[j] == null)
                    {
                        printPof[j] = word + " : Noun";
                        tokenAttribute[j] =  word + "(icl>undefined object)";
                        tokenAtt[j] = "unknownatt";
                        grammar[0] += "Noun+";
                        shortPof[j] = 'n';
                        shortPofTemp[j] = 'n';
                        j++;
                    }

                    if (printPof2[z] == null)
                    {
                        printPof2[z] = word + " : Noun";
                        tokenAttribute2[z] = word + "(icl>undefined object)";
                        tokenAtt2[z] = "unknownatt";
                        grammar[0] += "Noun+";
                        shortPof2[z] = 'n';
                        shortPofTemp2[z] = 'n';
                        z++;
                    }
                    flag = 0;
                }
            }
            grammar[0] = grammar[0].Remove(grammar[0].Length - 1);//last + remove
            richTextBox1.Text += string.Join("\n", printPof) + "\n";//print pof for each word
            richTextBox1.Text += string.Join("\n", printPof2) + "\n";//print pof for each word

            richTextBox2.Text += string.Join("\n", grammar) + "\n";//print grammar rule

            
                                                    /************************************/

            int sPofSize = shortPof.Length;
            int newSize = sPofSize;

            for (int i = 0; i < newSize; i++)//replace p,n,v by N,N,V
            {
                if (shortPof[i] == 'p')
                {
                    shortPof[i] = 'N';
                    NounPhraseCount++;
                }
                else if (shortPof[i] == 'n')
                {
                    shortPof[i] = 'N';
                    NounPhraseCount++;
                }
                else if (shortPof[i] == 'v')
                {
                    shortPof[i] = 'V';
                }
            }
            for (int k = 0; k < 1000; k++)//ekhan theke charcter kombe
            {
                for (int i = 0; i < newSize - 1; i++)//character komar jonne, newsize theke 1 biyog
                {
                    if (shortPof[i] == 'N' && shortPof[i + 1] == 'V')
                    {
                        shortPof[i] = 'V';
                        for (int l = i + 1; l < newSize - 1; l++)//porer okkhor ek ghor age ana
                        {
                            shortPof[l] = shortPof[l + 1];
                        }
                        newSize--;
                    }
                    else if (shortPof[i] == 'a' && shortPof[i + 1] == 'V')
                    {
                        shortPof[i] = 'V';
                        for (int l = i + 1; l < newSize - 1; l++)
                        {
                            shortPof[l] = shortPof[l + 1];
                        }
                        newSize--;
                    }
                    else if (shortPof[i] == 'V' && shortPof[i + 1] == 'd')
                    {
                        shortPof[i] = 'V';
                        for (int l = i + 1; l < newSize - 1; l++)
                        {
                            shortPof[l] = shortPof[l + 1];
                        }
                        newSize--;
                    }
                }
            }
            int dif = sPofSize - newSize;
            Array.Resize(ref shortPof, shortPof.Length - dif);//last er gula baad
            if (shortPof.Length == 1 && shortPof[0] == 'V' && sizeOfArray > 1)
            {

                shortPof[0] = 'S';
            }
            if (shortPof[0] == 'S' && NounPhraseCount < 3)
            {
                flagg = 1;
                flagg = 0;
                int counter = 0;
                ua[0] += "[S]\n";
                foreach (string att in tokenAttribute)
                {
                    if (att != tokenAttribute[verbPosition])
                    {
                        if (tokenAtt[counter] == "place")
                        {
                            ua[0] += "plc{" + tokenAttribute[verbPosition] + "," + att + "}\n";
                        }
                        else if (tokenAtt[counter] == "food")
                        {
                            ua[0] += "fd{" + tokenAttribute[verbPosition] + "," + att + "}\n";
                        }
                        if (tokenAtt[counter] == "adjective")
                        {
                            ua[0] += "adj{" + tokenAttribute[verbPosition] + "," + att + "}\n";
                        }
                        else
                        {
                            ua[0] += "unknown{" + tokenAttribute[verbPosition] + "," + att + "}\n";
                        }
                    }
                    counter++;
                }

                ua[0] += "[/S]\n";
                richTextBox4.Text += string.Join("\n", ua) + "\n";
                richTextBox3.Text += string.Join("\n", "This is a simple sentense") + "\n";
            }
            else if ((grammar[0] == "Pronoun+Verb+Conjunction+Noun+Verb") || (grammar[0] == "Noun+Noun+Verb+Conjuction+Noun+Verb") || (grammar[0] == "Pronoun+Noun+Verb+Conjunction+Pronoun+Verb") || (grammar[0] == "Pronoun+Verb+Conjunction+Pronoun+Verb") || (grammar[0] == "Pronoun+Noun+Verb+Conjunction+Pronoun+Noun+Noun+Verb") || (grammar[0] == "Pronoun+Noun+Noun+Conjunction+Pronoun+Verb") || (grammar[0] == "Noun+Noun+Verb+Conjunction+Pronoun+Verb") || (grammar[0] == "Noun+Noun+Noun+Verb+Conjunction+Pronoun+Noun+Noun+Verb") || (grammar[0] == "Pronoun+Conjunction+Pronoun+Noun+Noun+Verb") || (grammar[0] == "Noun+Noun+Conjunction+Pronoun+Noun+Noun+Verb") || (grammar[0] == "Noun+Noun+Conjunction+Noun+Noun+Noun+Noun+Verb"))
            {
                //flagg = 0;
                int counter = 0;
               // ua2[0] += "[S]\n";
                foreach (string att in tokenAttribute)
                {
                    if (att != tokenAttribute[verbPosition])
                    {
                        ua[0] += "LAW UW =[" + tokenAttribute[verbPosition] + "] (V,CONADD)\n";

                    }
                    break;

                }
                foreach (string att in tokenAttribute2)
                {
                    if (att != tokenAttribute2[verbPosition])
                    {
                        ua2[0] += "RAW UW =["+ tokenAttribute2[verbPosition] +"] (V,AOJRES)\n";
                       
                    }
                    break;
           
                }

                //ua2[0] += "[/S]\n";
                richTextBox4.Text += string.Join("\n", ua)+ "\n";
                richTextBox4.Text += string.Join("\n", ua2) + "\n";
                
                
                     richTextBox3.Text += string.Join("\n", "This is a compound sentense") + "\n";
            }

            else if (grammar[0] == "Condition+Pronoun+Verb+Condition+Pronoun+Verb")
            { 
               
                foreach (string att in tokenAttribute)
                {
                    if (att != tokenAttribute[verbPosition])
                    {
                        ua[0] += "agt(" + tokenAttribute[verbPosition] ;
                        ua2[0] += "obj:01 " + tokenAttribute[verbPosition] + " সে(icl>human)"+"\n" +"agt:01" + tokenAttribute[verbPosition] + " আমি(icl>human)";
                    } 
                    break;
                 }
               
                    richTextBox4.Text += string.Join("\n", ua) + "\n";
                    richTextBox4.Text += string.Join("\n", ua2) + "\n";
                    
                    richTextBox3.Text += string.Join("\n", "This is a complex sentense") + "\n";
                
            }
            else if (grammar[0] == "Condition+Noun+Noun+Verb+Condition+Pronoun+Verb")
            {

                foreach (string att in tokenAttribute)
                {
                    if (att != tokenAttribute[verbPosition])
                    {
                        ua[0] += "agt(" + tokenAttribute[verbPosition];
                        ua2[0] += "obj:01 " + tokenAttribute[verbPosition] + " রহিম(icl>human)" + "\n" + "agt:01" + tokenAttribute[verbPosition] + " আমি(icl>human)";
                    }
                    break;
                }

                richTextBox4.Text += string.Join("\n", ua) + "\n";
                richTextBox4.Text += string.Join("\n", ua2) + "\n";

                richTextBox3.Text += string.Join("\n", "This is a complex sentense") + "\n";

            }
            else if (grammar[0] == "Condition+Noun+Noun+Verb+Condition+Noun+Noun+Verb")
            {

                foreach (string att in tokenAttribute)
                {
                    if (att != tokenAttribute[verbPosition])
                    {
                        ua[0] += "agt(" + tokenAttribute[verbPosition];
                        ua2[0] += "obj:01 " + tokenAttribute[verbPosition] + " রহিম(icl>human)" + "\n" + "agt:01" + tokenAttribute[verbPosition] + " করিম(icl>human)";
                    }
                    break;
                }

                richTextBox4.Text += string.Join("\n", ua) + "\n";
                richTextBox4.Text += string.Join("\n", ua2) + "\n";

                richTextBox3.Text += string.Join("\n", "This is a complex sentense") + "\n";

            }
            else
             {
                richTextBox3.Text += string.Join("\n", "This is not a sentense") + "\n";
             }
            //richTextBox3.Text = string.Join("\n", shortPof) + "\n";


                                                   /************************************/

      


         
        }

    }
 }
