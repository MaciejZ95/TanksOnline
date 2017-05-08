using System.Data.Entity.ModelConfiguration;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    public class PlayerPoints
    {
        /// <summary>
        /// Identyfikator gracza
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id gracza w ramach rozgrywki
        /// </summary>
        public int IdInMatch { get; set; }
        /// <summary>
        /// Liczba trafień w przeciwnika
        /// </summary>
        public int DealedHits { get; set; }
        /// <summary>
        /// Liczba trafień, które przyjął gracz
        /// </summary>
        public int HitsTaken { get; set; }
        /// <summary>
        /// Liczba zabitych przeciwników w grze
        /// </summary>
        public int Kills { get; set; }
        /// <summary>
        /// Czy gracz został pokonany w tej grze
        /// </summary>
        public bool Dead { get; set; }
        /// <summary>
        /// Referencja do użytkownika będącego właścicielem danych
        /// </summary>
        public User User { get; set; }
    }

    public class PlayerPointsMappings : EntityTypeConfiguration<PlayerPoints>
    {
        public PlayerPointsMappings()
        {
            HasKey(x => x.Id);
            Property(x => x.IdInMatch).IsRequired();
            Property(x => x.DealedHits).IsRequired();
            Property(x => x.HitsTaken).IsRequired();
            Property(x => x.Kills).IsRequired();
            Property(x => x.Dead).IsRequired();
            HasRequired(x => x.User);
        }
    }
}