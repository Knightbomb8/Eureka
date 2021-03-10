using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class CopperBoomerangProjectile : BasicBoomerangProjectile
    {
        public CopperBoomerangProjectile()
        {
            this.maxDistance = 275;
            this.maxSpeed = 8f;
        }
    }
}