using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class BsBacteriaShu
    {
        public BsBacteriaShu()
        {
            this.BsBacterias = new List<BsBacteria>();
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string PyCode { get; set; }
        public string WbCode { get; set; }
        public short OrderBy { get; set; }
        public bool IsActive { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public short IconIndex { get; set; }
        public Nullable<int> GramsId { get; set; }
        public virtual ICollection<BsBacteria> BsBacterias { get; set; }
        public virtual BsBacteriaGram BsBacteriaGram { get; set; }
        public virtual BsBacteriaType BsBacteriaType { get; set; }
    }
}
