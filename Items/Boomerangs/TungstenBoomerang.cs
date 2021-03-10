using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Eureka.Items.Boomerangs
{
    public class TungstenBoomerang : BasicBoomerang
    {

        
        public TungstenBoomerang()
        {
            this.projectileName = "TungstenBoomerangProjectile";
            this.shootSpeed = 12f;
            this.damage = 21;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nrooom");
            DisplayName.SetDefault("Tungsten Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}