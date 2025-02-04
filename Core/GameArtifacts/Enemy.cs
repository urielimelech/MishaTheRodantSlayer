using Microsoft.Xna.Framework;
using MishaTheRodantSlayer.Core.Basics;

namespace MishaTheRodantSlayer.Core.GameArtifacts
{
    internal class Enemy : LivingGameObject
    {
        private Vector2 previousPosition;
        private string currentDirection;
        internal Enemy() : base()
        {
            currentDirection = Data.Directions.Right.ToString();
            frameNames = [
                "misha_walk_000",
                "misha_walk_001",
                "misha_walk_002"
            ];
            // controlSystem2D = new ControlSystem2D(Position);
            // controlSystem2D.AddMovementObserver(this);
            Health = 100;
            Damage = 1;
            Speed = 1;
        }
    }
}