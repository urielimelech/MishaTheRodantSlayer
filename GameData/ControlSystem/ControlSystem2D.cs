using System;
using GameData.Utils.DesignPatterns.Notifier;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameData.ControlSystem;
public class ControlSystem2D
{
    Vector2 objectPosition;
    float objectSpeed;
    int deadZone;
    private readonly Notifier<bool> movementNotifier;

    public ControlSystem2D(Vector2 objectPosition)
    {
        this.objectPosition = objectPosition;
        objectSpeed = 100f;
        deadZone = 4096;
        movementNotifier = new Notifier<bool>();
    }
    public ControlSystem2D(Vector2 objectPosition, float objectSpeed)
    {
        this.objectPosition = objectPosition;
        this.objectSpeed = objectSpeed;
        deadZone = 4096;
        movementNotifier = new Notifier<bool>();
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