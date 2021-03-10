using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{
    public class LumirangProjectile : ModProjectile
    {

        float maxDistance = 30; //every ten is basically 1000 in game distance
        float maxSpeed = 35f;

        BoomerangMethods methods = new BoomerangMethods();
        
        Vector2 origin = new Vector2(0, 0);
        bool newOrigin = false;

        int turnAround;

        int timeCounter;

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 40;
            projectile.height = 42;
            projectile.scale = 1f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
            projectile.light = 3f;  
            projectile.knockBack = 8f;          

            BoomerangMethods methods = new BoomerangMethods();

            Player p = Main.player[projectile.owner];
            Vector2 mouse = methods.mousePosition();
            Vector2 throwTo = mouse - projectile.Center;
            projectile.velocity = maxSpeed * methods.normalize(throwTo);

        }            

        public override void AI()
        {
            Player p = Main.player[projectile.owner];
            if (newOrigin)
            {
                newOrigin = false;
                origin = p.Center;
            }

            //changes the frame of the projectile every 5 ticks
            if (++projectile.frameCounter >= 2) //change this number to change rate of change of frames
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 8)
                {
                    projectile.frame = 0;
                }
            }

            if(timeCounter > maxDistance)
            {                
                
                if(turnAround > 18)
                {
                    projectile.tileCollide = false;
                }
                
                if(turnAround < 35)
                {
                    methods.turnAround(projectile, p, maxSpeed);
                    turnAround++;
                }
                else
                {
                    methods.homeToLocation(projectile, p.Center, maxSpeed);
                }
                
                if(methods.distanceTo(p.Center, projectile.Center) < 20)
                {
                    projectile.timeLeft = 0;
                }

            }

            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("LumirangDust"));
            }

            timeCounter ++;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[projectile.owner];
            //Projectile.NewProjectile(Location.X, Location.Y, speed.X, speed.Y, projectile type, damage, knockback, who owns the projectile, ?, ?)
            //                          float       float       float   float     int             int?      int         Player(p.whoAmI)

            int numberOfSpawns = 2 + Main.rand.Next(3);
            float changeInDegrees = (float)(360/numberOfSpawns);
            float degrees = 0;
            float distanceFromCenter = 200;
            float speed = 3;

            for (int i = 0; i < numberOfSpawns; i++)
            {
                float radians = (float)(Math.PI*degrees/180);
                Projectile.NewProjectile(projectile.Center.X + (float)(distanceFromCenter * Math.Sin(radians)), projectile.Center.Y + (float)(distanceFromCenter * Math.Cos(radians)), (float)(speed * Math.Sin(radians)), (float)(speed * Math.Cos(radians)), mod.ProjectileType("LumirangProjectileType2"), (projectile.damage / 2), 1, p.whoAmI);
                degrees += changeInDegrees;
            }
            if(projectile.tileCollide)
            {
                projectile.velocity *= -1;
            }

            //this next chunk spawns a bunch of projectiles to visually register a hit
            float NumberOfProjectiles = 50;
            for(float i = 0; i<360; i = i)
            {
                float radians = (float)(Math.PI * i/180 );
                //                          (Vector 2 of x and y spawn location)                width               height              dust type                   x velocity                  y velocity              
                int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("LumirangDust"), (float)(Math.Sin(radians)), (float)(Math.Cos(radians)));
                i += 360 / NumberOfProjectiles;
            }

            projectile.tileCollide = false;
            timeCounter = (int)maxDistance;
            turnAround = 35;

        }

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
            projectile.tileCollide = false;
            timeCounter = 31;
            return false;
        }

    }
}