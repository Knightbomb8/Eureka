using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class TheDarkProjectileType2 : BasicBoomerangProjectile
    {
        public TheDarkProjectileType2()
        {
            this.maxDistance = 500f;
            this.maxSpeed = 13f;
            this.tileCollide = false;

            this.dustExists = true;
            this.DustChance = 2;
            this.dustStyle = "TheDarkDust";
        }
    }
}