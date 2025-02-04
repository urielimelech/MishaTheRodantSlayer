using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Core.Basics
{
    internal abstract class Component
    {
        internal abstract void LoadContent(ContentManager content);
        internal abstract void Draw(SpriteBatch spriteBatch);
        internal abstract void Update(GameTime gameTime);
    }
}