using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class GunnerangProjectile : BasicBoomerangProjectile
    {
        int chanceOfBullets;
        int bulletCounter;
        float bulletSpeed;
        public GunnerangProjectile()
        {
            this.maxDistance = 450;
            this.maxSpeed = 8f;
            this.tileCollide = false;

            this.width = 60;
            this.height = 60;
            this.rotationSpeed = .2f;

            this.chanceOfBullets = 3;
            this.bulletCounter = 0;
            this.bulletSpeed = 15f;
        }

        BoomerangMethods boomerMethods = new BoomerangMethods();

        bool newOrigin = true;
        Vector2 origin = Vector2.Zero;

        //how the boomerang acts
        public override void AI()
        {
            Player p = Main.player[projectile.owner];

            if (newOrigin)
            {
                newOrigin = false;
                origin = p.Center;
            }

            boomerMethods.BasicBoomerangMovement(projectile, p, maxSpeed, maxDistance, origin, this.rotationSpeed);

            if (this.dustExists)
            {
                if (Main.rand.Next(this.DustChance) == 0)
                {
                    //                                      location x          location y              width           height                  dust type           can have: velocity x, velocity y
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType(this.dustStyle));
                }
            }
            shootThreeRoundBurst();
            if(this.bulletCounter == 3)
            {
                this.bulletCounter = 0;
            }
        }

        public void shootThreeRoundBurst()
        {
            Player p = Main.player[projectile.owner];
            if(Main.rand.Next(this.chanceOfBullets) == 0 || this.bulletCounter > 0)
            {
                this.bulletCounter += 1;
                Projectile.NewProjectile((float)(projectile.Center.X), (float)(projectile.Center.Y), (float)(this.bulletSpeed * Math.Cos(projectile.rotation)), (float)(this.bulletSpeed * Math.Sin(projectile.rotation)), 287, 35, 0f, p.whoAmI);
            }
        }
    }
}