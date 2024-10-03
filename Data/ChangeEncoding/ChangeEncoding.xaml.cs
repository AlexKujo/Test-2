﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkProject;
using WorkProject.Main;

namespace WorkProject
{
    /// <summary>
    /// Логика взаимодействия для ChangeEncoding.xaml
    /// </summary>
    public partial class ChangeEncoding : Window
    {
        public ChangeEncoding()
        {
            InitializeComponent();
        }

        private void ChangeEncodeButton_Click(object sender, RoutedEventArgs e)
        {
            string inputEncode = InputEncode.Text;
            string outputEncode;

            //KAMAZ53949-WE06-31-01-00-01RP4-520C-N

            if (IsValidFormat(inputEncode) == true)
            {
                List<string> sub = inputEncode.Split('-').ToList();

                outputEncode = $"ICN-{sub[0]}-{sub[1]}-{sub[2]}{sub[3]}{sub[4]}-A-00000-00000-{sub[6].Last()}-001-01";

                OutputEncode.Text = outputEncode;
            }
            else
            {
                MessageBox.Show("Неверный формат ввода");
                InputEncode.Text = "";
            }                    
        }

        private bool IsValidFormat( string inputEncode) => inputEncode.Split('-').ToList().Count == 8;
     
        private void OutputEncode_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(OutputEncode.Text);
            NoticeHelper.ShowNotification(CopyNotification,"Текст скопирован в буфер обмена!");
        }
    }
}
