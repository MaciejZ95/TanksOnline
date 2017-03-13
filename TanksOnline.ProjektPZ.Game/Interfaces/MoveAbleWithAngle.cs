﻿using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Interfaces
{
    public interface MoveAbleWithAngle
    {
        Vector2f Position { get; set; }
        float Angle { get; }
        float Speed { get; }
    }
}
