﻿using PWI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWI
{
    public class PreciousMaterials : Product
    {
        private string mat;
        private string peso;
        public PreciousMaterials()
        {
            Console.WriteLine("What is the type of the material?: ");
            this.mat = Console.ReadLine();
            Console.WriteLine("What is the weight?(g): ");
            this.weight = Console.ReadLine();

        }
        public PreciousMaterials(string materia, string pesos) // constructor para el rellnar automatico (usando files)
        {
            this.mat = materia;
            this.peso = pesos;
        }

        public PreciousMaterials(string a) // constructor para el rellnar automatico (usando files)
        {
            this.mat = this.materials;
            this.peso = this.weight;
        }

        public override void Rellenar()
        {
            if (this.index_pal == 5) // tipo de material
            {
                this.materials = this.pal; // guardamos la variable de tipo de material
            }
            else if (this.index_pal == 6) // weight
            {
                this.weight = this.pal; // guardamos la variable del peso del producto
            }
            this.mat = this.materials;
            this.peso = this.weight;
        }

        public string GetMat()
        {
            return this.materials;
        }
        public string GetPeso()
        {
            return this.peso;
        }

    }
}