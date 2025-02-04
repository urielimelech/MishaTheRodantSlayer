namespace MishaTheRodantSlayer.Core.Basics
{
    internal class LivingGameObject : AnimatedGameObject
    {
        internal int Health { get; set; }
        internal int Damage { get; set; }
        internal int Speed { get; set; }
        internal LivingGameObject() : base() { }
    }
}