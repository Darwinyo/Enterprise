using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_TransactionModel
{
    public partial class TblProductTransaction
    {
        public string ProductTransactionId { get; set; }
        public string ProductId { get; set; }
        public int ProductAmount { get; set; }
        public string TransactionId { get; set; }

        public TblTransaction Transaction { get; set; }
    }
}
