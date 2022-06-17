namespace API.Entites
{
    public class AppUser
    {
        public int id { get; set; }
        
        public string UserName { get; set; }

        public byte[] PasswordHash{get;set;} //hash
        public byte[] PasswordSelt{get;set;} //key

  
    }
}