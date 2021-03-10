using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Eureka.Items.Boomerangs
{
    public class TinBoomerang : BasicBoomerang
    {

        public TinBoomerang()
        {
            this.projectileName = "TinBoomerangProjectile";
            this.shootSpeed = 8f;
            this.damage = 10;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nroom");
            DisplayName.SetDefault("Tin Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}