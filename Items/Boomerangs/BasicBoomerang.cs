using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class BasicBoomerang : ModItem
    {

        public string projectileName;
        public float shootSpeed;
        public int damage;
        public int maxProjectiles;

        public int useAnimation;
        public int useTime;
        public int reuseDelay;

        public BasicBoomerang()
        {
            this.projectileName = "BasicBoomerangProjectile";
            this.shootSpeed = 11f;
            this.damage = 13; 
            this.maxProjectiles = 1;

            this.useAnimation = 14;
            this.useTime = 14;
            this.reuseDelay = 14;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Item Descrption");
            DisplayName.SetDefault("Item Name");
        }

        public override void SetDefaults()
        {
            item.damage = this.damage;//
            item.melee = true;
            item.width = 16;
            item.height = 30;
            item.useTime = this.useTime;//
            item.useAnimation = this.useAnimation;//
            item.reuseDelay = this.reuseDelay;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 8f;
            item.value = Item.sellPrice(0, 1, 0, 0);//
            item.rare = 1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType(this.projectileName);//
            item.shootSpeed = this.shootSpeed;//
            item.noUseGraphic = true;
            item.maxStack = 1;
            item.crit = 0;//
        }

        public override bool CanUseItem(Player player) //checks if the player can throw another of these items;
        {
            int projectilesOut = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    projectilesOut += 1;
                    if (projectilesOut >= this.maxProjectiles)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //shoots the projectile
        {
            Vector2 mouse = Main.MouseWorld;
            Vector2 shootTowards = (mouse - player.Center);

            float baseVelocityRadians = (float)(Math.Atan(shootTowards.Y / shootTowards.X));
            if ((shootTowards.X < 0f && shootTowards.Y > 0f) || (shootTowards.X < 0f && shootTowards.Y < 0f))
            {
                baseVelocityRadians += (float)Math.PI;
            }

            float X_Velocity = (float)(this.shootSpeed * Math.Cos(baseVelocityRadians));
            float Y_Velocity = (float)(this.shootSpeed * Math.Sin(baseVelocityRadians));
            Projectile.NewProjectile(player.position.X, player.position.Y, X_Velocity, Y_Velocity, mod.ProjectileType(this.projectileName), this.damage, 8f, player.whoAmI);
            return false;
        }
    }
}