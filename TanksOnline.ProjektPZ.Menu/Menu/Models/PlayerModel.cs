namespace Menu.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int TankHP { get; set; }
        public UserModel User { get; set; }
        public MatchModel Match { get; set; }
        public int IdInMatch { get; set; }
        public float TurretAngle { get; set; }
    }
}