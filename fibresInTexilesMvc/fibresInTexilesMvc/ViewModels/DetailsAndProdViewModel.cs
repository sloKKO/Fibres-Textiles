using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fibresInTexilesMvc.Models;

namespace fibresInTexilesMvc.ViewModels
{
    public class DetailsAndProdViewModel
    {

        public virtual fibre fibre { get; set; }
        public virtual IList<product> products { get; set; }

    }
}