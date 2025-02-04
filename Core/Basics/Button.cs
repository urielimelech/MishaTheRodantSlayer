using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MishaTheRodantSlayer.Core.Basics
{
    internal class Button : GameObject
    {
        public Button() : base() { }

        internal void Draw(SpriteBatch spriteBatch, Rectangle mouseRectangle, MouseState mouseState)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
            if (mouseRectangle.Intersects(Rectangle))
            {
                spriteBatch.Draw(Texture, Rectangle, Color.Gray);
            }
            if (mouseRectangle.Intersects(Rectangle) && mouseState.LeftButton == ButtonState.Pressed)
            {
                spriteBatch.Draw(Texture, Rectangle, Color.DarkGray);
            }
        }

    }
}