/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: BrickCollisionManager.cs
 * 
 * Revision History
 *      Tonnicca Gelacio, 2018-December: Created
 *      Tonnicca Gelacio, 2018-December: Updated
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the collision of the ball and the bricks.
    /// </summary>
    class BrickCollisionManager : GameComponent
    {
        //Declarations
        private Ball ball;
        private Bat bat;
        private Bat topBat;
        private Brick[,] bricks;
        private Rectangle brickRect;
        private Rectangle ballRect;
        private TextDisplay scoreDisplay;
        private int score;
        private int brickCount;
        private Explosion explosion;
        private SoundEffect boomSound;
        private TextDisplay statusDisplay;
        private TextDisplay brickCounter;

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="ball"></param>
        /// <param name="bricks"></param>
        /// <param name="bat"></param>
        /// <param name="topBat"></param>
        /// <param name="brickCount"></param>
        /// <param name="score"></param>
        /// <param name="scoreDisplay"></param>
        /// <param name="brickCounter"></param>
        /// <param name="statusDisplay"></param>
        /// <param name="explosion"></param>
        /// <param name="boomSound"></param>
        public BrickCollisionManager(Game game, Ball ball, Brick[,] bricks, Bat bat, Bat topBat,
            int brickCount, int score, TextDisplay scoreDisplay, TextDisplay brickCounter, TextDisplay statusDisplay,
            Explosion explosion, SoundEffect boomSound) : base(game)
        {
            this.ball = ball;
            this.bat = bat;
            this.topBat = topBat;
            this.bricks = bricks;
            this.brickCount = brickCount;
            this.score = score;
            this.scoreDisplay = scoreDisplay;
            this.brickCounter = brickCounter;
            this.explosion = explosion;
            this.boomSound = boomSound;
            this.statusDisplay = statusDisplay;

        }

        /// <summary>
        /// Override Update()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            ballRect = ball.getBounds();

            foreach (Brick brick in bricks)
            {
                brickRect = brick.getBounds();

                if (ballRect.Intersects(brickRect))
                {
                    brick.IsHit = true;
                    brickCount--;

                    //Check which side has been hit by the ball
                    int x = brickRect.X + (brickRect.Width / 2) - (ballRect.X + (ballRect.Width / 2));
                    int y = brickRect.Y + (brickRect.Height / 2) - (ballRect.Y + (ballRect.Height / 2));

                    if (Math.Abs(x) > Math.Abs(y))
                    {
                        // reflect horizontally
                        ball.Speed = new Vector2(-Math.Abs(ball.Speed.X), ball.Speed.Y);
                        //ball.Speed = new Vector2(-(ball.Speed.X), ball.Speed.Y);
                    }

                    else
                    {
                        // reflect vertically
                        ball.Speed = new Vector2(ball.Speed.X, -ball.Speed.Y);
                    }

                    //play sound effect
                    boomSound.Play();

                    //show explosion
                    Vector2 pos = new Vector2(brickRect.X, brickRect.Y);
                    explosion.Position = pos;

                    explosion.Enabled = true;
                    explosion.Visible = true;

                    //remove brick from playing area
                    brick.Position = new Vector2(-100, -100);

                    //add points to score
                    score += brick.Points;
                }
            }

            scoreDisplay.Message = "Score: " + score.ToString();

            //Display number of bricks left
            brickCounter.Message = brickCount.ToString();

            if (brickCount == 0)
            {
                LevelCleared();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Executes whenever a level is cleared.
        /// </summary>
        public void LevelCleared()
        {
            statusDisplay.Message = "Level Cleared. \nScore: " + score.ToString();
            ball.Visible = false;
            bat.Visible = false;
            topBat.Visible = false;

        }
    }
}
