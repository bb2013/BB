using System.Collections.Generic;

namespace BB.Presentation.Models.Pages
{
    public class PageNodes
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual PageNodes Parent { get; set; }
        public virtual List<PageNodes> Children { get; set; }
    }
}