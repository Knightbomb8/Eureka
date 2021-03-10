using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class BloodLetterProjectile : BasicBoomerangProjectile
    {

        public BloodLetterProjectile()
        {
            this.maxDistance = 500f;
            this.maxSpeed = 13f;

            this.dustExists = true;
            this.DustChance = 2;
            this.dustStyle = "BloodLetterDust";
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(projectile.tileCollide)
            {
                int healingAmount = (int)(damage * .18); //LifeSteal
                Main.player[projectile.owner].statLife += healingAmount;
                Main.player[projectile.owner].HealEffect(healingAmount, true);
            }
            projectile.velocity *= -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
    }
}