using Assignment3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ballon ballon1;
        private Ballon ballon2;
        private Ballon ballon3;
        private Bomb bomb1;
        private Bomb bomb2;
        private Bomb bomb3;
        Random random = new Random();
        Random randomSpeed = new Random();
        double tmr = 0;
        double mllscnd = 0;

        int level = 1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Ballon
            Texture2D texBallon = Content.Load<Texture2D>("img/ballon");
            Vector2 stageBallon = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Vector2 position1 = new Vector2(100 , 100);
            Vector2 position2 = new Vector2(stageBallon.X / 2, 100);
            Vector2 position3 = new Vector2(stageBallon.X / 2 + 200, 100);
            Vector2 speedBallon = new Vector2(1, 1);
            ballon1 = new Ballon(this, _spriteBatch, texBallon, position1, speedBallon, stageBallon);
            ballon2 = new Ballon(this, _spriteBatch, texBallon, position2, speedBallon, stageBallon);
            ballon3 = new Ballon(this, _spriteBatch, texBallon, position3, speedBallon, stageBallon);

            // Load Bomb
            Texture2D texBomb = Content.Load<Texture2D>("img/bomb");
            Vector2 stageBomb = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Vector2 postBomb1 = new Vector2(120, 100);
            Vector2 postBomb2 = new Vector2(stageBallon.X / 2, 100);
            Vector2 postBomb3 = new Vector2(stageBallon.X / 2 + 200, 100);
            Vector2 speedBomb = new Vector2(1, 1);
            bomb1 = new Bomb(this, _spriteBatch, texBomb, postBomb1, speedBomb, stageBomb);
            bomb2 = new Bomb(this, _spriteBatch, texBomb, postBomb2, speedBomb, stageBomb);
            bomb3 = new Bomb(this, _spriteBatch, texBomb, postBomb3, speedBomb, stageBomb);


            this.Components.Add(ballon1);
            this.Components.Add(ballon2);
            this.Components.Add(ballon3);

            this.Components.Add(bomb1);
            this.Components.Add(bomb2);
            this.Components.Add(bomb3);

        }

        protected override void Update(GameTime gameTime)
        {

            tmr++;
            mllscnd = Math.Round(tmr / 100);

            if(tmr == 1000)
            {
                level = 2;
            }


            if (tmr == 2000)
            {
                level = 3;
            }

            base.Update(gameTime);


            ballon1.position.Y += 1;
            ballon2.position.Y += 1;
            ballon3.position.Y += 1;


            if(level == 1)
            {
                ballon1.position.Y += randomSpeed.Next(1,3);
                ballon2.position.Y += randomSpeed.Next(1, 3); ;
                ballon3.position.Y += randomSpeed.Next(1, 3); ;
            }

            if (level == 2)
            {
                ballon1.position.Y += randomSpeed.Next(4, 6);
                ballon2.position.Y += randomSpeed.Next(4, 6); ;
                ballon3.position.Y += randomSpeed.Next(4, 5); ;
            }

            if (level == 3)
            {
                ballon1.position.Y += randomSpeed.Next(7, 9);
                ballon2.position.Y += randomSpeed.Next(7, 9); ;
                ballon3.position.Y += randomSpeed.Next(7, 9); ;
            }

            if (ballon1.position.Y > _graphics.PreferredBackBufferHeight)
            {
                ballon1.position.Y = random.Next(50, 50);
                ballon1.position.X = random.Next(50, _graphics.PreferredBackBufferWidth);
            }

            if (ballon2.position.Y > _graphics.PreferredBackBufferHeight)
            {
                ballon2.position.Y = random.Next(50, 50);
                ballon2.position.X = random.Next(50, _graphics.PreferredBackBufferWidth);
            }

            if (ballon3.position.Y > _graphics.PreferredBackBufferHeight)
            {
                ballon3.position.Y = random.Next(50, 50);
                ballon3.position.X = random.Next(50, _graphics.PreferredBackBufferWidth);
            }

            bomb1.position.Y += 1;
            bomb2.position.Y += 1;
            bomb3.position.Y += 1;


            if (bomb1.position.Y > _graphics.PreferredBackBufferHeight)
            {
                bomb1.position.Y = random.Next(50, 50);
                bomb1.position.X = random.Next(50, _graphics.PreferredBackBufferWidth);
            }

            if (bomb2.position.Y > _graphics.PreferredBackBufferHeight)
            {
                bomb2.position.Y = random.Next(50, 50);
                bomb2.position.X = random.Next(50, _graphics.PreferredBackBufferWidth);
            }

            if (bomb3.position.Y > _graphics.PreferredBackBufferHeight)
            {
                bomb3.position.Y = random.Next(50, 50);
                bomb3.position.X = random.Next(50, _graphics.PreferredBackBufferWidth);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}