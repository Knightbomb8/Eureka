using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class Gunnerang : BasicBoomerang
    {

        public Gunnerang()
        {
            this.projectileName = "GunnerangProjectile";
            this.shootSpeed = 8f;
            this.damage = 21;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Pew Pew Pew");
            DisplayName.SetDefault("Gunnerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}