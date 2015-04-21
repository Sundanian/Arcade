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
        private int timer = 0;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player(Vector2.Zero + new Vector2(128, 128));
                }
                return instance;
            }
        }

        private Player(Vector2 position)
            : base(position)
        {

        }
        public override void LoadContent(ContentManager content)
        {
            frames = 2;
            speed = 100;
            texture = content.Load<Texture2D>(@"Ship");

            CreateAnimation("Idle", 1, 0, 1, 128, 128, Vector2.Zero, 1, texture);
            CreateAnimation("Thrust", 2, 0, 0, 128, 128, Vector2.Zero, 30, texture);
            PlayAnimation("Idle");

            base.LoadContent(content);
        }
        private void HandleInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
            {
                //Thrust
                PlayAnimation("Thrust");
                velocity += new Vector2((float)Math.Sin(rotation), -(float)Math.Cos(rotation));
            }
            else
            {
                PlayAnimation("Idle");
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                //Rotate Left
                rotation -= 0.05f;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                //Rotate right
                rotation += 0.05f;
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                if (timer > 10)
                {
                    Space.AddObjects.Add(new Missile(position + new Vector2(0, 16), this));
                    timer = 0;
                }
            }
            timer++;
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
