using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        public void LoadContent(ContentManager content)
        {

        }
        private void HandleInput(KeyState keyState)
        {

        }
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }
    }
}
