﻿using System;
using System.Collections.Generic;
using System.Linq;
using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication
{
    public class SalesEngine : ISalesEngine
    {
        private readonly IEnumerable<Lazy<IProductRecommender, ProductRecommenderMetadata>> _recommenders;

        public SalesEngine(IEnumerable<Lazy<IProductRecommender, ProductRecommenderMetadata>> recommenders)
        {

            _recommenders = recommenders;
        }

        public Product Recommend(SalesMode salesMode, Customer customer)
        {
            return _recommenders.FirstOrDefault(e => e.Metadata.SalesMode == salesMode).Value.Recommend(customer);
        }
    }
}