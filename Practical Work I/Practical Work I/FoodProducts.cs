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

        public FoodProducts(int product_type, string product_name, int product_units, double product_unit_price, string product_description, string var6) // cosntructor para lectura de ficheros automatica
        {

            this.product_type = product_type;
            this.product_name = product_name;
            this.product_units = product_units;
            this.product_unit_price = product_unit_price;
            this.product_description = product_description;

            this.nutri_info = var6;
            this.nutritional_information = this.nutri_info;
        }
        public override void Rellenar()
        {
            this.nutri_info = this.pal; // guardamos la variable de tipo de material
        }
    }
}
