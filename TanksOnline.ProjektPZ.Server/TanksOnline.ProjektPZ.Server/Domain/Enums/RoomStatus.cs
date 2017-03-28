using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Domain.Enums
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
        /// Z jakichś powodów pokój został zamknięty // TODO RK: Trza w sumie ogarnąć jakieś wyjątki czy cóś???
        /// </summary>
        Closed = 3
    }
}