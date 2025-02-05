using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Core.Basics
{
    internal class LivingGameObject : Component
    {
        internal int Health { get; set; }
        internal int Damage { get; set; }
        internal int Speed { get; set; }

        private AnimatedGameObject AnimatedGameObject { get; set; }
        private GameObject GameObject { get; set; }
        private bool useAnimation;

        internal LivingGameObject(bool useAnimation) : base()
        {
            this.useAnimation = useAnimation;
            if (useAnimation)
            {
                AnimatedGameObject = new AnimatedGameObject();
            }
            else
            {
                GameObject = new GameObject();
            }
        }
        internal int GetCurrentFrameIndex()
        {
            if (useAnimation)
            {
                return AnimatedGameObject.currentFrame;
            }
            return 0;
        }
        internal Texture2D GetFrameTexture(int frameIndex)
        {
            if (useAnimation)
            {
                return AnimatedGameObject.frameTextures[frameIndex];
            }
            return GameObject.Texture;
        }
        internal void SetRectangle(Rectangle rectangle)
        {
            if (useAnimation)
            {
                AnimatedGameObject.Rectangle = rectangle;
            }
            else
            {
                GameObject.Rectangle = rectangle;
            }
        }
        internal Rectangle GetBoundingBox()
        {
            if (useAnimation)
            {
                return AnimatedGameObject.GetBoundingBox();
            }
            return GameObject.GetBoundingBox();
        }

        internal int GetTextureWidth()
        {
            if (useAnimation)
            {
                return AnimatedGameObject.frameTextures[0].Width;
            }
            return GameObject.Texture.Width;
        }
        internal int GetTextureHeight()
        {
            if (useAnimation)
            {
                return AnimatedGameObject.frameTextures[0].Height;
            }
            return GameObject.Texture.Height;
        }

        internal override void LoadContent(ContentManager content)
        {
            if (useAnimation)
            {
                AnimatedGameObject.LoadContent(content);
            }
            else
            {
                GameObject.LoadContent(content);
            }
        }

        internal override void Update(GameTime gameTime)
        {
            if (useAnimation)
            {
                AnimatedGameObject.Update(gameTime);
            }
            else
            {
                GameObject.Update(gameTime);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            if (useAnimation)
            {
                AnimatedGameObject.Draw(spriteBatch);
            }
            else
            {
                GameObject.Draw(spriteBatch);
            }
        }

        internal void SetObjectPosition(Vector2 position)
        {
            if (useAnimation)
            {
                AnimatedGameObject.Position = position;
            }
            else
            {
                GameObject.Position = position;
            }
        }

        internal Vector2 GetPosition()
        {
            if (useAnimation)
            {
                return AnimatedGameObject.Position;
            }
            else
            {
                return GameObject.Position;
            }
        }

        internal void SetTextureName(string textureName)
        {
            if (!useAnimation)
            {
                GameObject.TextureName = textureName;
            }
        }

        internal void SetFrameNames(string[] frameNames)
        {
            if (useAnimation)
            {
                AnimatedGameObject.frameNames = frameNames;
            }
        }
    }
}