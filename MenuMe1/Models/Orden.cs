﻿using System.ComponentModel.DataAnnotations;
namespace MenuMe1.Models
{
    public class Orden
    {
        public Orden ()
        {

        }

        public Orden(CreateOrden co)
        {
            Mesa = co.Mesa;
            MenuItemId = co.MenuItemId;

        }

        [Key]
        public int Id { get; set; }

        
        public int Mesa { get; set; }

        public MenuItem MenuItem { get; set; }

        public int MenuItemId { get; set; }


    }
}





