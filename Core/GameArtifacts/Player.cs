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

        public Player() : base()
        {
            currentDirection = Data.Directions.Right.ToString();
            frameNames = [
                "misha_walk_000",
                "misha_walk_001",
                "misha_walk_002"
            ];
            controlSystem2D = new ControlSystem2D(Position);
            controlSystem2D.AddMovementObserver(this);
            Health = 100;
            Damage = 1;
            Speed = 1;
        }

        internal void SetPosition(Vector2 position)
        {
            this.Position = position;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, frameTextures[0].Width, frameTextures[0].Height);
            controlSystem2D.SetObjectPosition(Position);
        }

        internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Position = controlSystem2D.KeyboardContorlSystem(Keyboard.GetState(), gameTime);
            if (previousPosition != Position)
            {
                if (Position.X > previousPosition.X)
                {
                    currentDirection = Data.Directions.Right.ToString();
                }
                else if (Position.X < previousPosition.X)
                {
                    currentDirection = Data.Directions.Left.ToString();
                }
                if (isMoving)
                {
                    base.Update(gameTime);
                }
                previousPosition = Position;
            }
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

            if (isMoving)
            {
                spriteBatch.Draw(frameTextures[currentFrame], Rectangle, null, Color.White, 0f, Vector2.Zero, spriteEffects, 0f);
            }
            else
            {
                spriteBatch.Draw(frameTextures[0], Rectangle, null, Color.White, 0f, Vector2.Zero, spriteEffects, 0f);
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