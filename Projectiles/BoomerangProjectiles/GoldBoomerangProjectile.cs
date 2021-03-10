using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class GoldBoomerangProjectile : BasicBoomerangProjectile
    {
        public GoldBoomerangProjectile()
        {
            this.maxDistance = 500f;
            this.maxSpeed = 13f;
        }
    }
}