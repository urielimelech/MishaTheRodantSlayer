using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;

namespace MishaTheRodantSlayer.Scenes
{
    internal class GameScene1 : Component
    {
        private Texture2D backgroundTexture;
        Player player;
        Camera camera;
        public GameScene1()
        {
            // LoadContent();
            player = new Player();
            camera = new Camera();
        }

        internal override void LoadContent(ContentManager content)
        {
            backgroundTexture = content.Load<Texture2D>("field_background");
            player.LoadContent(content);
            player.SetPosition(
                new Vector2(
                    Data.ScreenWidth / 2 - player.frameTextures[0].Width / 2,
                    Data.ScreenHeight / 2 - player.frameTextures[0].Height / 2
            ));
        }

        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            // Console.WriteLine($"{player.position}{player.rectangle}");
            camera.Follow(player.Position);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);
            backgroundDrawer(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
        private void backgroundDrawer(SpriteBatch spriteBatch)
        {
            int tilesX = (int)Math.Ceiling((double)Data.ScreenWidth / backgroundTexture.Width);
            int tilesY = (int)Math.Ceiling((double)Data.ScreenHeight / backgroundTexture.Height);

            // Draw the background texture multiple times to cover the screen
            for (int x = -1; x <= tilesX; x++)
            {
                for (int y = -1; y <= tilesY; y++)
                {
                    Vector2 position = new Vector2(x * backgroundTexture.Width, y * backgroundTexture.Height);
                    spriteBatch.Draw(backgroundTexture, position, Color.White);
                }
            }
        }
    }
}