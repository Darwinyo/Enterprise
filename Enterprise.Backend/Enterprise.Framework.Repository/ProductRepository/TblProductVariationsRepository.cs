﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductVariationsRepository : ProductBaseRepository<TblProductVariations>, ITblProductVariationsRepository
    {
        public TblProductVariationsRepository(ProductContext context) : base(context)
        {
        }
    }
}
