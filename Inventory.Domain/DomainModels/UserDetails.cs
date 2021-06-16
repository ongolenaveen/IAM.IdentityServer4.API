namespace Inventory.Domain.DomainModels
{
    public class UserDetails
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SubjectId { get; set; }

        public Address Address { get; set; }
    }
}
