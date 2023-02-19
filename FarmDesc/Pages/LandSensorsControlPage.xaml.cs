using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static FarmDesc.Classes.Helper;
using static FarmDesc.Classes.GetData;
using FarmDesc.Models;
using System.Windows.Forms.DataVisualization.Charting;


namespace FarmDesc.Pages
{
    /// <summary>
    /// Логика взаимодействия для LandSensorsControlPage.xaml
    /// </summary>
    public partial class LandSensorsControlPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public LandSensorsControlPage()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick; ;
            InitializeComponent();
        }

        private void GraphGen()
        {

            try
            {
                SensorsGraph.ChartAreas.Add(new ChartArea("Сенсоры"));
                SensorsGraph.ChartAreas["Сенсоры"].AxisY.Interval = 5;


                


                Series ser1Hum = new Series("Сенсор1Влаж");
                ser1Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser1Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                


                Series ser2Hum = new Series("Сенсор2Влаж");
                ser2Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser2Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                


                Series ser3Hum = new Series("Сенсор3Влаж");
                ser3Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser3Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                


                Series ser4Hum = new Series("Сенсор4Влаж");
                ser4Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser4Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                Series ser5Hum = new Series("Сенсор5Влаж");
                ser5Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser5Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;




                Series ser6Hum = new Series("Сенсор6Влаж");
                ser6Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser6Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                SensorsGraph.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd hh:mm:ss";

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
        private void GraphData()
        {

            try
            {
                

                var ox11 = Db.LandSensorLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy11 = Db.LandSensorLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор1Влаж"].Points.DataBindXY(ox11, oy11);

                
                var ox21 = Db.LandSensorLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy21 = Db.LandSensorLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор2Влаж"].Points.DataBindXY(ox21, oy21);

                
                var ox31 = Db.LandSensorLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy31 = Db.LandSensorLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор3Влаж"].Points.DataBindXY(ox31, oy31);


                var ox41 = Db.LandSensorLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy41 = Db.LandSensorLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор4Влаж"].Points.DataBindXY(ox41, oy41);

                var ox51 = Db.LandSensorLogs.Where(el => el.id == 5 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy51 = Db.LandSensorLogs.Where(el => el.id == 5 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор5Влаж"].Points.DataBindXY(ox51, oy51);


                var ox61 = Db.LandSensorLogs.Where(el => el.id == 6 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy61 = Db.LandSensorLogs.Where(el => el.id == 6 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор4Влаж"].Points.DataBindXY(ox61, oy61);


            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
        private void DataLoad()
        {

            try
            {
                Sensor1Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor2Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor3Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor4Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor5Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 5 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor6Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 6 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DataLoad();
            GraphData();
            LoadBtns();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            DataLoad();
            GraphGen();
            GraphData();
            LoadBtns();

            timer.Start();
        }

        private void LoadBtns()
        {

            try
            {
                if (Db.Devices.FirstOrDefault(el => el.Id == 7).State == false)
                {
                    Water1Btn.Content = "Открыть полив 1";
                    if (Db.LandSensorLogs.Where(el => el.id == 1).OrderByDescending(el => el.date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 3).Value || IsExtramod == true)
                    {
                        Water1Btn.IsEnabled = true;
                    }
                    else
                    {
                        Water1Btn.IsEnabled = false;
                    }
                }
                else
                {
                    Water1Btn.Content = "Закрыть полив 1";
                    Water1Btn.IsEnabled = true;
                }

                if (Db.Devices.FirstOrDefault(el => el.Id == 6).State == false)
                {
                    Water2Btn.Content = "Открыть полив 2";
                    if (Db.LandSensorLogs.Where(el => el.id == 2).OrderByDescending(el => el.date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 3).Value || IsExtramod == true)
                    {
                        Water2Btn.IsEnabled = true;
                    }
                    else
                    {
                        Water2Btn.IsEnabled = false;
                    }
                }
                else
                {
                    Water2Btn.Content = "Закрыть полив 2";
                    Water2Btn.IsEnabled = true;
                }

                if (Db.Devices.FirstOrDefault(el => el.Id == 5).State == false)
                {
                    Water3Btn.Content = "Открыть полив 3";
                    if (Db.LandSensorLogs.Where(el => el.id == 3).OrderByDescending(el => el.date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 3).Value || IsExtramod == true)
                    {
                        Water3Btn.IsEnabled = true;
                    }
                    else
                    {
                        Water3Btn.IsEnabled = false;
                    }
                }
                else
                {
                    Water3Btn.Content = "Закрыть полив 3";
                    Water3Btn.IsEnabled = true;
                }

                if (Db.Devices.FirstOrDefault(el => el.Id == 4).State == false)
                {
                    Water4Btn.Content = "Открыть полив 4";
                    if (Db.LandSensorLogs.Where(el => el.id == 4).OrderByDescending(el => el.date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 3).Value || IsExtramod == true)
                    {
                        Water4Btn.IsEnabled = true;
                    }
                    else
                    {
                        Water4Btn.IsEnabled = false;
                    }
                }
                else
                {
                    Water4Btn.Content = "Закрыть полив 4";
                    Water4Btn.IsEnabled = true;
                }

                if (Db.Devices.FirstOrDefault(el => el.Id == 3).State == false)
                {
                    Water5Btn.Content = "Открыть полив 5";
                    if (Db.LandSensorLogs.Where(el => el.id == 5).OrderByDescending(el => el.date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 3).Value || IsExtramod == true)
                    {
                        Water5Btn.IsEnabled = true;
                    }
                    else
                    {
                        Water5Btn.IsEnabled = false;
                    }
                }
                else
                {
                    Water5Btn.Content = "Закрыть полив 5";
                    Water5Btn.IsEnabled = true;
                }

                if (Db.Devices.FirstOrDefault(el => el.Id == 2).State == false)
                {
                    Water6Btn.Content = "Открыть полив 6";
                    if (Db.LandSensorLogs.Where(el => el.id == 6).OrderByDescending(el => el.date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 3).Value || IsExtramod == true)
                    {
                        Water6Btn.IsEnabled = true;
                    }
                    else
                    {
                        Water6Btn.IsEnabled = false;
                    }
                }
                else
                {
                    Water6Btn.Content = "Закрыть полив 6";
                    Water6Btn.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Water1Btn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Water1Btn.Content == "Открыть полив 1")
                {
                    if (WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 7).State = true;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив открыт");
                    }
                    else
                    {
                        Error("Ошибка открытия полива");
                    }

                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 7).State = false;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив закрыт");
                    }
                    else
                    {
                        Error("Ошибка закрытия полива");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Water2Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Water2Btn.Content == "Открыть полив 2")
                {
                    if (WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 6).State = true;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив открыт");
                    }
                    else
                    {
                        Error("Ошибка открытия полива");
                    }

                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 6).State = false;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив закрыт");
                    }
                    else
                    {
                        Error("Ошибка закрытия полива");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Water3Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Water3Btn.Content == "Открыть полив 3")
                {
                    if (WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 5).State = true;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив открыт");
                    }
                    else
                    {
                        Error("Ошибка открытия полива");
                    }

                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 5).State = false;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив закрыт");
                    }
                    else
                    {
                        Error("Ошибка закрытия полива");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Water4Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Water4Btn.Content == "Открыть полив 4")
                {
                    if (WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 4).State = true;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив открыт");
                    }
                    else
                    {
                        Error("Ошибка открытия полива");
                    }

                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 4).State = false;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив закрыт");
                    }
                    else
                    {
                        Error("Ошибка закрытия полива");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Water5Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Water5Btn.Content == "Открыть полив 5")
                {
                    if (WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 3).State = true;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив открыт");
                    }
                    else
                    {
                        Error("Ошибка открытия полива");
                    }

                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 3).State = false;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив закрыт");
                    }
                    else
                    {
                        Error("Ошибка закрытия полива");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Water6Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Water6Btn.Content == "Открыть полив 6")
                {
                    if (WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 2).State = true;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив открыт");
                    }
                    else
                    {
                        Error("Ошибка открытия полива");
                    }

                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 2).State = false;
                        Db.SaveChanges();
                        LoadBtns();
                        MessageBox.Show("Полив закрыт");
                    }
                    else
                    {
                        Error("Ошибка закрытия полива");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
