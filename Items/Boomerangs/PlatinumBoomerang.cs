using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Eureka.Items.Boomerangs
{
    public class PlatinumBoomerang : BasicBoomerang
    {

        public PlatinumBoomerang()
        {
            this.projectileName = "PlatinumBoomerangProjectile";
            this.shootSpeed = 13f;
            this.damage = 25;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nroooom");
            DisplayName.SetDefault("Platinum Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}