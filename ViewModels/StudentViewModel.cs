//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }
        public byte[] RowVersion { get; set; }
        public string JavascriptToRun { get; set; }

    }
}
