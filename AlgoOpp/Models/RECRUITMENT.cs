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
    using System.ComponentModel;

    public partial class RECRUITMENT
    {
        [DisplayName("Recruit_id")]
        public int RECRUIT_ID { get; set; }
        [DisplayName("Position")]
        public string POSITION { get; set; }
        [DisplayName("Job Location")]
        public string JOB_LOCATION { get; set; }
        [DisplayName("Skills Required")]
        public string SKILLS_REQ { get; set; }
        [DisplayName("Job Description")]
        public string JOB_DESC { get; set; }
        [DisplayName("Required CGPA")]
        public Nullable<decimal> REQ_CGPA { get; set; }
        [DisplayName("Created Date")]
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        [DisplayName("Created By")]
        public string CREATED_BY { get; set; }
        [DisplayName("Modified Date")]
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        [DisplayName("Modified By")]
        public string MODIFIED_BY { get; set; }
        [DisplayName("Est_id")]
        public Nullable<int> EST_ID { get; set; }
    }
}
