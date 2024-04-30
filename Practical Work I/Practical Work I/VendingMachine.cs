using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWI
{
    public class VendingMachine
    {
        private int index_pal;
        private string pal;

        // vars generales para cada producto
        private int product_type;
        private string product_name;
        private int product_units;
        private double product_unit_price;
        private string product_description;

        // vars para mat precious
        private string materials;
        private string weight;


        // vars para food
        private string nutritional_information;

        // vars para electod prod
        private bool has_battery;
        private bool charged_by_default;

        private char newProduct;

        //private string typeMat;
        //private double weight;

        //private string typeMatE;
        //private bool battery;
        //private bool precharged;

        //private string nutInfo;

        private List<Product> products;

        public VendingMachine()
        {
            this.newProduct = 'a';
            this.products = new List<Product>();
        }

        public void LeerFile(string stock)
        {
            int y = 0; // indice de lineas
            int x = 0; // indice de palabras

            string[] lineas = File.ReadAllLines(stock); // leemos todas las lineas del fichero y las guardamos en un array de tipo string

            foreach (string lineaA in lineas) // recorremos todas las lineas, una a una
            {
                Console.WriteLine(lineas[y]); // para ver la linea completa

                string[] pFilt = lineaA.Split(';'); // separamos las palabras de la linea con un split ';'
                foreach (string palabra in pFilt) // recorremos todas las palabras de la linea, una por una
                {
                    this.index_pal = x;
                    switch (x)
                    {
                        case 0: // product_type
                            this.product_type = int.Parse(palabra); // guardamos en la variable, el tipo de producto:['Precious Mat' = 1, 'Food' = 2, 'Electro. Mat' = 3]
                            break;
                        case 1: // product_name
                            this.product_name = palabra; // guardamos en la variable, el nombre del producto
                            break;
                        case 2: // product_units
                            this.product_units = int.Parse(palabra); // guardamos en la variable, las unidades que hay de el producto
                            break;
                        case 3: // product_unit_price
                            this.product_unit_price = double.Parse(palabra); // guardamos en la variable, el precio por unidad del producto
                            break;
                        case 4: // product_description
                            this.product_description = palabra; // guardamos en la variable, la descripcion del producto
                            break;
                        default: // si es uno de los campos especificos del tipo de producto
                            if (this.product_type == 1) // crear un material precioso
                            {
                                if (x == 5) // tipo de material
                                {
                                    this.materials = palabra; // guardamos la variable de tipo de material
                                }
                                else if (x == 6) // weight
                                {
                                    this.weight = palabra; // guardamos la variable del peso del producto
                                }

                            }
                            else if (this.product_type == 2) // crear un alimento
                            {
                                this.nutritional_information = palabra; // guardamos en la variable, la info nutricional 
                            }
                            else if (this.product_type == 3) // crear un prod electronico
                            {
                                if (x == 5) // si es el campo de los materiales
                                {
                                    this.materials = palabra; // guardamos la variable de tipo de materiales del producto
                                }
                                else if (x == 6) // si es el campo de si tiene bateria o no
                                {
                                    this.has_battery = bool.Parse(palabra); // guardamos si tiene o no bateria (si tiene = 1, no tiene = 0)
                                }
                                else if (x == 7) // si es el campo que comprueba si esta cargada la bateria  o no
                                {
                                    if (this.has_battery == true) // si tiene bateria miramos si esta cargada o no
                                    {
                                        this.charged_by_default = bool.Parse(palabra); // guardamos en la variable, si la bateria esta cargada o no (1 = si esta cargada, 0 = no esta cargada)
                                    }
                                }
                            }
                            break;
                    }
                    this.pal = palabra;
                    x++;
                }
                if(this.product_type == 1)
                {
                    PreciousMaterials mat2 = new PreciousMaterials("tipo1");

                    mat2.Rellenar();

                    Console.WriteLine(" material--> "+ mat2.GetMat());
                    Console.ReadLine();
                }
                //Product p = new Product(this.product_type, this.product_name, this.product_units, this.product_unit_price, this.product_description, this.index_pal, this.pal);
                
                //this.products.Add(p);

                x = 0; // indice de palabras a cero, para que comience desde la primera palabra en la siguiente linea
                y++; // aumentamos el indice de linea, para que pase a procesar/leer la siguiente linea del fichero
            }
        }

        public void MostrarInfo(string stock)
        {
            int x = 0;
            string[] lineas = File.ReadAllLines(stock);
            foreach (string lineaA in lineas)
            {
                string[] pFilt = lineaA.Split(';');
                foreach (string palabra in pFilt)
                {
                    if (x == 0)
                    {
                        Console.WriteLine("\n {0}:", palabra);
                    }
                    else
                    {
                        Console.WriteLine("\n      -> {0}", palabra);
                    }
                    x++;
                }
                x = 0;
            }
        }

        public void ShowProducts()
        {
            int x = 0; // indice de tipos de prodctos
            
            int y = 0; // indice de productos

            foreach (Product producto in this.products)
            {
                x = producto.GetProduct_Type();
                switch (x)
                {
                    case 1:
                        Console.WriteLine(" Products Type: PRECIOUS MATERIALS ");
                        Console.WriteLine("   -> {0}:", producto.GetProduct_Name());
                        Console.WriteLine("     - {0}", producto.GetProduct_Units());
                        Console.WriteLine("     - {0}", producto.GetProduct_Price());
                        Console.WriteLine("     - {0}", producto.GetProduct_Description());
                        Console.WriteLine("     - {0}", producto.GetMaterials());
                        //foreach (string matP in producto.GetPreciousMaterialsMat())
                        //{
                        //    Console.WriteLine("     - {0}", matP.GetMat());
                        //    Console.WriteLine("     - {0}", matP.GetPeso());

                        //}
                        break;
                    case 2:
                        Console.WriteLine(" Products Type: FOOD PRODUCTS");
                        Console.WriteLine("   -> {0}:", producto.GetProduct_Name());
                        Console.WriteLine("     - {0}", producto.GetProduct_Units());
                        Console.WriteLine("     - {0}", producto.GetProduct_Price());
                        Console.WriteLine("     - {0}", producto.GetProduct_Description());
                        Console.WriteLine("     - {0}", producto.GetNutri_Info());
                        break;
                    case 3:
                        Console.WriteLine(" Products Type: ELECTRONIC PRODUCTS");
                        Console.WriteLine("   -> {0}:", producto.GetProduct_Name());
                        Console.WriteLine("     - {0}", producto.GetProduct_Units());
                        Console.WriteLine("     - {0}", producto.GetProduct_Price());
                        Console.WriteLine("     - {0}", producto.GetProduct_Description());
                        Console.WriteLine("     - {0}", producto.GetMaterials());
                        Console.WriteLine("     - {0}", producto.GetBattery());
                        Console.WriteLine("     - {0}", producto.GetBattery_Charge());
                        break;
                }
                y++;
            }
        }

        public void AddProduct()
        {
            int option = 0;

            Console.Clear();

            Console.WriteLine("What is the type of the product?: ");
            Console.WriteLine("");
            Console.WriteLine("1. Precious Materials");
            Console.WriteLine("2. Food products");
            Console.WriteLine("3. Electronic Products");
            Console.WriteLine("4. Return");

            option = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (option)
            {
                case 1:
                    PreciousMaterials mat1 = new PreciousMaterials();

                    this.products.Add(mat1); 
                        
                    Console.ReadLine();

                    break;
                case 2:
                    FoodProducts food1 = new FoodProducts();

                    this.products.Add(food1);

                    Console.ReadLine();

                    break;
                case 3:
                    ElectronicProducts elc1 = new ElectronicProducts();

                    this.products.Add(new PreciousMaterials());
                    Console.ReadLine();

                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Type a valid option");
                    Console.ReadLine();
                    break;
            }

            //if ((option != 4))
            //{
            //    //IndividualProductLoading();
            //}
        }

        public void IndividualProductLoading()
        {
            do
            {
                Console.WriteLine("Do you want to restock an existing product(type e) or add a new product(type n)?");
                newProduct = char.Parse(Console.ReadLine());
                if (newProduct == 'e')
                {
                    Console.WriteLine("Which Product would you like to restock?");
                }
                else if (newProduct == 'n')
                {
                    Console.WriteLine("");
                }
                else Console.WriteLine("Type a valid letter"); Console.ReadLine();

            } while (newProduct == 'e' || newProduct == 'n');
        }
    }
}
            
            









