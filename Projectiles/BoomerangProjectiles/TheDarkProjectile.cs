using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class TheDarkProjectile : BasicBoomerangProjectile
    {
        public TheDarkProjectile()
        {
            this.maxDistance = 500f;
            this.maxSpeed = 13f;

            this.dustExists = true;
            this.DustChance = 2;
            this.dustStyle = "TheDarkDust";
        }
    }
}