using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;

namespace MishaTheRodantSlayer.Scenes
{
    internal class GameScene : Component
    {
        private Texture2D backgroundTexture;
        private Texture2D gameOverTexture;
        private readonly Player Player;
        private readonly Camera Camera;
        private readonly Dictionary<Enemy, double> Enemies;
        private ContentManager content;
        private double SpawnTimer;
        private const double SpawnInterval = 2.0;
        private bool isGameOver;
        private const double damageInterval = 1.0;
        public GameScene()
        {
            // LoadContent();
            Player = new Player();
            Camera = new Camera();
            Enemies = [];
            SpawnTimer = 0;
            isGameOver = false;
        }

        internal override void LoadContent(ContentManager content)
        {
            this.content = content;
            backgroundTexture = content.Load<Texture2D>("field_background");
            Player.LoadContent(content);
            Player.SetPosition(
                new Vector2(
                    Data.ScreenWidth / 2 - Player.GetTextureWidth() / 2,
                    Data.ScreenHeight / 2 - Player.GetTextureHeight() / 2
            ));
            gameOverTexture = content.Load<Texture2D>("game_over");
        }

        internal override void Update(GameTime gameTime)
        {
            if (!isGameOver)
            {
                Player.Update(gameTime);
                Vector2 playerPosition = Player.GetPosition();
                Camera.Follow(playerPosition);

                SpawnTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (SpawnTimer >= SpawnInterval)
                {
                    SpawnEnemy();
                    SpawnTimer = 0;
                }
                foreach (Enemy enemy in Enemies.Keys)
                {
                    if (enemy.GetFrameTexture(enemy.GetCurrentFrameIndex()) == null)
                    {
                        enemy.LoadContent(content);
                    }
                    enemy.SetTargetPosition(playerPosition);
                    enemy.Update(gameTime);
                    Enemies[enemy] += gameTime.ElapsedGameTime.TotalSeconds;
                    CheckCollision(enemy);
                }
                if (Player.Health <= 0)
                {
                    isGameOver = true;
                }
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Camera.Transform);
            BackgroundDrawer(spriteBatch);
            Player.Draw(spriteBatch);
            foreach (Enemy enemy in Enemies.Keys)
            {
                enemy.Draw(spriteBatch);
            }
            if (isGameOver)
            {
                Vector3 cameraPosition = Camera.Transform.Translation;
                Vector2 gameOverPosition = new(
                    -cameraPosition.X + Data.ScreenWidth / 2 - gameOverTexture.Width / 2,
                    -cameraPosition.Y + Data.ScreenHeight / 2 - gameOverTexture.Height / 2
                );
                spriteBatch.Draw(gameOverTexture, gameOverPosition, Color.White);
                Enemies.Clear();
            }
            spriteBatch.End();
        }
        private void BackgroundDrawer(SpriteBatch spriteBatch)
        {
            Vector3 cameraPosition = Camera.Transform.Translation;
            int textureWidth = backgroundTexture.Width;
            int textureHeight = backgroundTexture.Height;

            // Calculate the starting position based on the camera's position
            int startX = -(int)Math.Floor(cameraPosition.X / textureWidth) * textureWidth;
            int startY = -(int)Math.Floor(cameraPosition.Y / textureHeight) * textureHeight;

            // Draw the background texture multiple times to cover the screen
            for (int x = startX - (textureWidth * 2); x <= startX + (Data.ScreenWidth * 2); x += textureWidth)
            {
                for (int y = startY - (textureHeight * 2); y <= startY + (Data.ScreenHeight * 2); y += textureHeight)
                {
                    spriteBatch.Draw(backgroundTexture, new Vector2(x, y), Color.White);
                }
            }
        }
        private void SpawnEnemy()
        {
            Enemies.Add(new Enemy(Player.GetPosition()), 0);
        }
        private void CheckCollision(Enemy enemy)
        {
            if (Player.GetBoundingBox().Intersects(enemy.GetBoundingBox()))
            {
                if (Enemies[enemy] >= damageInterval)
                {
                    Player.Health -= enemy.Damage;
                    Console.WriteLine($"Hit: {enemy.Damage}");
                    Enemies[enemy] = 0;
                }
            }
        }
    }
}