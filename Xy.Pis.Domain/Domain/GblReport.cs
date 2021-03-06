using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class GblReport
    {
        public GblReport()
        {
            this.GblReportGroups = new List<GblReportGroup>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public short OrderBy { get; set; }
        public bool IsActive { get; set; }
        public short LsOutOrIn { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public short IconIndex { get; set; }
        public virtual ICollection<GblReportGroup> GblReportGroups { get; set; }
    }
}
