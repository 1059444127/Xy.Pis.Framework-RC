using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class GblMrk
    {
        public int ID { get; set; }
        public string MrkFile { get; set; }
        public string MrkContent { get; set; }
        public bool IsActive { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
    }
}
