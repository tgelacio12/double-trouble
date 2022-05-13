/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: Brick.cs
 * 
 * Revision History
 *      Tonnicca Gelacio, 2018-December: Created
 *      Tonnicca Gelacio, 2018-December: Updated
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the Brick object.
    /// </summary>
    public class Brick : DrawableGameComponent
    {
        //Initializations and Declarations
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 stage;
        private Color tint;
        private bool isHit;
        private int points;

        public Vector2 Position { get => position; set => position = value; }
        public bool IsHit { get => isHit; set => isHit = value; }
        public int Points { get => points; set => points = value; }

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game">Game.</param>
        /// <param name="spriteBatch">Spritebatch</param>
        /// <param name="tex">Brick image</param>
        /// <param name="position">Position</param>
        /// <param name="stage">Stage</param>
        /// <param name="tint">Color</param>
        /// <param name="points">Points allocated</param>
        public Brick(Game game, SpriteBatch spriteBatch, Texture2D tex,
            Vector2 position, Vector2 stage, Color tint, int points) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.stage = stage;
            this.tint = tint;
            this.isHit = false;
            this.points = points;
        }

        /// <summary>
        /// Override Draw()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //Check if brick has been hit
            //Draw bricks that havent been hit
            if (!isHit)
            {
                spriteBatch.Draw(tex, position, tint);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Override Update()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// To get the bounds of the brick.
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

    }
}
