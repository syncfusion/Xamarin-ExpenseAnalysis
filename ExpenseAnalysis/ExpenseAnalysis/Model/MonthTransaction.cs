using System.Collections.Generic;

namespace ExpenseAnalysis
{
    public class MonthTransaction
    {
        public List<TransactionDetail> MonthData { get; set; }

        public string Title { get; set; }

        public MonthTransaction(List<TransactionDetail> monthData, string title)
        {
            this.MonthData = monthData;
            this.Title = title;
        }
    }
}