using System.ComponentModel.DataAnnotations;

namespace odata_poc.Entities {
    public class SystemInterface {
        [Key]
        public int SystemInterfaceId {get; set;}

        [StringLength(145)]
        [Required]
        public string InterfaceName {get; set;}

        public virtual FnmaSystem FnmaSystem {get; set;}

        public int FnmaSystemId {get; set;}
    }
}