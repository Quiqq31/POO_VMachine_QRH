using PWI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWI
{
    public class FoodProducts : Product
    {
        private string nutri_info;

        public FoodProducts() 
        {
            Console.WriteLine("Nutritional info (calories, fats, sugars): ");
            this.nutri_info = Console.ReadLine();
        }

        public FoodProducts(string a) // cosntructor para lectura de ficheros automatica
        {
            //this.nutri_info = this.nutritional_information;
        }
        public override void Rellenar()
        {
            this.nutri_info = this.pal; // guardamos la variable de tipo de material
        }
    }
}
