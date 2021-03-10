using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class IronBoomerang : BasicBoomerang
    {

        public IronBoomerang()
        {
            this.projectileName = "IronBoomerangProjectile";
            this.shootSpeed = 11f;
            this.damage = 16;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nroom");
            DisplayName.SetDefault("Iron Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}