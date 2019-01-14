namespace User.Model
{
    public static class UserData
    {
        public static int id { get; set; }
        public static string name { get; set; }
        public static string surname { get; set; }
        public static string email { get; set; }
        public static string phone { get; set; }
        public static string nick { get; set; }
        public static string password { get; set; }
        public static Address address { get; set; }
        public static Question question { get; set; }
        public static string answer { get; set; }
        public static bool active { get; set; }
        public static bool loggedIn { get; set; }
        public static bool admin { get; set; }
        public static bool ableToChangePassword { get; set; }
    }
}