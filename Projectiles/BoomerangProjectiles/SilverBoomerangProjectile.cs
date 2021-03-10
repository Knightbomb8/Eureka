using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class SilverBoomerangProjectile : BasicBoomerangProjectile
    {

        public SilverBoomerangProjectile()
        {
            this.maxDistance = 450f;
            this.maxSpeed = 12f;
        }
    }
}