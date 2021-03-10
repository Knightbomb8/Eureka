using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{
    public class BloodLetter : BasicBoomerang
    {

        public BloodLetter()
        {
            this.projectileName = "BloodLetterProjectile";
            this.shootSpeed = 13f;
            this.damage = 29;
            this.maxProjectiles = 3;

            this.useAnimation = 24; //time your hand is out
            this.useTime = 8; //shouts a projectile every 6 ticks so three total if useAnimation is 18
            this.reuseDelay = 26; //before you can use it again
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Thou Shall Lettith Lifith"
                                + "\n 18% LifeSteal"
                                + "\n Can throw Three at a time");
            DisplayName.SetDefault("BloodLetter");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.TissueSample, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}