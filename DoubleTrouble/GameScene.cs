/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: GameScene.cs
 * 
 * Revision History
 *      Tonnicca Gelacio, 2018-December: Created
 *      Tonnicca Gelacio, 2018-December: Updated
 */

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the game scene.
    /// </summary>
    public abstract class GameScene : DrawableGameComponent
    {
        private List<GameComponent> components;

        public List<GameComponent> Components { get => components; set => components = value; }

        public virtual void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public virtual void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            Hide();
        }



        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;

            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    //check if item is a drawable game component
                    comp = (DrawableGameComponent)item;

                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
    }
}
