//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBS.Models.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Kullanıcılar
    {
        [Display(Name ="Kullanıcı No")]
        public string k_no { get; set; }
        public string k_sifre { get; set; }
        [Display(Name ="Kullanıcı Seviye")]
        public string k_seviye { get; set; }
    }
}
