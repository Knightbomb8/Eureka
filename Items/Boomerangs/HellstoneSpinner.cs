using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eureka.Items.Boomerangs

{

    public class HellstoneSpinner : ModItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gotta spin fast");
            DisplayName.SetDefault("Hellstone Spinner");
        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.melee = true;
            item.width = 42;
            item.height = 30;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HellstoneSpinnerProjectile");
            item.shootSpeed = 6.3f;
            item.noUseGraphic = true;
            item.maxStack = 1;
        }

        public override bool CanUseItem(Player player)
        {
            int projectilesOut = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    projectilesOut += 1;
                    if (projectilesOut > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemonScythe, 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}