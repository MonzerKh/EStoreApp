namespace EStoreWebApi.AppCore.Entities
{
    public class User : BaseEntity<int>
    {
        public string Fistname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    
    }
}
