using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class HuAdjustDtl
    {
        public int ID { get; set; }
        public int InBatchId { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public decimal ProfLoss { get; set; }
        public decimal DrugNum { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public virtual BsItem BsItem { get; set; }
        public virtual HuAdjust HuAdjust { get; set; }
        public virtual HuStore HuStore { get; set; }
    }
}
