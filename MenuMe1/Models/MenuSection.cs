using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace MenuMe1.Models

{
    public class MenuSection
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }

        public Menu Menu { get; set; }

        public int MenuId { get; set; }

        public int Position { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        
    }
}
