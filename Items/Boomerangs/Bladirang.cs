using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class Bladirang : BasicBoomerang
    {

        int numberOfBladirangs;
        int DegreeSeperation;
        public Bladirang()
        {
            this.projectileName = "BladirangProjectile";
            this.shootSpeed = 14f;
            this.damage = 46;
            this.maxProjectiles = 2;

            this.numberOfBladirangs = 2;
            this.DegreeSeperation = 360/numberOfBladirangs;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Big Ole Throwy Blade");
            DisplayName.SetDefault("Bladirang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BreakerBlade, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mouse = Main.MouseWorld;
            Vector2 shootTowards = (mouse - player.Center);

            float RadianSeperation = (float)(DegreeSeperation * Math.PI / 180);

            float baseVelocityRadians = (float)(Math.Atan(shootTowards.Y / shootTowards.X));
            if ((shootTowards.X < 0f && shootTowards.Y > 0f) || (shootTowards.X < 0f && shootTowards.Y < 0f))
            {
                baseVelocityRadians += (float)Math.PI;
            }

            for(int i = 0; i < this.numberOfBladirangs; i++)
            {
                float X_Velocity = (float)(this.shootSpeed * Math.Cos(baseVelocityRadians + RadianSeperation));
                float Y_Velocity = (float)(this.shootSpeed * Math.Sin(baseVelocityRadians + RadianSeperation));

                Projectile.NewProjectile(player.position.X, player.position.Y, X_Velocity, Y_Velocity, mod.ProjectileType(this.projectileName), this.damage, 4f, player.whoAmI);
            }
            return true; //true makes tmod shoot the initial projectile, false makes it not shoot the original projectile

        }
    }
}