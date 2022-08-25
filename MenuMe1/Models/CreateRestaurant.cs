using System.ComponentModel.DataAnnotations;


namespace MenuMe1.Models

{
    public class CreateRestaurant
    {
        public string Name { get; set; }
       
        public string Address { get; set; }
       
        public int Phone { get; set; }

        public string Website { get; set; }

        public string Motto { get; set; }
        
    }
}
