using System;

namespace HM6_Class_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            string countint;
            int counts;
            bool bookcheck = false;
            Library library = new Library();
            library.Books = new Book[0];
            do
            {
                if (bookcheck)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Serti düzgün oxuyun!!!!");
                    Console.WriteLine("------------------------");

                }
                Console.WriteLine("Daxil edilecek kitablarin ümumi sayini qeyd edin:");
                countint = Console.ReadLine();
                counts = Convert.ToInt32(countint);
                bookcheck = true;
            } while (counts <= 0);

            if (counts > 0)
            {
                bool check = false;

                for (int i = 0; i < counts; i++)
                {
                    Console.WriteLine("================================================");
                    Console.WriteLine($"{i + 1}.kitabin melumatlarini daxil edin:");
                    Console.WriteLine("================================================");


                    int no = getInputInt("No", 0);
                    string name = getInputStr("Name", 1, 50);
                    string genre = getInputStr("Genre", 3, 20);
                    double price = getInputDouble("Price", 0);
                    int count = getInputInt("Count", 0);

                    int no2;
                    string name2;
                    string genre2;
                    double price2;
                    int count2;

                    if (check)
                    {
                        bool cheks = false;
                        for (int a = 0; a < library.Books.Length; a++)
                        {
                            for (int b = 0; b < library.Books.Length; b++)
                            {
                                if (library.Books[b].No == no)
                                {
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine($"No-{no} deyerinde bir kitab siyahida var");
                                    Console.WriteLine("Zehmet olmasa siyahida olmayan No-deyerli kitab elave edin!");
                                    Console.WriteLine("------------------------------------------------");
                                    no2 = getInputInt("No", 0);
                                    name2 = getInputStr("Name", 1, 50);
                                    genre2 = getInputStr("Genre", 3, 20);
                                    price2 = getInputDouble("Price", 0);
                                    count2 = getInputInt("Count", 0);

                                    no = no2;
                                    name = name2;
                                    genre = genre2;
                                    price = price2;
                                    count = count2;
                                    cheks = false;
                                    b = b - 1;
                                    continue;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (cheks == false)
                            {
                                Book book = new Book(genre, no, name, price)
                                {
                                    Count = count
                                };
                                library.addBook(book);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Book book = new Book(genre, no, name, price)
                        {
                            Count = count
                        };
                        library.addBook(book);
                        check = true;

                    }
                }

            }
            bool answercheck = false;
            string answer;
            do
            {
                if (answercheck)
                {
                    Console.WriteLine("Zehmet olmasa serti düzgün oxuyun!!!!");
                }
                Console.WriteLine("Filterlemek isteyirsinizmi? Seçim:(y,n)");
                answer = Console.ReadLine();
                answercheck = true;


            } while (answer != "y" && answer != "n");


            int answer1;
            string answer1str;

            if (answer == "y")
            {

                bool answer1check = false;
                do
                {
                    if (answer1check)
                    {
                        Console.WriteLine("Zehmet olmasa serti düzgün oxuyun!!!!");
                    }
                    Console.WriteLine("Kitablari neye  göre axtaris etmek isterdiniz?  Seçim: 1-(Genre adina gore), Seçim: 2 - (Qiymet intervalina gore)");
                    answer1str = Console.ReadLine();
                    answer1 = Convert.ToInt32(answer1str);
                    answer1check = true;
                } while (answer1 != 1 && answer1 != 2);

                string answergenre;

                if (answer1 == 1)
                {
                    Console.WriteLine("Kitabin Genre-sini daxil edin:");
                    answergenre = Console.ReadLine();
                    var filterGenreBook = library.GetFilteredBook(library.Books, answergenre);

                    Console.WriteLine("-----------Genre adina gore kitablar---------");
                    foreach (var books in filterGenreBook)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine($"No-{books.No} Name-{books.Name} Genre-{books.Genre} Price-{books.Price} Count-{books.Count}");
                        Console.WriteLine("---------------------------------------------");

                    }
                }

                else if (answer1 == 2)
                {
                    Console.WriteLine("MaxPrice deyerin daxil edin:");
                    string maxPriceStr = Console.ReadLine();
                    int maxPrice = Convert.ToInt32(maxPriceStr);

                    Console.WriteLine("MinPrice deyerin daxil edin:");
                    string minPriceStr = Console.ReadLine();
                    int minPrice = Convert.ToInt32(minPriceStr);

                    var filterBookPrice = library.GetFilteredBook(library.Books, minPrice, maxPrice);

                    Console.WriteLine("--------Qiymet intervalina gore kitablar---------");
                    foreach (var books in filterBookPrice)
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine($"No-{books.No} Name-{books.Name} Genre-{books.Genre} Price-{books.Price} Count-{books.Count}");
                        Console.WriteLine("-------------------------------------------------");
                    }

                }
            }

            else if (answer == "n")
            {
                Console.WriteLine("Daxil edilmis kitablarin siyahisi:");
                Console.WriteLine("---------------------------------------------");
                foreach (var book in library.Books)
                {
                    Console.WriteLine(book.getInfo());
                }
                Console.WriteLine("---------------------------------------------");


            }

        }

        static string getInputStr(string inputName, int minLength = 0, int maxLength = int.MaxValue)
        {
            string input;
            do
            {
                Console.WriteLine($"{inputName}-deyerin daxil edin:");
                input = Console.ReadLine();
            } while (input.Length <= 1 || input.Length > 50);

            return input;

        }

        static int getInputInt(string inputName, int min = 0, int max = int.MaxValue)
        {
            string inputstr;
            int input;
            do
            {
                Console.WriteLine($"{inputName}-deyerin daxil edin:");
                inputstr = Console.ReadLine();
                input = Convert.ToInt32(inputstr);

            } while (input < 0);

            return input;
        }
        static double getInputDouble(string inputName, int min = 0, int max = int.MaxValue)
        {
            string inputdouble;
            double input;
            do
            {
                Console.WriteLine($"{inputName}-deyerin daxil edin:");
                inputdouble = Console.ReadLine();
                input = Convert.ToDouble(inputdouble);

            } while (input < 0);

            return input;
        }
    }
}
