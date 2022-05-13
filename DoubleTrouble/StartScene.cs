/* Double Trouble Application
* PROG2370 Final Project
* 
* Class Name: StartScene.cs
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
    /// A class that handles the start scene of the game.
    /// </summary>
    public class StartScene : GameScene
    {
        //Declarations
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        private string[] menuItems = { "Start Game", "Help",
            "High Score", "Credit", "Quit" };

        private Background background;

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        public StartScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/regularfont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts/highlightfont");

            Shared.stage = new Vector2(1000, 625);

            //Create instance of background
            Texture2D backgroundImage = game.Content.Load<Texture2D>("Images/Title");
            Rectangle srcRect = new Rectangle(0, 0, (int)Shared.stage.X, (int)Shared.stage.Y);
            background = new Background(game, spriteBatch, backgroundImage, srcRect);
            this.Components.Add(background);

            //creating components in constructor instead of Load
            Menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);

            this.Components.Add(Menu);
        }

        /// <summary>
        /// Override Draw()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
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
