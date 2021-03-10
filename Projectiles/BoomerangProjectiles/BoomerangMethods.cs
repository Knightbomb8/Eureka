using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Projectiles.BoomerangProjectiles
{

    public class BoomerangMethods
    {

        public Vector2 mousePosition()
        {
            return Main.MouseWorld;
        }

        public void throwToMouse(Projectile projectile, float maxSpeed)
        {
            Vector2 mouse = mousePosition();
            projectile.velocity = maxSpeed * normalize(mouse - projectile.Center);
        }

        public Vector2 normalize(Vector2 toNormalize)
        {
            float scale = (float)Math.Sqrt(toNormalize.X * toNormalize.X + toNormalize.Y * toNormalize.Y);
            return toNormalize/scale;
        }

        public float distanceTo(Vector2 start, Vector2 end)
        {
            Vector2 distance = end - start;
            return (float)(Math.Sqrt(distance.X * distance.X + distance.Y * distance.Y))  ;
        }

        public float Magnitude(Vector2 findMagnitude)
        {
            return (float)(Math.Sqrt(findMagnitude.X * findMagnitude.X + findMagnitude.Y * findMagnitude.Y));
        }

        public float NormalizeScalar(Vector2 scalarNeeded)
        {
            return (float)(Math.Sqrt(scalarNeeded.X * scalarNeeded.X + scalarNeeded.Y * scalarNeeded.Y));
        }

        public void turnAround(Projectile projectile, Player player, float maxSpeed)
        {
            Vector2 moveTo = normalize(player.Center - projectile.Center);
            projectile.velocity.X += (float)(moveTo.X * .05 * maxSpeed);
            projectile.velocity.Y += (float)(moveTo.Y * .05 * maxSpeed); 
            
        }

        public void homeToLocation(Projectile projectile, Vector2 goTo, float maxSpeed)
        {
            projectile.velocity = normalize(goTo - projectile.Center) * maxSpeed;
        }

        public void GoToNearestEnemy(float MaxDistance, Projectile projectile, float maxSpeed)
        {
            float distance = MaxDistance;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                {
                    float howFar = distanceTo(Main.npc[i].Center, projectile.Center);
                    if (howFar < distance)
                    {
                       homeToLocation(projectile, Main.npc[i].Center, maxSpeed);
                    }
                }
            }
        }






        //this code is much cleaner than what Lumirang uses, do not use it for basic boomerang style reference
        public void BasicBoomerangMovement(Projectile projectile, Player player, float maxSpeed, float maxDistance, Vector2 origin, float rotationSpeed)
        {
            projectile.rotation += rotationSpeed;
            float startSlowDown = (float)(maxDistance * .15);

            if(!projectile.ignoreWater) //ignore water is only true when returning so any time the boomerang is going out it is affected by water but then on return it is not.
            {
                if(distanceTo(origin, projectile.Center) > (maxDistance - (startSlowDown))) 
                {
                    slowDown(startSlowDown, projectile, maxSpeed);
                    //gravity affecting it
                    projectile.position.Y += 1.5f;
                }
                if(Magnitude(projectile.velocity) < (1f)) 
                {
                    projectile.ignoreWater = true;
                    projectile.tileCollide = false; 
                }
            }
            else
            {
                if (distanceTo(projectile.Center, player.Center) < 10) //checks if projectle has returned to player
                {
                    projectile.timeLeft = 0;
                }

                if (Magnitude(projectile.velocity) < (maxSpeed * .9))
                {
                    homeToLocation(projectile, player.Center, (float)(maxSpeed * .025 + Magnitude(projectile.velocity)));
                    projectile.position.Y += 1.5f;
                }
                else
                {
                    homeToLocation(projectile, player.Center, maxSpeed);
                }
            }
        }

        public void slowDown(float slowDown, Projectile projectile, float maxSpeed)
        {
            projectile.velocity.X -= (float)((5 * maxSpeed / slowDown) * (Math.Abs(projectile.velocity.X) / projectile.velocity.X));
            projectile.velocity.Y -= (float)((5 * maxSpeed / slowDown) * (Math.Abs(projectile.velocity.Y) / projectile.velocity.Y));
        }
    }
}