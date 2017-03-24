using Syncfusion.SfChart.XForms;

namespace ExpenseAnalysis
{
    public class ChartSelectionBehaviorExt : ChartSelectionBehavior
    {
        protected override void OnSelectionChanged(ChartSelectionEventArgs arg)
        {
            if (arg.SelectedDataPointIndex != -1)
                ((ExpenseViewModel)BindingContext).UpdateTrends(arg.SelectedDataPointIndex);
            base.OnSelectionChanged(arg);
        }
    }
}