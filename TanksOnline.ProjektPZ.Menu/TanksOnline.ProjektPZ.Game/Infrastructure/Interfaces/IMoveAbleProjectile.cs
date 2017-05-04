using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Infrastructure.Interfaces
{
    public interface IMoveAbleProjectile
    {
        /// <summary>
        /// Aktualna pozycja pocisku
        /// </summary>
        SFML.System.Vector2f Position { get; set; }
        /// <summary>
        /// Kąt początkowy
        /// </summary>
        float Angle { get; }
        /// <summary>
        /// Szybkość początkowa pocisku
        /// </summary>
        float Speed { get; }
        /// <summary>
        /// Siła oporu powietrza
        /// </summary>
        float AirForce { get; }
        /// <summary>
        /// Czas na starcie
        /// </summary>
        float Time { get; set; }
        /// <summary>
        /// Masa pocisku
        /// </summary>
        float Mass { get; }
        /// <summary>
        /// Siła grawitacji (musi być ujemna)
        /// </summary>
        float Gravity { get; }
    }
}
