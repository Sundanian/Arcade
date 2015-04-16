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
        public int lives = 3;
        static Player instance;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player(Vector2.Zero);
                }
                return instance;
            }
        }

        private Player(Vector2 position) : base(position)
        {
            
        }
        public override void LoadContent(ContentManager content)
        {
            speed = 100;
            Texture = content.Load<Texture2D>(@"Ship");

            CreateAnimation("Idle", 1, 0, 2, 128, 128, Vector2.Zero, 1, texture);
            CreateAnimation("Thrust", 2, 0, 1, 128, 128, Vector2.Zero, 2, texture);
            PlayAnimation("Idle");

            base.LoadContent(content);
        }
        private void HandleInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
            {
                //Thrust
                PlayAnimation("Thrust");
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
            if (keyState.IsKeyDown(Keys.Space))
            {
                Space.AddObjects.Add(new Missile(position));
            }
        }
        public override void Update(GameTime gametime)
        {
            velocity = Vector2.Zero;

            HandleInput(Keyboard.GetState());

            velocity *= speed;

            float deltatime = (float)gametime.ElapsedGameTime.TotalSeconds;

            Position += (velocity * deltatime);
            base.Update(gametime);
        }
    }
}
