using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class BsItemFrequency
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public int FrequencyId { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public short IconIndex { get; set; }
        public virtual BsFrequency BsFrequency { get; set; }
        public virtual BsItem BsItem { get; set; }
    }
}
