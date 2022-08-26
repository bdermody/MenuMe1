using System.ComponentModel.DataAnnotations;


namespace MenuMe1.Models

{
    public class CreateMenuItem
    {
        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public int Price { get; set; }

        public int Position { get; set; }



    }
}
