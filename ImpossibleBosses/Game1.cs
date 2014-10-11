#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using ImpossibleBosses.GameObjects;
#endregion

namespace ImpossibleBosses
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerController.PlayerController player1 = new PlayerController.PlayerController(1);
        MapHandler.GameMap curMap = new MapHandler.GameMap();

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            Texture2D basicTilesPng = this.Content.Load<Texture2D>("BasicTileSet");
            Texture2D playerTilesPng = this.Content.Load<Texture2D>("PlayerTestTileSet");

            TileHandler.AddTileSet("basic", basicTilesPng);
            TileHandler.AddTileSet("player", playerTilesPng);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            Vector2 moveDir = player1.Update();
            if (curMap.isFree(pc.TryMove(moveDir))) { pc.Move(moveDir); }
            else
            {
                var xMove = new Vector2(moveDir.X, 0);
                var yMove = new Vector2(0, moveDir.Y);
                if (curMap.isFree(pc.TryMove(xMove))) { pc.Move(xMove); }
                if (curMap.isFree(pc.TryMove(yMove))) { pc.Move(yMove); }
            }

            if ((pc.Facing = PlayerController.PlayerController.GetFacing(moveDir)) < 0)
            { pc.Facing = lastFacing; }
            else { lastFacing = pc.Facing; }
            base.Update(gameTime);
        }

        int lastFacing = 0;
        GameObject pc = new GameObject(80, 80);

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            curMap.Draw(spriteBatch);
            spriteBatch.Draw(TileHandler.GetTileSet("player"), new Vector2(pc.Position.X, pc.Position.Y), new Rectangle(pc.Facing * 40, 0, 40, 40), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
