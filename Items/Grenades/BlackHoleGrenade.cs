using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Eureka.Items.Grenades
{
    public class BlackHoleGrenade : ModItem
    {
        string projectileName;
        float throwSpeed;
        int damage;
        int useAnimation;
        int useTime;
        int reuseDelay;
        int reuseTime;
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Does the depth frighten you?");
            DisplayName.SetDefault("Black Hole Grenade");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 15)); // ticksperframe, frameCount
        }
        
        public BlackHoleGrenade()
        {
            this.projectileName = "BlackHoleGrenadeProjectile";
            this.throwSpeed = 15f;
            this.damage = 0;
            this.useAnimation = 14;
            this.useTime = 14;
            this.reuseTime = 7;
        }

        public override void SetDefaults()
        {
            item.damage = this.damage;//
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = this.useTime;//
            item.useAnimation = this.useAnimation;//
            item.reuseDelay = this.reuseDelay;
            item.useStyle = 1;
            //whether or not this item does damage
            item.noMelee = true;
            item.knockBack = 8f;
            item.value = Item.sellPrice(0, 1, 0, 0);//
            item.rare = 3;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType(this.projectileName);//
            item.shootSpeed = this.throwSpeed;//
            item.noUseGraphic = true;
            item.maxStack = 99;
            item.crit = 0;//
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dynamite, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}