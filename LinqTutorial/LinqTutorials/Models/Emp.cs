using System;
using System.Collections.Generic;

namespace LinqTutorials.Models
{
    public class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int? Deptno { get; set; }
        public Emp Mgr { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Emp emp &&
                   Empno == emp.Empno &&
                   Ename == emp.Ename &&
                   Job == emp.Job &&
                   Salary == emp.Salary &&
                   HireDate == emp.HireDate &&
                   Deptno == emp.Deptno &&
                   EqualityComparer<Emp>.Default.Equals(Mgr, emp.Mgr);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Empno, Ename, Job, Salary, HireDate, Deptno, Mgr);
        }

        public override string ToString()
        {
            return $"{Ename} ({Empno})";
        }

    }
}