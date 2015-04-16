﻿using Microsoft.Xna.Framework;
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
        Random r =  new Random();
        Player player;
        private static List<SpriteObject> objects = new List<SpriteObject>();
        private static List<SpriteObject> removeObjects = new List<SpriteObject>();
        private static List<SpriteObject> addObjects = new List<SpriteObject>();

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
            Enemy enemy;
            EnemyDirector director = new EnemyDirector(new AstroidBig(), Content, new Vector2(r.Next(0, Window.ClientBounds.Width), r.Next(0, Window.ClientBounds.Height)));
            director.BuildEnemy();
            enemy = director.GetEnemy;
            addObjects.Add(enemy);

            player = new Player(Vector2.Zero);
            addObjects.Add(player);

            foreach (SpriteObject obj in addObjects)
            {
                obj.LoadContent(Content);
            }
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

            //Builder en enemy som er en AstroidBig
            foreach (SpriteObject obj in removeObjects)
            {
                objects.Remove(obj);
            }
            foreach (SpriteObject obj in addObjects)
            {
                objects.Add(obj);
            }
            removeObjects.Clear();
            addObjects.Clear();
            foreach (SpriteObject obj in objects)
            {
                obj.Update(gameTime);
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
