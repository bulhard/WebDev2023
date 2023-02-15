using System.Collections.Generic;

namespace _02_Introduction.Models
{
    public class IndexViewModel
    {

        public IndexViewModel()
        {
            Group1 = new List<StudentViewModel>();
            Group2 = new List<StudentViewModel>();
        }

        public List<StudentViewModel> Group1 { get; set; }

        public List<StudentViewModel> Group2 { get; set; } 

        public string PageTitle { get; set; }
    }
}
