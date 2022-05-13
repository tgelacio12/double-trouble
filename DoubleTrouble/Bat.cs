/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: Ball.cs
 * 
 * Revision History
 *      Tonnicca Gelacio, 2018-December: Created
 *      Tonnicca Gelacio, 2018-December: Updated
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the Bat object.
    /// </summary>
    public class Bat : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;

        private Vector2 stage;

        public Vector2 Position { get => position; set => position = value; }

        public Bat(Game game, SpriteBatch spriteBatch, Texture2D tex,
            Vector2 position, Vector2 speed, Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;

                if (position.X < 0)
                {
                    position.X = 0;
                }

            }

            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;

                if (position.X + tex.Width > stage.X)
                {
                    position.X = stage.X - tex.Width;
                }

            }

            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        //public void SetStartPosition()
        //{
        //    position.X = stage.X / 2 - tex.Width / 2;
        //    position.Y = stage.Y - tex.Height;
        //}
    }
}
