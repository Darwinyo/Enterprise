using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_TransactionModel
{
    public partial class TblTransaction
    {
        public TblTransaction()
        {
            TblProductTransaction = new HashSet<TblProductTransaction>();
        }

        public string TransactionId { get; set; }
        public string UserDetailsId { get; set; }
        public string TypeTransaction { get; set; }
        public string TransactionMethod { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionCurrency { get; set; }
        public string TransactionDate { get; set; }
        public string BalanceId { get; set; }
        public string TransactionStatus { get; set; }

        public TblBalance Balance { get; set; }
        public ICollection<TblProductTransaction> TblProductTransaction { get; set; }
    }
}
