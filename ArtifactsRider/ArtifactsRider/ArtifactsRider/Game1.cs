using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using VAPI;
using ArtifactsRider.Scenes;

namespace ArtifactsRider
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GeneralManager.Initalize(Content, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, this);


            LoadTextures();
            LoadFonts();

            GeneralManager.CurrentScreen = new MainMenuScreen(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void UnloadContent()
        {
        }

        private static void LoadTextures()
        {
            //GeneralManager.LoadTex("texname");
            GeneralManager.LoadTex("Textures/TestTex");
        }

        private static void LoadFonts()
        {
            GeneralManager.LoadFont("Fonts/SteamWreck");
        }


        protected override void Update(GameTime gameTime)
        {

            GeneralManager.Update();
            GeneralManager.CurrentScreen.HandleInput();
            GeneralManager.CurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GeneralManager.CurrentScreen.BeginDraw(spriteBatch, gameTime);
            GeneralManager.CurrentScreen.Draw(spriteBatch, gameTime);
            GeneralManager.CurrentScreen.EndDraw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
