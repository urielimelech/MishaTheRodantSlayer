using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MishaTheRodantSlayer.Core.Basics
{
    public class ControlSystem2D
    {
        Vector2 objectPosition;
        float objectSpeed;
        int deadZone;
        private readonly Notifier<bool> movementNotifier;
        private bool isGameOver;

        public ControlSystem2D(Vector2 objectPosition)
        {
            this.objectPosition = objectPosition;
            objectSpeed = 100f;
            deadZone = 4096;
            movementNotifier = new Notifier<bool>();
            isGameOver = false;
        }
        public ControlSystem2D(Vector2 objectPosition, float objectSpeed)
        {
            this.objectPosition = objectPosition;
            this.objectSpeed = objectSpeed;
            deadZone = 4096;
            movementNotifier = new Notifier<bool>();
            isGameOver = false;
        }
        public void ToggleGameOver()
        {
            isGameOver = !isGameOver;
        }

        public void SetDeadZone(int deadZone)
        {
            this.deadZone = deadZone;
        }
        public void SetObjectSpeed(float objectSpeed)
        {
            this.objectSpeed = objectSpeed;
        }
        public void SetObjectPosition(Vector2 objectPosition)
        {
            this.objectPosition = objectPosition;
        }

        public Vector2 KeyboardContorlSystem(KeyboardState kState, GameTime gameTime)
        {
            if (isGameOver)
            {
                return objectPosition;
            }
            float updatedObjectSpeed = objectSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var prevPosition = objectPosition;
            if (kState.IsKeyDown(Keys.Up))
            {
                objectPosition.Y -= updatedObjectSpeed;
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                objectPosition.Y += updatedObjectSpeed;
            }
            if (kState.IsKeyDown(Keys.Left))
            {
                objectPosition.X -= updatedObjectSpeed;
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                objectPosition.X += updatedObjectSpeed;
            }
            if (prevPosition != objectPosition)
                NotifyMovement(true);
            else
                NotifyMovement(false);
            return objectPosition;
        }
        public Vector2 JoystickControlSystem(JoystickState jState, GameTime gameTime)
        {
            if (isGameOver)
            {
                return objectPosition;
            }
            float updatedObjectSpeed = objectSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var prevPosition = objectPosition;

            if (jState.Axes[1] < -deadZone)
            {
                objectPosition.Y -= updatedObjectSpeed;
            }
            if (jState.Axes[1] > deadZone)
            {
                objectPosition.Y += updatedObjectSpeed;
            }
            if (jState.Axes[0] < -deadZone)
            {
                objectPosition.X -= updatedObjectSpeed;
            }
            if (jState.Axes[0] > deadZone)
            {
                objectPosition.X += updatedObjectSpeed;
            }
            if (prevPosition != objectPosition)
                NotifyMovement(true);
            else
                NotifyMovement(false);
            return objectPosition;
        }

        public Vector2 GamePadControlSystem(GamePadState gpState, GameTime gameTime)
        {
            if (isGameOver)
            {
                return objectPosition;
            }
            float updatedObjectSpeed = objectSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var prevPosition = objectPosition;
            if (gpState.ThumbSticks.Left.Y < -deadZone)
            {
                objectPosition.Y -= updatedObjectSpeed;
            }
            if (gpState.ThumbSticks.Left.Y > deadZone)
            {
                objectPosition.Y += updatedObjectSpeed;
            }
            if (gpState.ThumbSticks.Left.X < -deadZone)
            {
                objectPosition.X -= updatedObjectSpeed;
            }
            if (gpState.ThumbSticks.Left.X > deadZone)
            {
                objectPosition.X += updatedObjectSpeed;
            }
            if (prevPosition != objectPosition)
                NotifyMovement(true);
            else
                NotifyMovement(false);
            return objectPosition;
        }

        public void AddMovementObserver(IObserver<bool> observer)
        {
            movementNotifier.AddObserver(observer);
        }

        public void RemoveMovementObserver(IObserver<bool> observer)
        {
            movementNotifier.RemoveObserver(observer);
        }
        public void NotifyMovement(bool value)
        {
            movementNotifier.Notify(value);
        }
    }
}