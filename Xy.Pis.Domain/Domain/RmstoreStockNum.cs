using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class RmstoreStockNum
    {
        public System.DateTime opertime { get; set; }
        public int HospitalId { get; set; }
        public int LsRoomType { get; set; }
        public int LsInOut { get; set; }
        public int ItemId { get; set; }
        public Nullable<decimal> StockNum { get; set; }
    }
}
