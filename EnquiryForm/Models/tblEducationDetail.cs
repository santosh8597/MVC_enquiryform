//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnquiryForm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEducationDetail
    {
        public int Education_id { get; set; }
        public Nullable<int> Candidate_id { get; set; }
        public string University { get; set; }
        public Nullable<int> Passing_year { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public string SpecilazationCourse { get; set; }
        public string Medium { get; set; }
        public Nullable<double> Percentage { get; set; }
        public string Institute_name { get; set; }
    
        public virtual tblCandidateDetail tblCandidateDetail { get; set; }
    }
}
