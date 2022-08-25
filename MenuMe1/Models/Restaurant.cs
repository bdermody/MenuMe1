using System.ComponentModel.DataAnnotations;


namespace MenuMe1.Models

{
    public class Restaurant
    {

        public Restaurant()
        {

        }

        public Restaurant(CreateRestaurant cr)
        {
            Name=cr.Name;
            Address=cr.Address;
            Phone=cr.Phone;
            Website = cr.Website;
            Motto = cr.Motto;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Address { get; set; }
       
        public int Phone { get; set; }

        public string Website { get; set; }

        public string Motto { get; set; }

        public List<Menu> Menus { get; set; }

        
    }
}
