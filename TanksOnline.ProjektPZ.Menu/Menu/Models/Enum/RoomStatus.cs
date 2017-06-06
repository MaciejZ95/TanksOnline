using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Models.Enum
{
    public enum RoomStatus
    {
        /// <summary>
        /// Oczekiwanie na graczy
        /// </summary>
        Waiting = 1,
        /// <summary>
        /// Wszyscy gracze są gotowi - można przejść do rozgrywki
        /// </summary>
        Ready = 2,
        /// <summary>
        /// Gra została kulturalnie zakończona i rozstrzygnięta
        /// </summary>
        GameEnded = 3,
        /// <summary>
        /// Z jakichś powodów pokój został zamknięty w sposób awaryjny
        /// </summary>
        Closed = 4,
        /// <summary>
        /// Pokój jest pełen
        /// </summary>
        Full = 5,
        /// <summary>
        /// W grze
        /// </summary>
        InGame = 6
    }

}
