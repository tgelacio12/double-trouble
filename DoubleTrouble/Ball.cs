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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the Ball object.
    /// </summary>
    public class Ball : DrawableGameComponent
    {
        //Declarations
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        private int livesLeft;
        private TextDisplay livesCounter;
        private SoundEffect dingSound;
        //private SoundEffect missSound;

        public Vector2 Speed { get => speed; set => speed = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Ball(Game game, SpriteBatch spriteBatch,
            Texture2D tex, Vector2 position, Vector2 speed,
            Vector2 stage, int livesLeft, TextDisplay livesCounter,
            SoundEffect dingSound) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.dingSound = dingSound;
            this.livesLeft = livesLeft;
            this.livesCounter = livesCounter;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;

            //Top Wall
            if (position.Y < 100)
            {
                //missSound.Play();
                this.Visible = false;

                SetStartPosition();
            }

            //Bottom Wall
            if (position.Y + tex.Height > stage.Y)
            {
                //missSound.Play();
                this.Visible = false;

                SetStartPosition();
            }

            //Right Wall
            if (position.X + tex.Width > stage.X)
            {
                speed.X = -speed.X;
                dingSound.Play();
            }

            //Left Wall
            if (position.X < 0)
            {
                speed.X = -speed.X;
                dingSound.Play();
            }

            //Display lives left
            livesCounter.Message = "Lives: " + livesLeft.ToString();

            base.Update(gameTime);
        }

        /// <summary>
        /// To get the bounds of the ball's rectangle.
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        /// <summary>
        /// Executes whenever the player loses a life.
        /// </summary>
        //public void LoseLife()
        //{
        //    livesLeft--;

        //    if (livesLeft > 0)
        //    {
        //        SetStartPosition();
        //    }

        //    else
        //    {
        //        GameOver();
        //    }

        //}

        /// <summary>
        /// To set the ball's starting position after losing a life.
        /// </summary>
        /// <returns></returns>
        public void SetStartPosition()
        {
            KeyboardState ks = Keyboard.GetState();


            if (ks.IsKeyDown(Keys.Space))
            {
                if (livesLeft > 0)
                {
                    livesLeft--;

                    //(batInitPos.X + ((batTex.Width - ballTex.Width) / 2), batInitPos.Y - ballTex.Height)
                    position.X = stage.X / 2 - tex.Width / 2;
                    position.Y = stage.Y / 2 - tex.Height / 2;

                    //this.Enabled = true;
                    this.Visible = true;
                }

                else
                {
                    GameOver();
                }

            }
        }

        /// <summary>
        /// Executes wheneever the game is over.
        /// </summary>
        /// <returns></returns>
        public void GameOver()
        {
            this.Enabled = false;
            this.Visible = false;
            livesCounter.Message = "Game Over.";

            //Game Over.
            //Press space -> Go back to start scene
        }
    }
}
