namespace ModelCPro.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credential")]
    public partial class Credential
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string UserGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RoleID { get; set; }
    }
}
