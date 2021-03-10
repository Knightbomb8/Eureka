using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace Eureka.Dusts
{
    public class HellstoneSpinnerDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.frame = new Rectangle(0, 0, 10, 10);
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.scale -= 0.01f;
            if (dust.scale < 0.75f)
            {
                dust.active = false;
            }
            return false;
        }            
    }
}