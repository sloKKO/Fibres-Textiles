using fibresInTexilesMvc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fibresInTexilesMvc.ViewModels
{
    public class FibAndProdViewModel

    {
        public int FiberId { get; set; }
        public string Picture1 { get; set; }
        public string Description { get; set; }
        public string Advantages { get; set; }
        public string Disadvantages { get; set; }
        public string Picture2 { get; set; }

        public string Picture { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<product> Products { get; set; }
      
        public virtual fibre fibre { get; set; }
    }
}