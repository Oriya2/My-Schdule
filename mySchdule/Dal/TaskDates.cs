//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskDates
    {
        public int code { get; set; }
        public int taskCode { get; set; }
        public System.DateTime dateToFinish { get; set; }
    
        public virtual Tasks Tasks { get; set; }
    }
}
