using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Ballon : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 position;
        private Vector2 speed;

        private float rotation = 0f;
        private Rectangle srcRect;
        private Vector2 origin;
        private Vector2 stage;
        private float scale = 1f;
        private int rectSize = 10;

        public Ballon(Game game, SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            origin = new Vector2(tex.Width / 2, tex.Height / 2);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //v 6
            spriteBatch.Draw(tex, position, srcRect, Color.White, rotation, new Vector2(tex.Width / 2, tex.Height / 2), scale, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            /*
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                Vector2 target = new Vector2(ms.X, ms.Y);
                float xDiff = target.X - position.X;
                float yDiff = target.Y - position.Y;

                //translation
                position.X += xDiff * speed.X * 0.05f;
                position.Y += yDiff * speed.Y * 0.05f;


                //rotation
                float deviation = 0;
                if (xDiff < 0)
                {
                    deviation = (float)Math.PI;
                }


                rotation = deviation + (float)Math.Atan(yDiff / xDiff);
            }
            */


            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        public void sizeUp()
        {
            scale = (float)((double)scale * 1.1);
            rectSize = rectSize + (int)(rectSize / 2);
        }
    }
}
