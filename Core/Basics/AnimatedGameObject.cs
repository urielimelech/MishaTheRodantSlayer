using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Core.Basics
{
    internal class AnimatedGameObject : GameObject
    {
        internal string[] frameNames;
        internal List<Texture2D> frameTextures;
        internal int currentFrame;
        internal double frameTime;
        private double timeCounter;

        internal AnimatedGameObject() : base()
        {
            frameTextures = new List<Texture2D>();
            currentFrame = 0;
            frameTime = 0.2;
            timeCounter = 0;
        }

        internal override void LoadContent(ContentManager content)
        {
            foreach (string frameName in frameNames)
            {
                frameTextures.Add(content.Load<Texture2D>(frameName));
            }
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, frameTextures[0].Width, frameTextures[0].Height);
        }

        internal override void Update(GameTime gameTime)
        {
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= frameTime)
            {
                currentFrame = (currentFrame + 1) % frameTextures.Count;
                timeCounter -= frameTime;
            }
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, frameTextures[0].Width, frameTextures[0].Height);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(frameTextures[currentFrame], Rectangle, Color.White);
        }
    }
}
// public class Animation
// {
//     private List<Texture2D> frames;
//     private int currentFrame;
//     private double frameTime;
//     private double timeCounter;

//     public Animation(List<Texture2D> frames, double frameTime)
//     {
//         this.frames = frames;
//         this.frameTime = frameTime;
//         currentFrame = 0;
//         timeCounter = 0;
//     }

//     public void Update(GameTime gameTime)
//     {
//         timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
//         if (timeCounter >= frameTime)
//         {
//             currentFrame = (currentFrame + 1) % frames.Count;
//             timeCounter -= frameTime;
//         }
//     }

//     public void Draw(SpriteBatch spriteBatch, Vector2 Position)
//     {
//         spriteBatch.Draw(frames[currentFrame], Position, Color.White);
//     }
// }