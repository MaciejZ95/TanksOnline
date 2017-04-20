namespace Menu.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TankInfoModel TankInfo { get; set; }
        public UserScoreModel UserScore { get; set; }
        public string Password { get; set; }
    }
}
