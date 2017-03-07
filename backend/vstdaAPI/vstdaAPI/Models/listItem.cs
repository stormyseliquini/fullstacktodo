using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vstdaAPI.Models
{
    public class listItem
    {
        //primary key
        public int listItemId { get; set; }

        //add aditional columns
        public string Text { get; set; }
        public string PriorityLevel { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}