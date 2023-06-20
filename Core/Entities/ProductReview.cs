﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductReview : BaseEntitiy
    {
        public int ReviewPropsId { get; set; }
        public ReviewProps? ReviewProps { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
