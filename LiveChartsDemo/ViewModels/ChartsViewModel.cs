using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;

namespace LiveChartsDemo.ViewModels
{
    class ChartsViewModel:ViewModelBase
    {
        public ChartsViewModel()
        {
            ChartGroup.Add("条形图");
            ChartGroup.Add("折线图");
            ChartGroup.Add("饼图");
            ChartGroup.Add("散点图");
        }

        #region 数据绑定
        /// <summary>
        /// 图表类型列表
        /// </summary>
        public List<string> ChartGroup { get { return _ChartGroup; } set { _ChartGroup = value; RaisePropertyChanged("ChartGroup"); } }
        private List<string> _ChartGroup = new List<string>();

        /// <summary>
        /// 条形图图表信息
        /// </summary>
        public ChartInfo BarChartInfo { get { return _BarChartInfo; } set { _BarChartInfo = value; RaisePropertyChanged("BarChartInfo"); } }
        private ChartInfo _BarChartInfo = new ChartInfo();

        /// <summary>
        /// 折线图图表信息
        /// </summary>
        public ChartInfo LineChartInfo { get { return _LineChartInfo; } set { _LineChartInfo = value; RaisePropertyChanged("LineChartInfo"); } }
        private ChartInfo _LineChartInfo = new ChartInfo();

        /// <summary>
        /// 饼图图表信息
        /// </summary>
        public ChartInfo PieChartInfo { get { return _PieChartInfo; } set { _PieChartInfo = value; RaisePropertyChanged("PieChartInfo"); } }
        private ChartInfo _PieChartInfo = new ChartInfo();
        #endregion

        #region 逻辑主体
        /// <summary>
        /// 生成当前选择的图表类型
        /// </summary>
        /// <param name="chartsKind">选择的图表类型的索引</param>
        public void ChoiceCharts(int chartsIndex)
        {
            switch(chartsIndex)
            {
                case (int)EnumChartsKind.BarChart:
                    CreateBarChart();
                    break;
                case (int)EnumChartsKind.LineChart:
                    CreateLineChart();
                    break;
                case (int)EnumChartsKind.PieChart:
                    CreatePieChart();
                    break;
                case (int)EnumChartsKind.PointChart:
                    CreatePointChart();
                    break;
                default:break;
            }
        }

        /// <summary>
        /// 生成条形图
        /// </summary>
        private void CreateBarChart()
        {
            SeriesCollection SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "深圳",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                },
                new ColumnSeries
            {
                Title = "广州",
                Values = new ChartValues<double> { 11, 56, 42 }
            }
            };

            string[] Labels = new[] { "2011", "2012", "2013", "2014", "2015" };
            BarChartInfo.Series = SeriesCollection;
            BarChartInfo.XLables = Labels;
            BarChartInfo = BarChartInfo;
        }

        /// <summary>
        /// 生成折线图
        /// </summary>
        private void CreateLineChart()
        {
            SeriesCollection series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "深圳",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,7 }
                },
                new LineSeries
                {
                    Title = "广州",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 }
                }
            };

            //x轴
            string[] Labels = new[] { "2011", "2012", "2013", "2014", "2015" };
            LineChartInfo.Series = series;
            LineChartInfo.XLables = Labels;
            LineChartInfo = LineChartInfo;
        }

        /// <summary>
        /// 生成饼图
        /// </summary>
        private void CreatePieChart()
        {
            SeriesCollection SeriesCollection = new SeriesCollection();

            SeriesCollection.Add(new PieSeries()
            {
                Title = "高一(1)班",
                Values = new ChartValues<int>() { 30 },
                DataLabels = true,
                LabelPoint = new Func<ChartPoint, string>((chartPoint) =>
                {
                    return string.Format("{0}{1} ({2:P})", chartPoint.SeriesView.Title, chartPoint.Y, chartPoint.Participation);
                })
            });
            SeriesCollection.Add(new PieSeries()
            {
                Title = "高一(2)班",
                Values = new ChartValues<int>() { 50 },
                DataLabels = true,
                LabelPoint = new Func<ChartPoint, string>((chartPoint) =>
                {
                    return string.Format("{0}{1} ({2:P})", chartPoint.SeriesView.Title, chartPoint.Y, chartPoint.Participation);
                })
            });
            SeriesCollection.Add(new PieSeries()
            {
                Title = "高一(3)班",
                Values = new ChartValues<int>() { 20 },
                DataLabels = true,
                LabelPoint = new Func<ChartPoint, string>((chartPoint) =>
                {
                    return string.Format("{0}{1} ({2:P})", chartPoint.SeriesView.Title, chartPoint.Y, chartPoint.Participation);
                })
            });

            PieChartInfo.Series = SeriesCollection;
            PieChartInfo = PieChartInfo;
        }

        private void CreatePointChart()
        {
            Trace.WriteLine("散点图");
        }
        #endregion
    }


    /// <summary>
    /// 图表信息
    /// </summary>
    public class ChartInfo
    {
        /// <summary>
        /// 图表主体
        /// </summary>
        public SeriesCollection Series { get; set; }
        /// <summary>
        /// X坐标轴标签列表
        /// </summary>
        public string[] XLables { get; set; }
        /// <summary>
        /// X轴步长
        /// </summary>
        public int XStep { get; set; }
        /// <summary>
        /// X轴图表标签格式
        /// </summary>
        public Func<double, string> LabelFormatter { get; set; }
        /// <summary>
        /// Y坐标轴标签列表
        /// </summary>
        public string[] YLables { get; set; }      
        /// <summary>
        /// Y轴步长
        /// </summary>
        public int YStep { get; set; }
        /// <summary>
        /// Y轴图表标签格式
        /// </summary>
        public Func<double, string> YLabelFormatter { get; set; }
    }


    /// <summary>
    /// 图表类型
    /// </summary>
    enum EnumChartsKind
    {
        /// <summary>
        /// 条形图
        /// </summary>
        BarChart,
        /// <summary>
        /// 折线图
        /// </summary>
        LineChart,
        /// <summary>
        /// 饼图
        /// </summary>
        PieChart,
        /// <summary>
        /// 散点图
        /// </summary>
        PointChart,
    }
}
