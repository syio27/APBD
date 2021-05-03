using System;

namespace LinqTutorials.Models
{
    public class Dept
    {
        public int Deptno { get; set; }
        public string Dname { get; set; }
        public string Loc { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Dept dept &&
                   Deptno == dept.Deptno &&
                   Dname == dept.Dname &&
                   Loc == dept.Loc;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Deptno, Dname, Loc);
        }

        public override string ToString()
        {
            return $"{Deptno} ({Dname})";
        }
    }
}