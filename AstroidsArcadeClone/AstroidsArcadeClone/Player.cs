using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class Player : SpriteObject
    {
        public int lives;
        private Player instance = null;

        public Player Instance
        {
            get { return instance; }
        }

        private Player(Vector2 position, int frames) : base(position, frames)
        {

        }
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"");

            base.LoadContent(content);
        }
        private void HandleInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
            {
                //Thrust
                velocity += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                //Rotate Left

            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                //Rotate right

            }
        }
        public override void Update(GameTime gametime)
        {
            velocity = Vector2.Zero;

            HandleInput(Keyboard.GetState());

            velocity *= speed;

            float deltatime = (float)gametime.ElapsedGameTime.TotalSeconds;

            position += (velocity * deltatime);
            base.Update(gametime);
        }
    }
}
