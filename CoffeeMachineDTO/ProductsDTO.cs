using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.DTO
{
    public class ProductsDTO
    {
        public int RequiredId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Coffee { get; set; }
        public int Water { get; set; }
        public int Suger { get; set; }
    }
}
