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

        private string var6;
        private string var7;
        private string var8;

        // vars para mat precious
        private string materials;
        private string weight;


        // vars para food
        private string nutritional_information;

        // vars para electod prod
        private bool has_battery;
        private bool charged_by_default;

        private char newProduct;

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
                        case 5:
                            this.var6 = palabra;
                            if (this.product_type == 1)
                            {
                                this.materials = this.var6;
                            }else if(this.product_type == 2)
                            {
                                this.nutritional_information = this.var6;
                            }
                            else if(this.product_type == 3)
                            {
                                this.materials = this.var6;
                            }
                            break;
                        case 6:
                            this.var7 = palabra;
                            if(this.product_type == 1)
                            {
                                this.weight = this.var7;
                            }else if (this.product_type == 3)
                            {
                                this.has_battery = bool.Parse(this.var7);
                            }
                            break;
                        case 7:
                            this.var8 = palabra;
                            if (this.product_type == 3)
                            {
                                if (this.has_battery == true) // si tiene bateria miramos si esta cargada o no
                                {
                                    this.charged_by_default = bool.Parse(this.var8); // guardamos en la variable, si la bateria esta cargada o no (1 = si esta cargada, 0 = no esta cargada)
                                }
                            }
                            break;
                    }
                    this.pal = palabra;
                    x++;
                }
                if(this.product_type == 1)
                {
                    //PreciousMaterials mat2 = new PreciousMaterials("tipo1");

                    //mat2.Rellenar();
                    this.products.Add(new PreciousMaterials(this.product_type, this.product_name, this.product_units, this.product_unit_price, this.product_description, this.var6, this.var7));

                }else if(this.product_type == 2)
                {
                    //FoodProducts food2 = new FoodProducts("tipo2");
                    //food2.Rellenar();
                    this.products.Add(new FoodProducts(this.product_type, this.product_name, this.product_units, this.product_unit_price, this.product_description, this.var6));


                }
                else if(this.product_type == 3)
                {
                    //ElectronicProducts elec2 = new ElectronicProducts("tipo3");
                    //elec2.Rellenar();

                    this.products.Add(new ElectronicProducts(this.product_type, this.product_name, this.product_units, this.product_unit_price, this.product_description, this.var6, this.has_battery, this.charged_by_default));
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
                        Console.WriteLine("     - {0}", producto.GetWeight());
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

        public void BuyProducts()
        {
            Console.Clear();
            Console.WriteLine("Available Products:");
            // Display all available products including name, available units, and price
            foreach (var product in products)
            {
                Console.WriteLine($"Type: {product.GetProduct_Type()}, Name: {product.GetProduct_Name()}, Available Units: {product.GetProduct_Units()}, Price: {product.GetProduct_Price()} \n  -> Description: {product.GetProduct_Description()}");
            }

            List<Product> selectedProducts = new List<Product>();

            while (true)
            {
                Console.Write("Enter the name of the product you want to buy (or type 'done' to proceed to payment): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }

                foreach (Product p in products)
                {
                    if (input == p.GetProduct_Name())
                    {
                        selectedProducts.Add(p);
                    }
                }
            }

            // Ask for payment method
            Console.WriteLine("Choose payment method:");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Card");
            Console.Write("Enter your choice: ");
            int paymentMethod = Convert.ToInt32(Console.ReadLine());

            switch (paymentMethod)
            {
                case 1:
                    // Process cash payment
                    ProcessCashPayment(selectedProducts);
                    break;
                case 2:
                    // Process card payment
                    ProcessCardPayment(selectedProducts);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void ProcessCashPayment(List<Product> selectedProducts)
        {
            double totalAmount = 0; // cantidad total a pagar
            foreach (var product in selectedProducts)
            {
                totalAmount += product.GetProduct_Price();
            }
            double paidAmount = 0; // cantidad total de dinero introducido en la maquina por el usuario
            bool succes = false;
            int quitarElemento = 0;

            Console.WriteLine($"Total amount to be paid: {totalAmount}");

            while (paidAmount < totalAmount) // falta dinero por meter para terminar la compra
            {
                Console.Write("Enter the amount paid (or type 'cancel' to cancel the transaction): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "cancel") // en caso de escribir cancel, terminamos con el metodo
                {
                    Console.WriteLine("Transaction canceled.");
                    return;
                }

                try
                {
                    paidAmount += double.Parse(input);
                    Console.WriteLine($"Paid amount: {paidAmount}");

                    if (paidAmount < totalAmount) // si aun el saldo introducido en la maquina no es suficiente para finalizar la compra
                    {
                        Console.WriteLine($"Remaining amount: {totalAmount - paidAmount}");
                    }
                    else if (paidAmount >= totalAmount) // si el saldo ya cumple con el minimo o hay suficiente para realizar la compra
                    {
                        Console.WriteLine($"Change due: {paidAmount - totalAmount}");
                    }
                    succes = true;
                }
                catch (FormatException)
                {
                    // Parsing failed due to invalid format, handle the error or invalid input
                    Console.WriteLine("Invalid input. Please enter a valid amount.");
                }
                finally
                {
                    if (succes != true)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid amount.");

                    }
                }
            }

            Console.WriteLine("Payment successful. Dispensing product(s)...");
            // Update available units for purchased products
            foreach (var product in selectedProducts)
            {
                product.SetEliminarProducto();
            }
            Console.WriteLine("Thank you for your purchase!");
        }


        private void ProcessCardPayment(List<Product> selectedProducts)
        {
            Console.WriteLine("Enter card details:");
            Console.Write("Card number: ");
            string cardNumber = Console.ReadLine();

            Console.Write("Expiration date (MM/YY): ");
            string expirationDate = Console.ReadLine();

            Console.Write("Security code: ");
            string securityCode = Console.ReadLine();

            // Validación de los detalles de la tarjeta (simplificado)
            if (!string.IsNullOrEmpty(cardNumber) && !string.IsNullOrEmpty(expirationDate) && !string.IsNullOrEmpty(securityCode))
            {
                double totalAmount = selectedProducts.Sum(p => p.GetProduct_Price());
                Console.WriteLine($"Total amount to be paid: {totalAmount}");

                // Aquí podrías implementar la lógica para comunicarte con un servicio de procesamiento de pagos
                // y autorizar la transacción con los detalles de la tarjeta proporcionados.

                Console.WriteLine("Card payment successful. Dispensing product(s)...");
                // Actualizar unidades disponibles para los productos comprados
                foreach (var product in selectedProducts)
                {
                    product.SetEliminarProducto();
                }
                Console.WriteLine("Thank you for your purchase!");
            }
            else
            {
                Console.WriteLine("Invalid card details. Payment could not be processed.");
            }
        }
    }
}
            
            









