using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the menu components of the game.
    /// </summary>
    public class MenuComponent : DrawableGameComponent
    {
        //Declarations
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, highlightFont;
        private List<string> menuItems;

        public int SelectedIndex { get; set; } = 0;
        private Vector2 position;
        private Color regularColor = Color.White;
        private Color highlightColor = Color.HotPink;

        private KeyboardState oldState;

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="regularFont"></param>
        /// <param name="highlightFont"></param>
        /// <param name="menus"></param>
        public MenuComponent(Game game, SpriteBatch spriteBatch,
            SpriteFont regularFont, SpriteFont highlightFont,
            string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;
            this.menuItems = menus.ToList<string>();

            this.position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        /// <summary>
        /// Override Draw()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;

            spriteBatch.Begin();

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (SelectedIndex == i)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[i], tempPos, highlightColor);
                    tempPos.Y += highlightFont.LineSpacing;
                }

                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }

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
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            //if (ks.IsKeyUp(Keys.Down) && oldState.IsKeyDown(Keys.Down))
            {
                SelectedIndex++;

                if (SelectedIndex >= menuItems.Count)
                {
                    SelectedIndex = 0;
                }

            }

            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;

                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Count - 1;
                }

            }

            oldState = ks;

            base.Update(gameTime);
        }
    }
}
