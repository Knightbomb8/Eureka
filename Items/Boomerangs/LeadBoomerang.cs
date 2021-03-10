using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Eureka.Items.Boomerangs
{
    public class LeadBoomerang : BasicBoomerang
    {

        
        public LeadBoomerang()
        {
            this.projectileName = "LeadBoomerangProjectile";
            this.shootSpeed = 11f;
            this.damage = 16;
        }
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes Nroom");
            DisplayName.SetDefault("Lead Boomerang");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}