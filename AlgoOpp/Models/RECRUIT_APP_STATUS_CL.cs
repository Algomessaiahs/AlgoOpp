//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlgoOpp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RECRUIT_APP_STATUS_CL
    {
        public int NOTIFY_ID { get; set; }
        public Nullable<int> EST_ID { get; set; }
        public string EST_NAME { get; set; }
        public string POSITION { get; set; }
        public string JOB_LOCATION { get; set; }
        public string JOB_DESC { get; set; }
        public string SKILLS_REQ { get; set; }
        public Nullable<decimal> REQ_CGPA { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<System.DateTime> APPLIED_DATE { get; set; }
        public string APP_STATUS { get; set; }
        public Nullable<int> RECRUIT_ID { get; set; }
    }
}
