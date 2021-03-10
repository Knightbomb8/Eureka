using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eureka.Projectiles.GrenadeProjectiles
{
    public class BlackHoleGrenadeProjectile : ModProjectile
    {
        private float maxDistance, maxSpeed;

        bool hasExploded, itemsUp;

        int explosionRadius, itemNumber;

        float speed;

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            hasExploded = false;
            itemsUp = false;

            projectile.width = 20;
            projectile.height = 20;

            projectile.friendly = true;
            projectile.tileCollide = false;
            
            // 5 second fuse.
			projectile.timeLeft = 500;

            this.maxSpeed = 10f;
            this.maxDistance = 200f;

            //sets explosion radius and makes an array to hold all tiles in that explosion
            explosionRadius = 15;

            speed = 5f;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            //changes the frame of the projectile every 5 ticks
            if (++projectile.frameCounter >= 5) //change this number to change rate of change of frames
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 15)
                {
                    projectile.frame = 0;
                }
            }

            //check explosion based on time left
            if(projectile.timeLeft < 400  && !hasExploded)
            {
                hasExploded = true;

                //shows bounds of explosion
                //each block is 16 pixels wide and tall
                int minX = (int)(projectile.position.X / 16f - (float)explosionRadius);
                int maxX = (int)(projectile.position.X / 16f + (float)explosionRadius);
                int minY = (int)(projectile.position.Y / 16f - (float)explosionRadius);
                int maxY = (int)(projectile.position.Y / 16f + (float)explosionRadius);

                //if we are at either edge of the world, set the min and max to 0 or maximum world size
                if (minX < 0) {
					minX = 0;
				}
				if (maxX > Main.maxTilesX) {
					maxX = Main.maxTilesX;
				}
				if (minY < 0) {
					minY = 0;
				}
				if (maxY > Main.maxTilesY) {
					maxY = Main.maxTilesY;
				}
                
                //Main.NewText(minX + " " + minY);
                //Main.NewText(maxX + " " + maxY);
                //Main.NewText(projectile.position.X/16f + " " + projectile.position.Y/16f);

                for(int x = minX; x <= maxX; x++)
                {
                    for(int y = minY; y <= maxY; y++)
                    {
                        //determines whether or not the player is within the radius of our explosion as our bonds create a square
                        float diffX = Math.Abs((float)x - projectile.position.X / 16f);
						float diffY = Math.Abs((float)y - projectile.position.Y / 16f);
						double distanceTo = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                        if(distanceTo <= explosionRadius)
                        {
                            bool canKillTile = true;

                            //if the tile is explodable or not
                            if (!TileLoader.CanExplode(x, y)) 
                            {
								canKillTile = false;
							}

                            if(canKillTile)
                            {
                                //what is going on here
                                WorldGen.KillTile(x, y, false, false, false);
                                if (!Main.tile[x, y].active() && Main.netMode != 0) 
                                {
									NetMessage.SendData(17, -1, -1, null, 0, (float)x, (float)y, 0f, 0, 0, 0);
								}
                            }
                        }
                    }
                }
            }

            if(hasExploded)
            {
                itemsUp = true;
                int itemsLength = Main.item.Length;
                //how far the pull reach is
                float pullRadius = (float)(explosionRadius * 2.5);

                //iterates through every item in the world and tries to attract it
                for(int i = 0; i < itemsLength; i++)
                {
                    float xDiff = (float)(Main.item[i].position.X/16f - projectile.position.X/16f);
                    float yDiff = (float)(Main.item[i].position.Y/16f - projectile.position.Y/16f);
                    double distanceToo = Math.Sqrt((double)(xDiff * xDiff + yDiff * yDiff));
                    if(distanceToo < pullRadius)
                    {
                        //determines the strength of the pull on an item
                        float rad, radAhead, gravity, moveX, moveY, normalizeScale;

                        //figure out the current degree to the item from the center of our object
                        if(xDiff < 0)
                        {
                            rad = (float)(Math.Atan(yDiff / xDiff) + Math.PI);
                        }
                        else if(yDiff > 0)
                        {
                            rad = (float)(Math.Atan(yDiff / xDiff));
                        }
                        else
                        {
                            rad = (float)(Math.Atan(yDiff / xDiff) + Math.PI * 2f);
                        }

                        radAhead = (float)(rad + 90f);                    

                        moveX = (float)((projectile.Center.X - 0) - Main.item[i].position.X - Math.Pow(speed, 2) * Math.Max(distanceToo, 2) * Math.Cos(radAhead));
                        moveY = (float)((projectile.Center.Y + 3) - Main.item[i].position.Y - Math.Pow(speed, 2) * distanceToo * Math.Sin(radAhead));

                        Main.item[i].velocity.X += moveX;
                        Main.item[i].velocity.Y += moveY;

                        normalizeScale = (float)(Math.Sqrt(Main.item[i].velocity.X * Main.item[i].velocity.X + Main.item[i].velocity.Y * Main.item[i].velocity.Y));

                        Main.item[i].velocity.X *= speed / normalizeScale;
                        Main.item[i].velocity.Y *= speed / normalizeScale;
                    }
                }
            }

            //below this line is the movement control for the projectile

            float slowDown = (float)(maxDistance * .15);
            //slows down projectile's horizontal movement until it is less than one, then completely stops it
            if(projectile.velocity.X > .2f || projectile.velocity.X < -.2f)
            {
                projectile.velocity.X -= (float)((1 * maxSpeed / slowDown) * (Math.Abs(projectile.velocity.X) / projectile.velocity.X));
            }
            else
            {
                projectile.velocity.X = 0f;
            }

            //slows down projectile's vertical movement until it is less than one, then completely stops it
            if(projectile.velocity.Y > .2f || projectile.velocity.Y < -.2f)
            {
                projectile.velocity.Y -= (float)((1 * maxSpeed / slowDown) * (Math.Abs(projectile.velocity.Y) / projectile.velocity.Y));
            }
            else
            {
                projectile.velocity.Y = 0f;
            }
        }
    }
}