using bbq.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace bbq.Domain.Entities
{
    public sealed class User : Entity
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecretKey { get; set; }
        public override string SearchKey => UserName;
    }
}