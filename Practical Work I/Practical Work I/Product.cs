using System;
using System.ComponentModel.Design;

namespace PWI
{
    public class Product
    {
        //protected string type;
        //protected string name;
        //private int units;
        //private double price;
        //private string description;

        protected string pal;
        protected int index_pal;
        protected int index_lin;


        // vars generales
        protected int product_type;
        protected string product_name;
        protected int product_units;
        protected double product_unit_price;
        protected string product_description;

        // vars para mat precious
        protected string materials;
        protected string weight;


        // vars para food
        protected string nutritional_information;

        // vars para electod prod
        protected bool has_battery;
        protected bool charged_by_default;

        private List<PreciousMaterials> precious_materials;
        private List<FoodProducts> food_products;
        private List<ElectronicProducts> elect_products;

        public Product() { }

        public Product(int a)
        {
            
            Console.WriteLine("Name of the product: ");
            this.product_name = Console.ReadLine();

            Console.WriteLine("How many units?: ");
            this.product_units = int.Parse(Console.ReadLine());

            Console.WriteLine("What will be the price of one unit?: ");
            this.product_unit_price = double.Parse(Console.ReadLine());

            Console.WriteLine("Description of the product: ");
            this.product_description = Console.ReadLine();

        }

        //public Product(int product_type, string product_name, int product_units, double product_unit_price, string product_description, int index_pal, string pal)
        //{
        //    this.product_type = product_type;
        //    this.product_name = product_name;
        //    this.product_units = product_units;
        //    this.product_unit_price = product_unit_price;
        //    this.product_description = product_description;

        //    this.index_pal = index_pal;
        //    this.pal = pal;

        //    if (this.product_type == 1) // crear un material precioso
        //    {
        //        PreciousMaterials mat2 = new PreciousMaterials("tipo1");

        //        mat2.Rellenar();
        //        this.precious_materials.Add(mat2);


        //    }
        //    else if (this.product_type == 2) // crear un alimento
        //    {
        //        FoodProducts food2 = new FoodProducts("tipo2");

        //        food2.Rellenar();

        //        this.food_products.Add(food2);
        //    }
        //    else if (this.product_type == 3) // crear un prod electronico
        //    {
        //        ElectronicProducts elec2 = new ElectronicProducts("tipo3");

        //        elec2.Rellenar();
        //        this.elect_products.Add(elec2);
        //    }
        //}

        public virtual void Rellenar(){ }

        // aqui escribir en el .txt
        //public void LeerFile(string stock)
        //{
        //    int y = 0; // indice de lineas
        //    int x = 0; // indice de palabras

        //    string[] lineas = File.ReadAllLines(stock); // leemos todas las lineas del fichero y las guardamos en un array de tipo string

        //    foreach (string lineaA in lineas) // recorremos todas las lineas, una a una
        //    {
        //        this.index_lin = y;
        //        Console.WriteLine(lineas[y]); // para ver la linea completa
                
        //        string[] pFilt = lineaA.Split(';'); // separamos las palabras de la linea con un split ';'
        //        foreach(string palabra in pFilt) // recorremos todas las palabras de la linea, una por una
        //        {
        //            this.index_pal = x;
        //            switch (x)
        //            {
        //                case 0: // product_type
        //                    this.product_type = int.Parse(palabra); // guardamos en la variable, el tipo de producto:['Precious Mat' = 1, 'Food' = 2, 'Electro. Mat' = 3]
        //                    break;
        //                case 1: // product_name
        //                    this.product_name = palabra; // guardamos en la variable, el nombre del producto
        //                    break;
        //                case 2: // product_units
        //                    this.product_units = int.Parse(palabra); // guardamos en la variable, las unidades que hay de el producto
        //                    break;
        //                case 3: // product_unit_price
        //                    this.product_unit_price = double.Parse(palabra); // guardamos en la variable, el precio por unidad del producto
        //                    break;
        //                case 4: // product_description
        //                    this.product_description = palabra; // guardamos en la variable, la descripcion del producto
        //                    break;
        //                default: // si es uno de los campos especificos del tipo de producto
        //                    if (this.product_type == 1) // crear un material precioso
        //                    {
        //                        if (x == 5) // tipo de material
        //                        {
        //                            this.materials = palabra; // guardamos la variable de tipo de material
        //                        }
        //                        else if (x == 6) // weight
        //                        {
        //                            this.weight = palabra; // guardamos la variable del peso del producto
        //                        }
        //                    }
        //                    else if (this.product_type == 2) // crear un alimento
        //                    {
        //                        this.nutritional_information = palabra; // guardamos en la variable, la info nutricional 
        //                    }
        //                    else if (this.product_type == 3) // crear un prod electronico
        //                    {
        //                        if(x == 5) // si es el campo de los materiales
        //                        {
        //                            this.materials = palabra; // guardamos la variable de tipo de materiales del producto
        //                        }
        //                        else if(x == 6) // si es el campo de si tiene bateria o no
        //                        {
        //                            this.has_battery = bool.Parse(palabra); // guardamos si tiene o no bateria (si tiene = 1, no tiene = 0)
        //                        }
        //                        else if(x == 7) // si es el campo que comprueba si esta cargada la bateria  o no
        //                        {
        //                            if(this.has_battery == true) // si tiene bateria miramos si esta cargada o no
        //                            {
        //                                this.charged_by_default = bool.Parse(palabra); // guardamos en la variable, si la bateria esta cargada o no (1 = si esta cargada, 0 = no esta cargada)
        //                            }
        //                        }
        //                    }
        //                    break;
        //            }
        //            this.pal = palabra;
        //            x++;
        //        }

        //        if (this.product_type == 1) // crear un material precioso
        //        {
        //            PreciousMaterials matA = new PreciousMaterials("tipo1");
        //            //matA.Rellenar();
        //        }
        //        else if (this.product_type == 2) // crear un alimento
        //        {
        //            FoodProducts food1 = new FoodProducts("tipo2");
        //        }
        //        else if (this.product_type == 3) // crear un prod electronico
        //        {
        //            ElectronicProducts elec2 = new ElectronicProducts("tipo3");
        //        }
        //        x = 0; // indice de palabras a cero, para que comience desde la primera palabra en la siguiente linea
        //        y++; // aumentamos el indice de linea, para que pase a procesar/leer la siguiente linea del fichero
        //    }
        //}


        public int GetProduct_Type()
        {
            return this.product_type;
        }
        public string GetProduct_Name()
        {
            return this.product_name;
        }
        public int GetProduct_Units()
        {
            return this.product_units;
        }
        public double GetProduct_Price()
        {
            return this.product_unit_price;
        }
        public string GetProduct_Description()
        {
            return this.product_description;
        }

        // GETTER -> PRECIOUS MAT
        public string GetMaterials()
        {
            return this.materials;
        }
        public string GetWeight()
        {
            return this.weight;
        }
        
        
        // GETTER -> FOOD PROD
        public string GetNutri_Info()
        {
            return this.nutritional_information;
        }
        
        
        // GETTER -> ELECT PROD
        public bool GetBattery()
        {
            return this.has_battery;
        }
        public bool GetBattery_Charge()
        {
            return this.charged_by_default;
        }

        public string GetPreciousMaterialsMat()
        {
            string materiales;
            foreach(PreciousMaterials preM in precious_materials)
            {
                return preM.GetMat();
            }
            return null;
        }


        public void SetEliminarProducto()
        {
            this.product_units--;
        }
        public void IncreaseProductUnits(int quantity)
        {
            this.product_units = quantity;
        }
    }
}
