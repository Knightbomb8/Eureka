using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace Eureka.Dusts
{
    public class BasicDust : ModDust
    {

        public int width;
        public int height;
        public int DustStyles;

        public BasicDust()
        {
            this.width = 5;
            this.height = 5;
            this.DustStyles = 1;
        }

        

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            int dustStyle = Main.rand.Next(this.DustStyles);
            dust.frame = new Rectangle(0, this.height * dustStyle, this.height, this.width);
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