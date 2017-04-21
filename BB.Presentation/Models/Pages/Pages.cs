using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Presentation.Models.Pages
{
    public class Pages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual List<Pages> Children { get; set; }
    }
}