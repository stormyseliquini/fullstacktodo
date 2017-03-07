using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using vstdaAPI.Models;

namespace vstdaAPI.data
{
    public class listItemDataContext: DbContext
    {
        public listItemDataContext() : base("itemTable")
        {

        }

        public IDbSet<listItem> listItems { get; set; }
    }
}