using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace ExpenseAnalysis
{
    public class TrendsPageViewModel : ExpenseViewModelBase
    {
        private IEnumerable _selectedTrends;

        private double _trendSpent;

        /// <summary>
        /// Gets or sets transactions details for selected month
        /// </summary>
        public IEnumerable SelectedTrends
        {
            get { return _selectedTrends; }

            set
            {
                _selectedTrends = value;
                NotifyPropertyChanged("SelectedTrends");
            }
        }

        /// <summary>
        /// Gets or sets the Cutsom palette for PieSeries
        /// </summary>
        public List<Color> CategoryColors { get; set; }

        public ICommand SelectionChanged { get; set; }

        public TrendsPageViewModel()
        {
            SelectionChanged = new Command(execute: OnSelectedDataPointChanged);
            UpdateTrends(2);
            CategoryColors = new List<Color>
            {
                Color.FromHex("#EA8F00"),
                Color.FromHex("#29ABE2"),
                Color.FromHex("#9f94ed"),
                Color.FromHex("#eec456"),
                Color.FromHex("#6aaaea"),
                Color.FromHex("#f06386"),
                Color.FromHex("#12ccc7"),
                Color.FromHex("#93278f"),
                Color.FromHex("#8cc63f"),
            };
        }

        private void OnSelectedDataPointChanged(object obj)
        {
            var arg = obj as ChartSelectionEventArgs;
            if (arg.SelectedDataPointIndex != -1)
                UpdateTrends(arg.SelectedDataPointIndex);
        }

        /// <summary>
        /// Sets transactions details of given month to SelectedTrends
        /// </summary>
        /// <param name="month"></param>
        public void UpdateTrends(int SelectedIndex)
        {
            _trendSpent = 0;
            foreach (var expense in Categories)
            {
                _trendSpent += expense.Spent;
            }
            SelectedTrends = Transactions.Where(i => i.Date.Month == SelectedIndex + 1).GroupBy(i => i.Category)
                .Select(
                    g =>
                        new
                        {
                            Category = g.Key,
                            Value = g.Sum(i => i.Spent),
                            Percentage = g.Sum(i => i.Spent) / _trendSpent * 100,
                            Month = SelectedIndex + 1
                        }).ToList();
        }
    }
}
