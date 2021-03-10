using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class IronBoomerangProjectile : BasicBoomerangProjectile
    {
        public IronBoomerangProjectile()
        {
            this.maxDistance = 350;
            this.maxSpeed = 11f;
        }
    }
}