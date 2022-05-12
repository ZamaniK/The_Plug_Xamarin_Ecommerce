﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThePlug.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;
        public IEnumerable<Category> Categories { get; set; }

    }
}
