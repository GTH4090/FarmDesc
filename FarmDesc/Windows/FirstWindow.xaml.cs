﻿using FarmDesc.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using static FarmDesc.Classes.GetData;
using static FarmDesc.Classes.Helper;
using FarmDesc.Models;

namespace FarmDesc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        
        public FirstWindow()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick;
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Db.AirSensorsLogs.AddRange(GetAirSensorsData());
            Db.LandSensorLogs.AddRange(GetLandSensorsData());
            Db.SaveChanges();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if(MainFrame.CanGoBack == false)
            {
                BackBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                BackBtn.Visibility = Visibility.Visible; 
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
