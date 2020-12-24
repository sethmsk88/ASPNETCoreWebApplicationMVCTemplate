using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.ViewModels
{
    public class StudentEditViewModel : StudentCreateViewModel
    {
        public int StudentId { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
