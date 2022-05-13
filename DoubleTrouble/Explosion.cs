using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the explosion animation.
    /// </summary>
    public class Explosion : DrawableGameComponent
    {
        //Declarations
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="delay"></param>
        public Explosion(Game game, SpriteBatch spriteBatch,
            Texture2D tex, Vector2 position, int delay) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.delay = delay;
            dimension = new Vector2(100, 100);

            this.Enabled = false;
            this.Visible = false;

            CreateFrames();
        }

        /// <summary>
        /// To create the frames from the spritesheet.
        /// </summary>
        private void CreateFrames()
        {
            frames = new List<Rectangle>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;

                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }
        }

        /// <summary>
        /// Override Draw()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                spriteBatch.Begin();

                //version 4
                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);

                spriteBatch.End();

            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Override Update()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            delayCounter++;

            if (delayCounter > delay)
            {
                frameIndex++;

                if (frameIndex > 7)
                {
                    frameIndex = -1;

                    this.Enabled = false;
                    this.Visible = false;
                }

                delayCounter = 0;

            }

            base.Update(gameTime);
        }
    }
}
