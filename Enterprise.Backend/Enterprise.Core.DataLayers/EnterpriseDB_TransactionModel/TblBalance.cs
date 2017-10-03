using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_TransactionModel
{
    public partial class TblBalance
    {
        public TblBalance()
        {
            TblTransaction = new HashSet<TblTransaction>();
        }

        public string UserDetailsId { get; set; }
        public string BalanceId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public ICollection<TblTransaction> TblTransaction { get; set; }
    }
}
