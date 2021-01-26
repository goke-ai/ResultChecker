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
    
    public partial class BulkStudentCourse : BulkEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BulkStudentCourse()
        {
    		Initialize();
        }
    	partial void Initialize();
    
        [Required(ErrorMessage = "The Session is a mandatory Field.")]
    	[Display(Name = "Session")]
    	public string Session { get; set; }
        [Required(ErrorMessage = "The Semester is a mandatory Field.")]
    	[Display(Name = "Semester")]
    	public string Semester { get; set; }
        [Required(ErrorMessage = "The Code is a mandatory Field.")]
    	[Display(Name = "Code")]
    	public string Code { get; set; }
        [Required(ErrorMessage = "The Matric No is a mandatory Field.")]
    	[Display(Name = "Matric No")]
    	public string MatricNo { get; set; }
        [Display(Name = "Score")]
    	public double Score { get; set; }
    }
}
