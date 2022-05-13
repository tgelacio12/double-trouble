/* Double Trouble Application
* PROG2370 Final Project
* 
* Class Name: TextDisplay.cs
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
    /// A class that handles the texts displayed in the game.
    /// </summary>
    public class TextDisplay : DrawableGameComponent
    {
        //Declarations
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private string message;
        private Vector2 position;
        private Color color;

        public string Message { get => message; set => message = value; }

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        /// <param name="message"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public TextDisplay(Game game, SpriteBatch spriteBatch,
            SpriteFont font, string message, Vector2 position,
            Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.message = message;
            this.position = position;
            this.color = color;
        }

        /// <summary>
        /// Override Draw()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
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
