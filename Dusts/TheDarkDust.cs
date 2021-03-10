using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Dusts
{
    public class TheDarkDust : BasicDust
    {
        public TheDarkDust()
        {
            this.width = 5;
            this.height = 5;
            this.DustStyles = 1;
        }
    }
}