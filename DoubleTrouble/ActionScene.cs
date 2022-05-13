/* Double Trouble Application
 * PROG2370 Final Project
 * 
 * Class Name: ActionScene.cs
 * 
 * Revision History
 *      Tonnicca Gelacio, 2018-December: Created
 *      Tonnicca Gelacio, 2018-December: Updated
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleTrouble
{
    /// <summary>
    /// A class that handles the gameplay of the game.
    /// </summary>
    public class ActionScene : GameScene
    {
        //Declaration and Initializations
        private SpriteBatch spriteBatch;
        private Ball ball;
        private Bat bat;
        private Bat topBat;
        private Brick[,] bricks;
        private BrickCollisionManager brickcm;
        private CollisionManager cm;
        private SpriteFont font;
        private Explosion explosion;
        private Background background;
        private TextDisplay scoreDisplay;
        private TextDisplay statusDisplay;
        private int score = 0;
        private int livesLeft = 3;
        private int brickCount;
        private TextDisplay brickCounter;
        private TextDisplay livesCounter;

        public int Score { get => score; set => score = value; }
        public TextDisplay ScoreDisplay { get => scoreDisplay; set => scoreDisplay = value; }
        public int BrickCount { get => brickCount; set => brickCount = value; }
        public TextDisplay BrickCounter { get => brickCounter; set => brickCounter = value; }
        public int LivesLeft { get => livesLeft; set => livesLeft = value; }
        public TextDisplay LivesCounter { get => livesCounter; set => livesCounter = value; }

        /// <summary>
        /// The default constructor of the class
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        public ActionScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;

            GenerateLevel(game);
        }

        /// <summary>
        /// To generate a level of the game.
        /// </summary>
        /// <param name="game"></param>
        public void GenerateLevel(Game game)
        {
            Shared.stage = new Vector2(1000, 625);

            #region Background
            //Create instance of background
            Texture2D backgroundImage = game.Content.Load<Texture2D>("Images/background");
            Rectangle srcRect = new Rectangle(0, 0, (int)Shared.stage.X, (int)Shared.stage.Y);
            background = new Background(game, spriteBatch, backgroundImage, srcRect);
            this.Components.Add(background);
            #endregion

            //Load Font
            font = game.Content.Load<SpriteFont>("Fonts/displayText");

            #region Scoreboard
            //Create new instance of scoreboard
            Vector2 scorePos = new Vector2(0, 0);
            scoreDisplay = new TextDisplay(game, spriteBatch, font, score.ToString(),
                scorePos, Color.White);
            this.Components.Add(scoreDisplay);
            #endregion

            #region BrickCounter
            //BrickCounter
            Vector2 bcPos = new Vector2(400, 0);
            brickCounter = new TextDisplay(game, spriteBatch, font, brickCount.ToString(),
                bcPos, Color.White);
            this.Components.Add(brickCounter);
            #endregion

            #region LivesCounter
            //LivesCounter
            Vector2 livesPos = new Vector2(850, 0);
            livesCounter = new TextDisplay(game, spriteBatch, font, livesLeft.ToString(),
                livesPos, Color.White);
            this.Components.Add(livesCounter);
            #endregion

            #region Bat
            //Declare bat properties
            Texture2D batTex = game.Content.Load<Texture2D>("Images/Bat");
            Vector2 batInitPos = new Vector2(Shared.stage.X / 2 - batTex.Width / 2, Shared.stage.Y - batTex.Height);
            Vector2 batSpeed = new Vector2(5, 0);
            Vector2 topBatInitPos = new Vector2(Shared.stage.X / 2 - batTex.Width / 2, 100);

            //Create new instance of a bat
            bat = new Bat(game, spriteBatch, batTex, batInitPos, batSpeed, Shared.stage);
            this.Components.Add(bat);

            //Create new instance of a top bat
            topBat = new Bat(game, spriteBatch, batTex, topBatInitPos, batSpeed, Shared.stage);
            this.Components.Add(topBat);
            #endregion

            #region Ball
            //Declare ball properties
            Texture2D ballTex = game.Content.Load<Texture2D>("Images/Ball");
            Vector2 ballInitPos = new Vector2(batInitPos.X + ((batTex.Width - ballTex.Width) / 2), batInitPos.Y - ballTex.Height);
            Vector2 ballSpeed = new Vector2(2, -5);
            SoundEffect dingSound = game.Content.Load<SoundEffect>("Music/ding");
            //SoundEffect missSound = game.Content.Load<SoundEffect>("Music/applause");


            //Create new instance of a ball
            ball = new Ball(game, spriteBatch, ballTex, ballInitPos, ballSpeed, Shared.stage, livesLeft, livesCounter, dingSound);
            this.Components.Add(ball);
            #endregion

            #region Brick
            //Declare brick properties
            int rows = 8;
            int columns = 6;
            int points = 0;
            brickCount = rows * columns;
            Texture2D brickTex = game.Content.Load<Texture2D>("Images/Brick");

            bricks = new Brick[rows, columns];

            for (int j = 0; j < columns; j++)
            {
                Color tint = Color.White;

                switch (j)
                {
                    case 0:
                        tint = Color.Blue;
                        points = 500;
                        break;
                    case 1:
                        tint = Color.Red;
                        points = 400;
                        break;
                    case 2:
                        tint = Color.Green;
                        points = 300;
                        break;
                    case 3:
                        tint = Color.Yellow;
                        points = 200;
                        break;
                    case 4:
                        tint = Color.Purple;
                        points = 100;
                        break;
                    default:
                        tint = Color.White;
                        break;
                }

                for (int i = 0; i < rows; i++)
                {
                    bricks[i, j] = new Brick(game, spriteBatch, brickTex,
                        new Vector2(200 + i * brickTex.Width, 200 + j * brickTex.Height),
                        Shared.stage, tint, points);

                    this.Components.Add(bricks[i, j]);
                }
            }
            #endregion

            #region CollisionManager
            //Create new instance of a collision manager
            //SoundEffect hitSound = this.Content.Load<SoundEffect>("Music/click");
            //cm = new CollisionManager(game, bat, topBat, ball, hitSound);
            cm = new CollisionManager(game, bat, topBat, ball);
            this.Components.Add(cm);
            #endregion

            #region Explosion
            //Create new instance of explosion
            Texture2D explosionImage = game.Content.Load<Texture2D>("Images/explosion");
            Vector2 position = new Vector2(300, 200);
            int delay = 2;

            explosion = new Explosion(game, spriteBatch, explosionImage, position, delay);
            this.Components.Add(explosion);
            #endregion

            #region Brick Collision Manager
            //Create new instance of a brick collision manager
            SoundEffect boomSound = game.Content.Load<SoundEffect>("Music/boom");
            statusDisplay = new TextDisplay(game, spriteBatch, font, "", new Vector2(350, 300), Color.White);
            this.Components.Add(statusDisplay);

            brickcm = new BrickCollisionManager(game, ball, bricks, bat, topBat, brickCount, score,
                scoreDisplay, brickCounter, statusDisplay, explosion, boomSound);
            this.Components.Add(brickcm);
            #endregion
        }
    }
}
