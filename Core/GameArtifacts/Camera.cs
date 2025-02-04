using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MishaTheRodantSlayer.Core.Basics;

namespace MishaTheRodantSlayer.Core.GameArtifacts
{
    internal class Camera : Component
    {
        public Matrix Transform { get; private set; }
        public void Follow(Vector2 target)
        {
            var position = Matrix.CreateTranslation(
                -target.X + Data.ScreenWidth / 2,
                -target.Y + Data.ScreenHeight / 2,
                0);
            // var offset = Matrix.CreateTranslation(
            //     Data.ScreenWidth / 2,
            //     Data.ScreenHeight / 2,
            //     0);
            // Transform = position * offset;

            Transform = position;
        }
        internal override void LoadContent(ContentManager content)
        {
            // throw new NotImplementedException();
        }
        internal override void Update(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            // throw new NotImplementedException();
        }
    }
}