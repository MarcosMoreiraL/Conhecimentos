using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroApp.Entity.Models;
using static FinanceiroApp.Entity.Models.Transaction;

namespace FinanceiroApp.WPF.ViewModel.Helpers
{
    public class Filter
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public FilterTypes FilterType { get; set; }
        public OrderTypes OrderType { get; set; }

        public enum FilterTypes
        {
            None,
            Number,
            String,
            DateTime
        }

        public enum OrderTypes
        {
            Ascending,
            Descending
        }

        public Filter()
        {
            Begin = DateTime.Now;
            End = DateTime.Now.AddDays(1);
            FilterType = FilterTypes.None;
            OrderType = OrderTypes.Descending;
        }

        public Filter(DateTime begin, DateTime end)
        {
            Begin = begin;
            End = end;
            FilterType = FilterTypes.None;
            OrderType = OrderTypes.Descending;
        }

        public Filter(DateTime begin, DateTime end, FilterTypes filterType, OrderTypes orderType) : this(begin, end)
        {
            FilterType = filterType;
            OrderType = orderType;
        }
    }

    public class TransactionFilter : Filter
    {
        public enum TransactionTypesFilter
        {
            None,
            Income,
            Expense
        }

        public TransactionTypesFilter Type { get; set; } = TransactionTypesFilter.None;

        public TransactionFilter() : base()
        {
            this.Begin = DateTime.Now.AddDays(-30);
            this.End = DateTime.Now;
            this.Type = TransactionTypesFilter.None;
            this.FilterType = Filter.FilterTypes.DateTime;
            this.OrderType = Filter.OrderTypes.Ascending;
        }

        public TransactionFilter(DateTime begin, DateTime end, TransactionTypesFilter type) : base(begin, end) 
        { 
            this.Type = type;
            this.FilterType = Filter.FilterTypes.DateTime;
            this.OrderType = Filter.OrderTypes.Ascending;
            this.Type = type;
        }

        public TransactionFilter(DateTime begin, DateTime end, FilterTypes filterType, OrderTypes orderType, TransactionTypesFilter type) : base(begin, end, filterType, orderType)
        {
            this.Type = type;
        }
    }
}
