using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class SilverBoomerang : BasicBoomerang
    {

        public SilverBoomerang()
        {
            this.projectileName = "SilverBoomerangProjectile";
            this.shootSpeed = 12f;
            this.damage = 21;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nrooom");
            DisplayName.SetDefault("Silver Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}