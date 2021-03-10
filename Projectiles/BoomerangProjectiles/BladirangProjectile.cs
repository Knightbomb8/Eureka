using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class BladirangProjectile : BasicBoomerangProjectile
    {
        public BladirangProjectile()
        {
            this.maxDistance = 500;
            this.maxSpeed = 14f;
            this.width = 49;
            this.height = 56;
            this.tileCollide = false;
            this.light = 2f;
            this.penetrate = 3;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)  //checks to see when it can only penetrate one more, it then returns the item home when 0 left to hit
        {
            if(projectile.penetrate == 1) 
            {   
                projectile.penetrate = -1;
                if(!projectile.ignoreWater)
                {
                    projectile.velocity *= -1;
                }
                projectile.ignoreWater = true;
                projectile.tileCollide = false;
            }
        }
    }
}