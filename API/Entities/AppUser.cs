namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        /// <summary>
        /// /reuired is new feature of C# 11  The default value for reference type is null so thats why we add required
        /// </summary>
        public required string UserName { get; set; }
    }

    
}
