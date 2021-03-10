using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{

    public class LumirangProjectileType2 : ModProjectile
    {

        BoomerangMethods boomMethods = new BoomerangMethods();

        float maxSpeed = 10f;
        float MaxDistance = 350f;

        int numberOfFrames = 8; //total nubmer of frames
        int ticksPerFrame = 4; //60 ticks a second

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 25;
            projectile.height = 25;
            projectile.scale = 1f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 200;
            projectile.light = 0f;
            projectile.alpha = 255;

        }
        
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = numberOfFrames; 
        }

        public override void AI()
        {

            //makes projectile slowly come int0 view
            if(projectile.alpha > 0)
            {
                projectile.alpha -= 10;

                if(projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
            }

            if (++projectile.frameCounter >= ticksPerFrame) //change this number to change rate of change of frames
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= numberOfFrames) //how many frames go here
                {
                    projectile.frame = 0;
                }
            }

            if (Main.rand.Next(10) == 0)
            {
                int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("LumirangDust"));
            }

            boomMethods.GoToNearestEnemy(MaxDistance, projectile, maxSpeed);

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.timeLeft = 0;
        }

    }

}