using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KargoTakip.DataAccsess.Data.Entity
{
    public class Kargo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(10)]
        [Required]
        public string Name { get; set; }
        [StringLength(10)]
        [Required]
        public string City { get; set; }


    }
}
