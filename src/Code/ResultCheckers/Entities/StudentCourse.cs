//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ark.ResultCheckers.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    
    public partial class StudentCourse : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentCourse()
        {
    		Initialize();
        }
    	partial void Initialize();
    
        [ForeignKey("Session")]
    	[Display(Name = "Session")]
    	public Nullable<int> SessionId { get; set; }
        [ForeignKey("Semester")]
    	[Display(Name = "Semester")]
    	public Nullable<int> SemesterId { get; set; }
        [ForeignKey("Student")]
    	[Display(Name = "Student")]
    	public int StudentId { get; set; }
        [ForeignKey("Course")]
    	[Display(Name = "Course")]
    	public int CourseId { get; set; }
        [Display(Name = "Score")]
    	public double Score { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Session Session { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
