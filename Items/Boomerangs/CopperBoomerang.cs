using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class CopperBoomerang : BasicBoomerang
    {

        public CopperBoomerang()
        {
            this.projectileName = "CopperBoomerangProjectile";
            this.shootSpeed = 8f;
            this.damage = 10;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nrom");
            DisplayName.SetDefault("Copper Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}