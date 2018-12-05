using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightFinder.Core.Domain
{
    [Table("State")]
    public class State
    {
        public State()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
