using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    enum EnemyType { AstroidBig, AstroidNormal, AstroidSmall, UFONormal, UFOSmall };
    class Enemy : SpriteObject
    {
        private bool weapon;
        private int velocityX;
        private int velocityY;
        private static Random r = new Random();
        private EnemyType type;
        private int timer = 0;  

        public EnemyType Type
        {
            get { return type; }
            set { type = value; }
        }
        public bool Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Enemy(Vector2 position)
            : base(position)
        {

        }
        public override void Update(GameTime gametime)
        {
            velocity = Vector2.Zero;
            velocity += new Vector2(velocityX, velocityY);
            velocity *= speed;
            float deltatime = (float)gametime.ElapsedGameTime.TotalSeconds;
            position += (velocity * deltatime);

            Move();

            base.Update(gametime);
        }
        public override void LoadContent(ContentManager content)
        {
            velocityX = r.Next(-1, 2);
            velocityY = r.Next(-1, 2);
            if (velocityX == 0 && velocityY == 0)
            {
                velocityX = r.Next(1, 3);
                if (velocityX == 2)
                {
                    velocityX = -1;
                }
                velocityY = r.Next(1, 3);
                if (velocityY == 2)
                {
                    velocityY = -1;
                }
            }

            CreateAnimation("Idle", 1, 0, 0, Texture.Width, Texture.Height, Vector2.Zero, 1, texture);
            PlayAnimation("Idle");
            base.LoadContent(content);
        }
        public virtual void Move()
        {
            if (this.Type == EnemyType.UFONormal || this.Type == EnemyType.UFOSmall)
            {
                if (timer == 0)
                {
                    switch (r.Next(1, 10))
                    {
                        case 1:
                            this.velocityX = -1;
                            timer++;
                            break;
                        case 2:
                            timer++;
                            break;
                        case 3:
                            this.velocityX = 1;
                            timer++;
                            break;
                        case 4:
                            timer++;
                            break;
                        case 5:
                            this.velocityY = -1;
                            timer++;
                            break;
                        case 6:
                            timer++;
                            break;
                        case 7:
                            this.velocityY = 1;
                            timer++;
                            break;
                        case 8:
                            timer++;
                            break;
                        case 9:
                            timer++;
                            break;
                        case 10:
                            timer++;
                            break;
                        //case 11:
                        //    timer++;
                        //    break;
                        //case 12:
                        //    timer++;
                        //    break;
                        default:
                            break;
                    }
                    
                }
                timer++;

            }
            if (timer == 30)
                {
                    timer = 0;
                }
        }
        public void DeathSpawn()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.type == EnemyType.AstroidBig)
                {
                    EnemyDirector director = new EnemyDirector(new AstroidNormal(), Space.ContentMan, position);
                    director.BuildEnemy();
                    Space.AddObjects.Add(director.GetEnemy);
                }
                if (this.type == EnemyType.AstroidNormal)
                {
                    EnemyDirector director = new EnemyDirector(new AstroidSmall(), Space.ContentMan, position);
                    director.BuildEnemy();
                    Space.AddObjects.Add(director.GetEnemy);
                }
            }
        }
        protected override void HandleCollision()
        {
            foreach (SpriteObject obj in Space.Objects)
            {
                if (obj != this && obj is Missile && obj.CollisionRect.Intersects(this.CollisionRect))
                {
                    if (PixelCollision(obj))
                    {
                        DeathSpawn();
                        Space.RemoveObjects.Add(this);
                        Space.RemoveObjects.Add(obj);
                    }
                }
            }
        }
    }
}
