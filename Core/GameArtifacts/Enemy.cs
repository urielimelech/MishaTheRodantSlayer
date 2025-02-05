using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MishaTheRodantSlayer.Core.Basics;

namespace MishaTheRodantSlayer.Core.GameArtifacts
{
    internal class Enemy : LivingGameObject
    {
        private Vector2 previousPosition;
        private Vector2 target;
        private string currentDirection;
        private readonly Random random;

        internal Enemy(Vector2 target) : base(false)
        {
            random = new Random();
            currentDirection = Data.Directions.Right.ToString();
            SetTextureName("rodant");
            this.target = target;
            Health = 100;
            Damage = 1;
            Speed = 15;
        }
        internal void SetTargetPosition(Vector2 target)
        {
            this.target = target;
        }
        internal override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            SetObjectPosition(GetRandomSpawnPosition());
            Vector2 currentPosition = GetPosition();
            SetRectangle(new Rectangle(
                (int)currentPosition.X,
                (int)currentPosition.Y,
                GetTextureWidth(),
                GetTextureHeight()
            ));
        }
        internal Vector2 GetRandomSpawnPosition()
        {
            int screenWidth = Data.ScreenWidth;
            int screenHeight = Data.ScreenHeight;
            int side = random.Next(4);
            return side switch
            {
                0 => new Vector2(target.X - screenWidth / 2 + random.Next(screenWidth), target.Y - screenHeight / 2),
                1 => new Vector2(target.X - screenWidth / 2 + random.Next(screenWidth), target.Y - screenHeight / 2 + screenHeight),
                2 => new Vector2(target.X - screenWidth / 2, target.Y - screenHeight / 2 + random.Next(screenHeight)),
                3 => new Vector2(target.X - screenWidth / 2 + screenWidth, target.Y - screenHeight / 2 + random.Next(screenHeight)),
                _ => Vector2.Zero,
            };
        }
        internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Vector2 currentPosition = GetPosition();
            Vector2 direction = target - currentPosition;
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
            currentPosition += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetObjectPosition(currentPosition);
            if (currentPosition.X > previousPosition.X)
            {
                currentDirection = Data.Directions.Left.ToString();
            }
            else if (currentPosition.X < previousPosition.X)
            {
                currentDirection = Data.Directions.Right.ToString();
            }
            previousPosition = currentPosition;
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;

            if (currentDirection == Data.Directions.Left.ToString())
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (currentDirection == Data.Directions.Right.ToString())
            {
                spriteEffects = SpriteEffects.None;
            }
            spriteBatch.Draw(GetFrameTexture(GetCurrentFrameIndex()), GetBoundingBox(), null, Color.White, 0f, Vector2.Zero, spriteEffects, 0f);
        }
    }
}