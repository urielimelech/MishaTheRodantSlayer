using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MishaTheRodantSlayer.Core.Basics;

namespace MishaTheRodantSlayer.Core.GameArtifacts
{
    internal class Player : LivingGameObject, IObserver<bool>
    {
        private Vector2 previousPosition;
        private string currentDirection;
        private readonly ControlSystem2D controlSystem2D;
        private bool isMoving = false;

        public Player() : base(true)
        {
            currentDirection = Data.Directions.Right.ToString();
            SetFrameNames([
                "misha_walk_000",
                "misha_walk_001",
                "misha_walk_002"
            ]);
            controlSystem2D = new ControlSystem2D(GetPosition());
            controlSystem2D.AddMovementObserver(this);
            Health = 100;
            Damage = 1;
            Speed = 1;
        }

        internal void SetPosition(Vector2 position)
        {
            SetObjectPosition(position);
            SetRectangle(new Rectangle(
                (int)position.X,
                (int)position.Y,
                GetTextureWidth(),
                GetTextureHeight()
            ));
            controlSystem2D.SetObjectPosition(GetPosition());
        }

        internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            SetObjectPosition(controlSystem2D.KeyboardContorlSystem(Keyboard.GetState(), gameTime));
            Vector2 currentPosition = GetPosition();
            if (previousPosition != currentPosition)
            {
                if (currentPosition.X > previousPosition.X)
                {
                    currentDirection = Data.Directions.Right.ToString();
                }
                else if (currentPosition.X < previousPosition.X)
                {
                    currentDirection = Data.Directions.Left.ToString();
                }
                if (isMoving)
                {
                    base.Update(gameTime);
                }
                previousPosition = currentPosition;
            }
            if (Health <= 0)
            {
                controlSystem2D.RemoveMovementObserver(this);
                controlSystem2D.ToggleGameOver();
            }
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            float rotation = 0f;

            if (currentDirection == Data.Directions.Left.ToString())
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (currentDirection == Data.Directions.Right.ToString())
            {
                spriteEffects = SpriteEffects.None;
            }
            if (Health <= 0)
            {
                rotation = 1f;
            }
            if (isMoving)
            {
                spriteBatch.Draw(GetFrameTexture(GetCurrentFrameIndex()), GetBoundingBox(), null, Color.White, rotation, Vector2.Zero, spriteEffects, 0f);
            }
            else
            {
                spriteBatch.Draw(GetFrameTexture(0), GetBoundingBox(), null, Color.White, rotation, Vector2.Zero, spriteEffects, 0f);
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Message);
            throw new NotImplementedException();
        }

        public void OnNext(bool value)
        {
            isMoving = value;
        }
    }
}