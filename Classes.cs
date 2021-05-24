using AdminLTE.Modelss;
using AdminLTE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE
{
    public class Classes
    {
        IList<StudentViewModel> students = null;
        public IList<StudentViewModel> GetAllStudents()
        {
            using (var ctx = new SchoolDBContext())
            {
                 students = ctx.Student
                            .Select(s => new StudentViewModel()
                            {
                                StudentId = s.StudentId,
                                StudentName = s.StudentName,
                                StandardId = (int)s.StandardId
                            }).ToList<StudentViewModel>();
                return students;

            }
        }
    }
}
