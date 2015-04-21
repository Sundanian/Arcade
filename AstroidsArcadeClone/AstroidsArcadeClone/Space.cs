using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AstroidsArcadeClone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Space : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static Random r = new Random();
        private static List<SpriteObject> objects = new List<SpriteObject>();
        private static List<SpriteObject> removeObjects = new List<SpriteObject>();
        private static List<SpriteObject> addObjects = new List<SpriteObject>();
        private static ContentManager contentMan;

        public static ContentManager ContentMan
        {
            get { return contentMan; }
            set { contentMan = value; }
        }
        public static List<SpriteObject> AddObjects
        {
            get { return addObjects; }
            set { addObjects = value; }
        }
        public static List<SpriteObject> Objects
        {
            get { return objects; }
            set { objects = value; }
        }
        public static List<SpriteObject> RemoveObjects
        {
            get { return removeObjects; }
            set { removeObjects = value; }
        }

        public Space()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            Window.Title = "AstroidClone by LaiHor Ent.";
            contentMan = Content;
            graphics.PreferredBackBufferWidth *= 2;
            graphics.PreferredBackBufferHeight *= 2;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            // TODO: use this.Content to load your game content here
            for (int i = 0; i < 3; i++)
            {
                EnemyDirector director = new EnemyDirector(new AstroidBig(), Content, new Vector2(r.Next(0, Window.ClientBounds.Width), r.Next(0, Window.ClientBounds.Height)));
                director.BuildEnemy();
                addObjects.Add(director.GetEnemy);
            }

            addObjects.Add(Player.Instance);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            int tmpEnemyCount = 0;
            foreach (SpriteObject obj in objects)
            {
                if (obj is Enemy)
                {
                    tmpEnemyCount++;
                }
            }
            foreach (SpriteObject obj in addObjects)
            {
                if (obj is Enemy)
                {
                    tmpEnemyCount++;
                }
            }
            if (tmpEnemyCount == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    EnemyDirector director = new EnemyDirector(new AstroidBig(), Content, new Vector2(r.Next(0, Window.ClientBounds.Width), r.Next(0, Window.ClientBounds.Height)));
                    director.BuildEnemy();
                    addObjects.Add(director.GetEnemy);
                }
            }

            //Holder styr på listerne
            foreach (SpriteObject obj in removeObjects)
            {
                objects.Remove(obj);
            }
            foreach (SpriteObject obj in addObjects)
            {
                objects.Add(obj);
                obj.LoadContent(Content);
            }
            removeObjects.Clear();
            addObjects.Clear();
            foreach (SpriteObject obj in objects)
            {
                obj.Update(gameTime);
            }

            //ScreenWrap
            foreach (SpriteObject obj in objects)
            {
                if (obj.Position.X + obj.Texture.Width / obj.Frames / 2 < 0)
                {
                    obj.Position = new Vector2(Window.ClientBounds.Width + obj.Texture.Width / obj.Frames / 2, obj.Position.Y);
                }
                if (obj.Position.Y + obj.Texture.Height / 2 < 0)
                {
                    obj.Position = new Vector2(obj.Position.X, Window.ClientBounds.Height + obj.Texture.Height / 2);
                }
                if (obj.Position.X - obj.Texture.Width / obj.Frames / 2 > Window.ClientBounds.Width)
                {
                    obj.Position = new Vector2(0 - obj.Texture.Width / obj.Frames / 2, obj.Position.Y);
                }
                if (obj.Position.Y - obj.Texture.Height / 2 > Window.ClientBounds.Height)
                {
                    obj.Position = new Vector2(obj.Position.X, 0 - obj.Texture.Height / 2);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (SpriteObject obj in objects)
            {
                obj.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
