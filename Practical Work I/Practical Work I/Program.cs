using System;

namespace PWI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string path = "stock.txt";

            VendingMachine v = new VendingMachine();

            v.LeerFile(path);

            v.ShowProducts();

            Console.ReadLine();

            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("         |------------------------------------|");
                Console.WriteLine("         ||||||||  UFV Vending Machine ||||||||");
                Console.WriteLine("         |------------------------------------|");
                Console.WriteLine("         |                                    |");
                Console.WriteLine("         |   Choose an option:                |");
                Console.WriteLine("         |   1. Buy products.                 |");
                Console.WriteLine("         |   2. Show product info.            |");
                Console.WriteLine("         |   3. Individual product loading.   |");
                Console.WriteLine("         |   4. Full product loading.         |");
                Console.WriteLine("         |   5. Exit.                         |");
                Console.WriteLine("         |                                    |");
                Console.WriteLine("         |------------------------------------|");
                Console.WriteLine("         ||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("         |------------------------------------|");
                Console.WriteLine();



                Console.WriteLine("Choose your option: ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();

                int passwd = 0;


                switch (option)
                {

                    case 1:
                        Console.WriteLine("Buy products ");
                        v.ShowProducts();
                        Console.ReadLine();

                        break;
                    case 2:

                        Console.WriteLine("Product info: ");
                        Console.ReadLine();

                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Enter admin secret key: ");
                            passwd = int.Parse(Console.ReadLine());

                            if (passwd == 1234)
                            {
                                v.AddProduct();
                            
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Incorrect key, press enter to return to menu");
                                Console.ReadLine() ;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadKey();
                        }

                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter admin secret key: ");
                            passwd = int.Parse(Console.ReadLine());

                            if (passwd == 1234)
                            {
                                Console.WriteLine("Full Product loading: ");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Incorrect key, press enter to return to de menu");
                                Console.ReadLine();

                            }
                        }catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadKey();
                        }
                         break;
                    case 5:
                        break;

                        break;
                    default:
                        Console.WriteLine("Please choose an option between 1 and 5");
                        Console.ReadLine();
                        break;
                }
            } while (option != 5);
        }
    }
}
