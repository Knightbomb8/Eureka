using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class TheDark : BasicBoomerang
    {
        public TheDark()
        {
            this.projectileName = "TheDarkProjectile";
            this.shootSpeed = 13f;
            this.damage = 31;
            this.maxProjectiles = 1;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Dark but X3");
            DisplayName.SetDefault("The Dark");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float DegreeSeperation = 30;
            int numberOfExtraProjectiles = 2;
            int topOrBottom = 1;

            Vector2 mouse = Main.MouseWorld;
            Vector2 shootTowards = (mouse - player.Center);

            float RadianSeperation = (float)(DegreeSeperation * Math.PI / 180);
            float baseVelocityRadians = (float)(Math.Atan(shootTowards.Y / shootTowards.X));
            if ((shootTowards.X < 0f && shootTowards.Y > 0f) || (shootTowards.X < 0f && shootTowards.Y < 0f))
            {
                baseVelocityRadians += (float)Math.PI;
            }

            for(int i = 0; i < numberOfExtraProjectiles; i++)
            {
                float X_Velocity = (float)(this.shootSpeed * Math.Cos(baseVelocityRadians + (RadianSeperation * topOrBottom)));
                float Y_Velocity = (float)(this.shootSpeed * Math.Sin(baseVelocityRadians + (RadianSeperation * topOrBottom)));
                topOrBottom *= -1;

                Projectile.NewProjectile(player.position.X, player.position.Y, X_Velocity, Y_Velocity, mod.ProjectileType("TheDarkProjectileType2"), this.damage, 8f, player.whoAmI);
            }
            return true;
        }
    }
}