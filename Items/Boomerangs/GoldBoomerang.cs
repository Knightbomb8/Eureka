using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class GoldBoomerang : BasicBoomerang
    {

        public GoldBoomerang()
        {
            this.projectileName = "GoldBoomerangProjectile";
            this.shootSpeed = 13f;
            this.damage = 25;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nroooom");
            DisplayName.SetDefault("Gold Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}