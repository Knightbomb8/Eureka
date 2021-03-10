using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class BasicBoomerangProjectile : ModProjectile
    {
        public int width; //setting the dimensions
        public int height;
        public float rotationSpeed;

        public float maxSpeed;//match this with the items shootSpeed
        public float maxDistance;
        public float light;
        public int penetrate;

        public bool dustExists; //the dusts variables
        public int DustChance;
        public string dustStyle;

        public bool tileCollide;

        public BasicBoomerangProjectile()
        {
            this.width = 16;
            this.height = 30;
            this.rotationSpeed = .35f;

            this.maxSpeed = 11f;
            this.maxDistance = 500f;
            this.light = 0f;
            this.penetrate = -1;

            this.dustExists = false;
            this.DustChance = 0;
            this.dustStyle = "";

            this.tileCollide = true;
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = this.width;//
            projectile.height = this.height;//
            projectile.scale = 1f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = false;
            projectile.penetrate = this.penetrate;
            projectile.tileCollide = this.tileCollide;
            projectile.timeLeft = 1000;
            projectile.light = this.light;
            projectile.knockBack = 7.95f;//
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

            if(this.dustExists)
            {
                if (Main.rand.Next(this.DustChance) == 0)
                {
                    //                                      location x          location y              width           height                  dust type           can have: velocity x, velocity y
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType(this.dustStyle));
                }
            }
        }

        //what we do when hitting a block
        public override bool OnTileCollide(Vector2 velocityChange)
        {
            if (projectile.velocity.X != velocityChange.X)
            {
                projectile.velocity.X = -velocityChange.X;
            }
            if (projectile.velocity.Y != velocityChange.Y)
            {
                projectile.velocity.Y = -velocityChange.Y;
            }
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            return false;
        }

        // what we do when hitting an npc
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(!projectile.ignoreWater)
            {
                projectile.velocity *= -1;
            }
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
    }
}