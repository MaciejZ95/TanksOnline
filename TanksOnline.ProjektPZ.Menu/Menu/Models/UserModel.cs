namespace Menu.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
		public UserStatus status { get; set; }
        public TankInfoModel TankInfo { get; set; }
        public UserScoreModel UserScore { get; set; }
        public string Password { get; set; }
		
		public enum UserStatus
		{
			Offline = 1,
			Logged = 2,
			Waiting = 3,
			Ready = 4,
			InGame = 5,
			Mobile = 6
		}
    }
}
