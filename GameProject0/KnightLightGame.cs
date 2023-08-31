using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SpriteExample;

namespace GameProject0
{
    public class KnightLightGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private FireSprite fire;
        private BatSprite bat;
        private Texture2D tree;
        private Texture2D atlas;
        private SpriteFont title;
        private SpriteFont exit;

        /// <summary>
        /// A game Knight Light's home screen
        /// </summary>
        public KnightLightGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            fire = new FireSprite();
            bat = new BatSprite() { Position = new Vector2(140, 130), Direction = Direction.Right};

            base.Initialize();
        }

        /// <summary>
        /// Loads content for the game
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            atlas = Content.Load<Texture2D>("character_pack");
            fire.LoadContent(Content);
            bat.LoadContent(Content);
            tree = Content.Load<Texture2D>("tree");
            title = Content.Load<SpriteFont>("BlackOpsOne-Regular");
            exit = Content.Load<SpriteFont>("BlackOpsOne-Regular");
        }

        /// <summary>
        /// Updates the game world
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            bat.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game world
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(atlas, new Vector2(380, 200), new Rectangle(155, 150, 32, 53), Color.White);
            spriteBatch.Draw(atlas, new Vector2(320, 260), new Rectangle(91, 215, 32, 53), Color.White);
            spriteBatch.Draw(atlas, new Vector2(440, 260), new Rectangle(284, 358, 32, 53), Color.White);
            bat.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(tree, new Rectangle(600,100,160,240), new Rectangle(0,0,319, 479), Color.White);
            spriteBatch.Draw(tree, new Rectangle(50, 100, 160, 240), new Rectangle(0, 0, 319, 479), Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            fire.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(title, "KNIGHT LIGHT", new Vector2(220, 25), Color.Orange);
            spriteBatch.DrawString(exit, "press esc to exit", new Vector2(190, 400), Color.Orange);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}