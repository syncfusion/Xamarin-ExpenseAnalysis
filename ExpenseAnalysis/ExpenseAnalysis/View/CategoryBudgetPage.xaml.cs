namespace ExpenseAnalysis
{
    public partial class CategoryBudgetPage
    {
        public CategoryBudgetPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            CategoryColumn.Width = width*0.6;
            base.OnSizeAllocated(width, height);
        }
    }
}