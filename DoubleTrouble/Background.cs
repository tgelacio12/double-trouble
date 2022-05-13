/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: Background.cs
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
    /// A class that handles the backgrounds of the game.
    /// </summary>
    public class Background : DrawableGameComponent
    {
        //Declarations
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Rectangle srcRect;
        private Vector2 position;

        /// <summary>
        /// Default constructor of the class.
        /// </summary>
        /// <param name="game">Game.</param>
        /// <param name="spriteBatch">Spritebatch.</param>
        /// <param name="tex">Background image.</param>
        /// <param name="srcRect">Rectangle.</param>
        public Background(Game game, SpriteBatch spriteBatch,
            Texture2D tex, Rectangle srcRect) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.srcRect = srcRect;
            position = new Vector2(0, 0);

        }

        /// <summary>
        /// Override Draw()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, srcRect, Color.White);
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
    }
}
