using System.ComponentModel.DataAnnotations;


namespace MenuMe1.Models

{
    public class MenuItem
    {

        public MenuItem()
        {

        }

        public MenuItem(CreateMenuItem cmi)
        {
            Name = cmi.Name;
            Description = cmi.Description;
            Price = cmi.Price;
            MenuSectionId = cmi.MenuSectionId;
            Position = cmi.Position;

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public int Price { get; set; }

        public int Position { get; set; }

        public MenuSection MenuSection { get; set; }

        public int MenuSectionId { get; set; }



    }
}
