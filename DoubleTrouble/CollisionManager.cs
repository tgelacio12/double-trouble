/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: CollisionManager.cs
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
    /// A class that handles the collision between the bat and the ball.
    /// </summary>
    class CollisionManager : GameComponent
    {
        private Ball ball;
        private Bat bat;
        private Bat topBat;

        /// <summary>
        /// The default constructor of the class.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="bat"></param>
        /// <param name="topBat"></param>
        /// <param name="ball"></param>
        public CollisionManager(Game game, Bat bat, Bat topBat, Ball ball) : base(game)
        {
            this.bat = bat;
            this.topBat = topBat;
            this.ball = ball;
            //this.hitSound = hitSound;
        }

        /// <summary>
        /// Override Update()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Rectangle batRect = bat.getBounds();
            Rectangle ballRect = ball.getBounds();
            Rectangle topBatRect = topBat.getBounds();

            //Check if intersection occurs
            if (batRect.Intersects(ballRect))
            {
                ball.Speed = new Vector2(ball.Speed.X, -Math.Abs(ball.Speed.Y));
            }

            if (topBatRect.Intersects(ballRect))
            {
                ball.Speed = new Vector2(ball.Speed.X, Math.Abs(ball.Speed.Y));
            }

            base.Update(gameTime);
        }
    }
}

