namespace APIFARM.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash  { get; set; }
        public byte[] Salt { get; set; } = Array.Empty<byte>();
    }
}
