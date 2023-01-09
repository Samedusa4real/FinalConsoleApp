using ConsoleAppCA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCA.Models
{
    internal class Group
    {
        public int No { get; set; }
        public bool IsOnline { get; set; }
        public int Limit { get; set; }
        public GroupCategory Category { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public Group(GroupCategory category,int no,bool isonline)
        {
            //No = $"{category.ToString().Substring(0,1)}{no}";
            Category = category;
            this.No = no;
            IsOnline = isonline;

            if (isonline == true)
            {
                Limit = 15;
            }
            else
            {
                Limit = 10;
            }
        }


        public override string ToString()
        {
            return $"groupno: {Category.ToString().Substring(0, 1)}-{No}, Online olma statusu: {IsOnline}";
        }

    }
}
