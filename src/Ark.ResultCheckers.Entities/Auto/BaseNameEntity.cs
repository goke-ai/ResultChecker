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
    
    public partial class BaseNameEntity : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseNameEntity()
        {
    		Initialize();
        }
    	partial void Initialize();
    
        [Required(ErrorMessage = "The Name is a mandatory Field.")]
    	[MaxLength(100), StringLength(100, ErrorMessage = "The Name value cannot exceed 100 characters.")]
    	[Display(Name = "Name")]
    	public string Name { get; set; }
    }
}
