using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject0
{
    /// <summary>
    /// A class representing the fire sprite
    /// </summary>
    public class FireSprite
    {
        private Texture2D texture;

        private double animationTimer;

        private short animationFrame = 1;

        /// <summary>
        /// loads the fire sprite texture
        /// </summary>
        /// <param name="content">the ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("fireSprite");
        }

        /// <summary>
        /// draws the animated fire sprite
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="spriteBatch">the SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            
            //update the animation frame
            if(animationTimer > 0.3)
            {
                animationFrame++;
                if (animationFrame > 4
                    ) animationFrame = 1;
                animationTimer -= 0.3;
            }

            //draw the sprite
            var source = new Rectangle(animationFrame * 64 + 17, 0, 31, 63);
            spriteBatch.Draw(texture, new Vector2(380, 280), source, Color.White);
        }
    }
}
