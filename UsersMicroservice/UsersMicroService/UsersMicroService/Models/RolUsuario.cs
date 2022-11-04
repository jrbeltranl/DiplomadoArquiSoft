namespace UsersMicroService.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RolUsuario")]
    public partial class RolUsuario
    {
        public int ID { get; set; }

        public int Rol { get; set; }

        public int Usuario { get; set; }
        
        [JsonIgnore]
        public virtual Roles Roles { get; set; }

        [JsonIgnore]
        public virtual Users Users { get; set; }
    }
}
