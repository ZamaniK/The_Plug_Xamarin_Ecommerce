﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThePlug.Models
{
    public class TrendingProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;
    }
}
