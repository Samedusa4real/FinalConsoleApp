using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCA.Models
{
    internal class Student
    {
        public string FullName { get; set; }
        public int GroupNo { get; set; }
        public bool Type { get; set; }

        public Student(string name, string surname, int groupno, bool type)
        {
            FullName = name + " " + surname;
            GroupNo = groupno;
            Type = type;
        }

        public override string ToString()
        {
            return $"Sagird: {FullName}, GrupNomresi: {GroupNo}, Zemanetli olma statusu: {Type}";
        }

    }
    
    
}
