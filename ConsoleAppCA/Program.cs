using ConsoleAppCA.Enums;
using ConsoleAppCA.Models;
using ConsoleAppCA.Services.Implementations;
using System.Drawing;

int choose;

do
{
    Console.WriteLine("1.Yeni qrup yaratmaq ucun,");
    Console.WriteLine("2.Yeni telebe yaratmaq ucun,");
    Console.WriteLine("3.Qrupda deyisiklik etmek ucun,");
    Console.WriteLine("4.Butun movcud qruplari gormek ucun,");
    Console.WriteLine("5.Butun telebeleri gormek ucun,");
    Console.WriteLine("6.Gruplardaki sagirdleri gormek ucun,");
    Console.WriteLine("         ");
    Console.WriteLine("         ");
    Console.WriteLine("7.Quit.");

    int.TryParse(Console.ReadLine(), out choose);

    switch (choose)
    {
        case 1:
            MenuService.CreateGroupMenu();
            break;
        case 2:
            MenuService.CreateStudentMenu();
            break;
        case 3:
            MenuService.EditGroupMenu();
            break;
        case 4:
            MenuService.ShowAllGroupMenu();
            break;
        case 5:
            MenuService.ShowAllStudentMenu();
            break;
        case 6:
            MenuService.ShowAllStudentInGroupMenu();
            break;
        case 7:
            Console.Clear();
            Console.WriteLine("Siz cixis etdiniz...");
            return;
        default:
            Console.WriteLine("Duzgun deyer daxil edin!");
            break;
    }
} while (choose != 7);


