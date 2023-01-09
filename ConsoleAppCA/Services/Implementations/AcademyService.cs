using ConsoleAppCA.Enums;
using ConsoleAppCA.Models;
using ConsoleAppCA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCA.Services.Implementations
{
    internal class AcademyService : IAcademyService
    {
        public List<Group> Groups { get ; set ; } = new List<Group>();


     // public List<Student> Students { get ; set ; } = new List<Student>();

        public string CreateGroup(GroupCategory category, int no, bool isonline)
        {
            if(no < 100 && isonline == null)
            {
                Console.WriteLine("grup id'si 100den boyuk olmalidir, tehsilin statusu qeyd edilmelidir!");
                Console.WriteLine("       ");
                Console.WriteLine("       ");
            }

            Group group = new Group(category, no, isonline);
            Groups.Add(group);
            return $"{group.Category.ToString().Substring(0, 1)}{group.No} yaradildi!";
            Console.WriteLine("          ");
            Console.WriteLine("          ");
        }

        public void CreateStudent(string name, string surname, int no,bool type)
        {
            foreach(Group group in Groups)
            {
                if(group.Limit < Groups.Count)
                {
                    Console.WriteLine("Grup limiti kecib!");
                    Console.WriteLine("     ");
                    Console.WriteLine("     ");
                }
                else
                {
                    if(no == group.No)
                    {
                        Student student = new Student(name, surname, no, type);
                        group.Students.Add(student);
                        Console.WriteLine("Sagird elave olundu!");
                        Console.WriteLine("          ");
                        Console.WriteLine("          ");
                    }
                    else
                    {
                        Console.WriteLine("Grup nomresini duzgun daxil edin!");
                        Console.WriteLine("         ");
                        Console.WriteLine("         ");
                    }
                }
            }
        }

        public void EditGroup(int no, int newNo)
        {
            foreach (Group group in Groups)
            {
                if (no == group.No)
                {
                    group.No = newNo;
                }
                else
                {
                    Console.WriteLine("Bu nomrede qrup tapilmadi!");
                    Console.WriteLine("          ");
                    Console.WriteLine("          ");
                }
            }
        }


        public void ShowAllGroup()
        {
            foreach(Group group in Groups)
            {
                Console.WriteLine(group);
            }
        }



        public void ShowAllStudent()
        {
            if (Groups.Count != 0)
            {
                foreach (Group group in Groups)
                {
                    if (group.Students.Count != 0)
                    {
                        foreach(Student student in group.Students)
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bele sagird tapilmadi!");
                        Console.WriteLine("        ");
                        Console.WriteLine("        ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Bos qrup tapilmadi!");
                Console.WriteLine("           ");
                Console.WriteLine("           ");
            }
        }

        public void ShowAllStudentInGroup(int no)
        {
            foreach (Group group in Groups)
            {
                if (group.No == no)
                {
                    if (group.Students.Count != 0)
                    {
                        foreach (Student student in group.Students)
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bele sagird tapilmadi!");
                        Console.WriteLine("           ");
                        Console.WriteLine("           ");
                    }
                }
                else
                {
                    Console.WriteLine("Qrup nomresini duzgun daxil edin!");
                    Console.WriteLine("           ");
                    Console.WriteLine("           ");
                }
            }
        }


    }
}


        //public string CreateStudent(string name, string surname, string no)
        //{
        //    foreach(Group groups in Groups)
        //    {
        //        if(groups.No.ToLower().Trim() == no.ToLower().Trim())
        //        {
        //            Student student = new Student(name,surname,no);
        //            Students.Add(student);
        //            return $"Student yaradildi!";
        //        }
        //    }

        //    return $"Sehv melumatlar!";
      