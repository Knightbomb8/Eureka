using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eureka.Projectiles
{

    public class HellstoneSpinnerProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 50;
            projectile.height = 50;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;
            projectile.light = 1f;
        }

        double deg = 0;
        double distanceFromChar = 100;
        float speed = 8f;
        public override void AI()
        {
                                        
            projectile.rotation += 0.2f;

            bool target = false;
            Vector2 move = Vector2.Zero;
            float distance = 400f;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                {
                    Vector2 newMove = Main.npc[i].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            Player p = Main.player[projectile.owner];
            if (deg != 360) { deg += .1; }
            else { deg = 0; }

            //if spinning around player and not chasing the target
            if (!target)
            {

                move.X = (float)(p.Center.X - projectile.Center.X - distanceFromChar * Math.Cos(deg));
                move.Y = (float)(p.Center.Y - projectile.Center.Y - distanceFromChar * Math.Sin(deg));
            }
            if (Math.Sqrt(move.X * move.X + move.Y * move.Y) < 5)
            {
                speed = 2f;
            }
            else { speed = 8f; }
            projectile.velocity.X = projectile.velocity.X + move.X;
            projectile.velocity.Y = projectile.velocity.Y + move.Y;
            float scale = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            projectile.velocity.X = speed * projectile.velocity.X / scale;
            projectile.velocity.Y = speed * projectile.velocity.Y / scale;

            if(Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("HellstoneSpinnerDust"));
            }

        }

    }

}