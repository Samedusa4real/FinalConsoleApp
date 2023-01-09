using ConsoleAppCA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppCA.Services.Implementations
{
    internal static class MenuService
    {

        public static AcademyService academy = new AcademyService();

        public static void CreateGroupMenu()
        {
            Console.Clear();
            category:
            Console.WriteLine("Zehmet olmasa ixtisasi secin:");
            Console.WriteLine("              ");
            Console.WriteLine("              ");
            foreach (var category in Enum.GetValues(typeof(GroupCategory)))
            {
                Console.WriteLine((int)category + "-" + category);
            }

            int CategoryLength = Enum.GetValues(typeof(GroupCategory)).Length;

            int.TryParse(Console.ReadLine(), out int CategoryNumber);

            if(CategoryNumber<=0 || CategoryNumber > CategoryLength)
            {
                Console.WriteLine("Categoriyani duzgun secin!");
                Console.WriteLine("        ");
                Console.WriteLine("        ");
                goto category;
            }

            Console.Clear();
            Console.WriteLine("Zehmet olmasa nomreni daxil edin:");
            int.TryParse(Console.ReadLine(), out int groupNo);


            Console.Clear();
            type1:
            Console.WriteLine("Tehsil novunu secin: (1- online; 2- offline)");
            Console.WriteLine("1");
            Console.WriteLine("2");
            int.TryParse(Console.ReadLine(), out int isonline);
            bool type;
            switch (isonline)
            {
                case 1:
                    type = true;
                    break;
                case 2:
                    type = false;
                    break;
                default:
                    Console.WriteLine("Duzgun secin!");
                    Console.WriteLine("         ");
                    Console.WriteLine("         ");
                    goto type1;
            }

             string result = academy.CreateGroup((GroupCategory)CategoryNumber, groupNo, type);

             Console.WriteLine(result);
        }


        public static void CreateStudentMenu()
        {
            Console.Clear();
        fullname:
            string name;
            string surname;
            Console.WriteLine("Sagirdin adini daxil edin:");
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Zehmet olmasa duzgun daxil edin!");
                Console.WriteLine("            ");
                Console.WriteLine("            ");
                goto fullname;
            }

            Console.Clear();

            Console.WriteLine("Sagirdin soyadini daxil edin:");
            try
            {
                surname = Console.ReadLine();
            }
            
            catch (Exception)
            {
                Console.WriteLine("Zehmet olmasa duzgun daxil edin!");
                Console.WriteLine("          ");
                Console.WriteLine("          ");
                goto fullname;
            }

            Console.Clear();

            notype:
            Console.WriteLine("Sagirdin oxudugu qrupu qeyd edin:");
            int.TryParse(Console.ReadLine(), out int no);

            if(academy.Groups.Count != 0)
            {
                foreach (Models.Group group in academy.Groups)
                {
                    if (no == group.No)
                    {
                        Console.WriteLine("Zehmet olmasa tehsil usulunu secin:");
                        Console.WriteLine("1.Zemanetli");
                        Console.WriteLine("2.Zemanetsiz");
                        int.TryParse(Console.ReadLine(), out int type);
                        bool educationType;

                        switch (type)
                        {
                            case 1:
                                educationType = true;
                                break;
                            case 2:
                                educationType = false;
                                break;
                            default:
                                Console.WriteLine("Zehmet olmasa duzgun secin!");
                                Console.WriteLine("           ");
                                Console.WriteLine("           ");
                                goto notype;
                        }

                        academy.CreateStudent(name, surname, no, educationType);

                    }
                    else
                    {
                        Console.WriteLine("Bu nomrede qrup movcud deyil!");
                        Console.WriteLine("           ");
                        Console.WriteLine("           ");
                        goto notype;
                    }
                }
            }
            else
            {
                Console.WriteLine("Bele qrup movcud deyil!");
                Console.WriteLine("           ");
                Console.WriteLine("           ");
            }
            
        }


        public static void EditGroupMenu()
        {
            Console.Clear();

            Console.WriteLine("Deyisiklik elemek istediyiniz grupun nomresini daxil edin:");
            int.TryParse(Console.ReadLine(), out int no);

            Console.Clear();

            Console.WriteLine("Yeni nomreni daxil edin:");
            int.TryParse(Console.ReadLine(), out int newNo);

            if(academy.Groups.Count != 0)
            {
                foreach(Models.Group group in academy.Groups)
                {
                    if (no == group.No)
                    {
                        academy.EditGroup(no, newNo);
                        Console.WriteLine($"Grupun nomresi yenilendi!");
                        Console.WriteLine("         ");
                        Console.WriteLine("         ");
                    }
                    else
                    {
                        Console.WriteLine("Bele qrup movcud deyil!");
                        Console.WriteLine("           ");
                        Console.WriteLine("           ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Bele qrup movcud deyil!");
                Console.WriteLine("            ");
                Console.WriteLine("            ");
            }
        }

        public static void ShowAllGroupMenu()
        {
            Console.Clear();

            if (academy.Groups.Count == 0)
            {
                Console.WriteLine("Hec bir qrup movcud deyil!");
                Console.WriteLine("            ");
                Console.WriteLine("            ");
            }

            else
            {
                Console.WriteLine("Butun qruplarin siyahisi:");
                Console.WriteLine("            ");
                Console.WriteLine("            ");
                academy.ShowAllGroup();
            }
        }

        public static void ShowAllStudentMenu()
        {
            Console.Clear();

            Console.WriteLine("Butun sagirdlerin siyahisi:");
            Console.WriteLine("        ");
            Console.WriteLine("        ");
            Console.WriteLine("        ");
            academy.ShowAllStudent();
        }

        public static void ShowAllStudentInGroupMenu()
        {
            Console.Clear();
        axirki:
            Console.WriteLine("Sagirdlerin siyahisini gormek istediyiniz grupu secin:");
            int.TryParse(Console.ReadLine(), out int no);
            if(academy.Groups.Count != 0)
            {
                foreach(Models.Group group in academy.Groups)
                {
                    if(no == group.No)
                    {
                        Console.Clear();
                        Console.WriteLine($"{no} qrupundaki sagirdler:");
                        Console.WriteLine("      ");
                        academy.ShowAllStudentInGroup(no);
                    }
                    else
                    {
                        Console.WriteLine("Bu nomrede grup movcud deyil!");
                        Console.WriteLine("            ");
                        Console.WriteLine("            ");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Grup movcud deyil!");
                Console.WriteLine("          ");
                Console.WriteLine("          ");
                goto axirki;
            }
        }
    }
}








//public static void CreateStudentMenu()
//{
//    Console.WriteLine("Zehmet olmasa sagirdin adini daxil edin:");
//    string name = Console.ReadLine();
//    Console.WriteLine("Zehmet olmasa soyadi daxil edin:");
//    string surname = Console.ReadLine();
//    Console.WriteLine("Zehmet olmasa oxudugu qrupu secin");
//    string no = Console.ReadLine();

//    academy.CreateStudent(name, surname, no);
//}