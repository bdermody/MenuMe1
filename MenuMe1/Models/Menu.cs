using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace MenuMe1.Models

{
    public class Menu
    {
        public Menu()
        {

        }

        public Menu(CreateMenu cr)
        {
            Name = cr.Name;
            RestaurantId = cr.RestaurantId;
        }
           

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public Restaurant Restaurant { get; set; }

        public int RestaurantId { get; set; }

        public List<MenuSection> MenuSections { get; set; }

    }
} 
