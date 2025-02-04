using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Core.Basics
{
    internal class GameObject : Component
    {
        internal Vector2 Position { get; set; }
        internal Texture2D Texture { get; set; }
        internal string TextureName { get; set; }
        internal Rectangle Rectangle { get; set; }

        public GameObject()
        {

        }
        // public GameObject(string textureName)
        // {
        //     this.textureName = textureName;
        // }

        internal override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>(TextureName);
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        internal override void Update(GameTime gameTime)
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}