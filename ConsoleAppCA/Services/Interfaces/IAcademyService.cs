using ConsoleAppCA.Enums;
using ConsoleAppCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCA.Services.Interfaces
{
    internal interface IAcademyService
    {
        //public static List<Group> Groups { get; set; } 
        public string CreateGroup(GroupCategory category,int no, bool isonline);
        public void CreateStudent(string name,string surname, int no, bool type);
        public void EditGroup(int no,int newNo);
        public void ShowAllGroup();
        public void ShowAllStudent();
        public void ShowAllStudentInGroup(int no);

    }
}
