namespace TanksOnline.ProjectPZ.HttpListener.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int TankHP { get; set; }
        public UserModel User { get; set; }
        public MatchModel Match { get; set; }
        /// <summary>
        /// Specjalne ID w danej rozgrywce. Określa kolejność graczy
        /// </summary>
        public int IdInMatch { get; set; }
        public float TurretAngle { get; set; }
    }
}