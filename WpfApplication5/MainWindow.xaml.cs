using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;
using HAP = HtmlAgilityPack;
using HtmlAgilityPack;


namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var webGet = new HtmlWeb();
            var doc = webGet.Load("http://vremea.ido.ro/Mioveni.htm");
            HtmlNode ourNode = doc.DocumentNode.SelectSingleNode("//div[@id='body']");

            int semafor = 0;
            int s = 0;
            string vreme = ourNode.InnerText;
            string outVreme = "";
            for (int i = 0; i < vreme.Length; i++)
            {
               
                
                if (semafor == 1)
                {
                    
                    outVreme += vreme[i];
                }
                if (vreme[i] == '>') semafor = 1;
                if (vreme[i] == ':' && vreme[i - 1] == 'm')
                {
                    s = i;
                }
                if (i == s + 3) i += 6;
                if (vreme[i].Equals('%')) break;
            }
            textBlock1.Text = outVreme;
        }

        
    }
}
