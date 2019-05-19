using System;
namespace FreightFinder.Core.Domain
{
    public class UserImagePath
    {
        public UserImagePath()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
    }
}
