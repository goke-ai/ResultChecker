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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    
    [Owned]
    public partial class File
    {
        public string Uri { get; set; }
        public string Extension { get; set; }
        public string Content { get; set; }
        // public byte[] Content { get; set; }
    }
}
