using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Boomerangs
{

    public class Lumirang : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The Moon doesn't even spin this fast");
            DisplayName.SetDefault("Lumirang");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8)); // ticksperframe, frameCount
        }

        public override void SetDefaults()
        {
            item.damage = 275;//
            item.melee = true;
            item.width = 0;
            item.height = 0;
            item.useTime = 20;//
            item.useAnimation = 20;//
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 8f;
            item.value = Item.sellPrice(2, 0, 0, 0);
            item.rare = 8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LumirangProjectile");//
            item.shootSpeed = 25f;//
            item.noUseGraphic = true;
            item.maxStack = 1;
            item.crit = 16;//
        }


        public override bool CanUseItem(Player player) //checks if the player can throw another of these items;
        {
            int projectilesOut = 0;
            int maxProjectiles = 30; //max amount that can be out at once
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    projectilesOut += 1;
                    if (projectilesOut >= maxProjectiles)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);//makes a new object
            recipe.AddIngredient(ItemID.LunarBar, 10); //needed items to make your item
            recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddTile(TileID.LunarCraftingStation);//where it needs to be crafted
            recipe.SetResult(this);//sets the recipe to THIS item being whatever item this recipe is in. SO for here it is the lumirang
            recipe.AddRecipe();//adds recipe to the game

        }

    }

}