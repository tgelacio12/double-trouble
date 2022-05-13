using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DoubleTrouble
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Declarations - Scenes
        public StartScene startScene;
        private ActionScene actionScene;
        private HelpScene helpScene;
        private CreditScene creditScene;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //set the dimension of the window
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 625;
            graphics.ApplyChanges();

            //Instantiate all scenes here
            startScene = new StartScene(this, spriteBatch);
            this.Components.Add(startScene);

            actionScene = new ActionScene(this, spriteBatch);
            this.Components.Add(actionScene);

            helpScene = new HelpScene(this, spriteBatch);
            this.Components.Add(helpScene);

            creditScene = new CreditScene(this, spriteBatch);
            this.Components.Add(creditScene);

            //Make only startScene active
            startScene.Show();

            //Set background music
            Song song = this.Content.Load<Song>("Music/RussianRoulette8bit");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 0.3f;

        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            // TODO: Add your update logic here

            KeyboardState ks = Keyboard.GetState();

            int selectedIndex = 0;

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;

                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    actionScene.Show();
                }

                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    helpScene.Show();
                }

                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    creditScene.Show();
                }

                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }

            }

            if (actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.Show();
                }
                //actionScene.GenerateLevel(this);
            }

            if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    helpScene.Hide();
                    startScene.Show();
                }
            }

            if (creditScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    creditScene.Hide();
                    startScene.Show();
                }
            }


            base.Update(gameTime);
        }

        private void HideAllScenes()
        {
            foreach (GameScene item in Components)
            {
                item.Hide();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
