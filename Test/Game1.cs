using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Vector2 position;
        Vector2 shift;
        Texture2D texture; //textura

        Vector2 NW = new Vector2(-1, -1);
        Vector2 NE = new Vector2(1, -1);
        Vector2 SW = new Vector2(-1, 1);
        Vector2 SE = new Vector2(1, 1);



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 900;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            position = new Vector2(1, 1);
            shift = SE;
            texture = new Texture2D(this.GraphicsDevice, 100, 100);
            Color[] square = new Color[100 * 100];

            // naplníme square barvou

            

            for (int i = 1; i < square.Length; i++)
            {
                square[i] = Color.Red;
            }

            texture.SetData(square);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);


            if (position.Y >= 300)
            {
                if (shift == SE) shift = NE;
                else shift = NW;
            }

            if (position.Y <= 0)
            {
                if (shift == NE) shift = SE;
                else shift = SW;
            }

            if (position.X >= 800)
            {
                if (shift == SE) shift = SW;
                else shift = NE;
            }

            if (position.X >= 0)
            {
                if (shift == SW) shift = SE;
                else shift = NE;
            }



            //if (position.Y >= 300 &&)
            //{

            //    shift = NE;
            //}
            //else if (position.Y <= 0 && shift == NE)
            //{
            //    shift = SE;
            //}
            //else if (position.X >= 700 && shift == SE)
            //{
            //    shift = SW;
            //}
            //else if (position.Y >= 300 && shift == SW)
            //{
            //    shift = NW;
            //}
            //else if (position.X <= 0 && shift == NW)
            //{
            //    shift = SW;
            //}
            //else if (position.Y >= 300 && shift == SW)
            //{
            //    shift = SE;
            //}


    

            position = position + shift;



            /**           if (position.X >= 700) {

                           position = position - new Vector2(-1, 1);


                       } else if (position.Y >= 300)
                       {

                           
                           position = position + new Vector2(1, -1);
                           

                       } else
                       {
                           position = position + new Vector2(1, 1);

                       }**/



        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
