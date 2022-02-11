namespace ControlAccounts.Models
{
    public class Account
    {

        public int id { get; set; }

        //public int Identificator { get; set; }

        public string? name { get; set; }

        public string? email{ get; set; }

        public string? password { get; set; }

        public string? role { get; set; }

        public int money { get; set; }

    }

    public enum Role
    {
        User,
        Admin
    }
}
