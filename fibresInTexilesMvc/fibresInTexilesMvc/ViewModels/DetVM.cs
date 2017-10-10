using fibresInTexilesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fibresInTexilesMvc.ViewModels
{
    public class DetVM
    {
        public string Picture1 { get; set; }
        public string Description { get; set; }
        public string Advantages { get; set; }
        public string Disadvantages { get; set; }
        public string Picture2 { get; set; }

        public string Picture { get; set; }
        public string Name { get; set; }
        public fibre fibre { get; set; }
        public ICollection<product>products { get; set; }
    }
}