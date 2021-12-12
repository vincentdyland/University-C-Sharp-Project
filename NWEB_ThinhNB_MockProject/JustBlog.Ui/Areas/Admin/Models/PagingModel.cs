﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBlog.Ui.Areas.Admin.Models
{
    public class PagingModel
    {
        public int currentpage { get; set; }
        public int countpages { get; set; }

        public Func<int?, string> generateUrl { get; set; }
    }
}