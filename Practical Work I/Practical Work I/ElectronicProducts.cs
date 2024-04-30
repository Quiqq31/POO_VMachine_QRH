using PWI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWI
{
    public class ElectronicProducts : Product
    {
        private string mat;
        private bool bateria;
        private bool bateria_cargada;
        public ElectronicProducts()
        {
            Console.WriteLine("What are the materials used?: ");
            this.mat = Console.ReadLine();

            Console.WriteLine("Does it have a battery?");
            this.bateria = bool.Parse(Console.ReadLine());

            if (this.bateria == true)
            {
                Console.WriteLine("Is it charged? ");
                this.bateria_cargada = bool.Parse(Console.ReadLine());
            }
        }

        public ElectronicProducts(string a) // cosntructor para rellenar con ficheros
        {
            //this.mat = this.materials;
            //this.bateria = this.has_battery;
            //this.bateria_cargada = this.charged_by_default;

        }

        public override void Rellenar()
        {
            if (this.index_pal == 5) // si es el campo de los materiales
            {
                this.materials = this.pal; // guardamos la variable de tipo de materiales del producto
            }
            else if (this.index_pal == 6) // si es el campo de si tiene bateria o no
            {
                this.has_battery = bool.Parse(this.pal); // guardamos si tiene o no bateria (si tiene = 1, no tiene = 0)
            }
            else if (this.index_pal == 7) // si es el campo que comprueba si esta cargada la bateria  o no
            {
                if (this.has_battery == true) // si tiene bateria miramos si esta cargada o no
                {
                    this.charged_by_default = bool.Parse(this.pal); // guardamos en la variable, si la bateria esta cargada o no (1 = si esta cargada, 0 = no esta cargada)
                }
            }
        }
    }
}