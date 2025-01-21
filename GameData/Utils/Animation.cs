using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameData.Utils;
public class Animation
{
    private List<Texture2D> frames;
    private int currentFrame;
    private double frameTime;
    private double timeCounter;

    public Animation(List<Texture2D> frames, double frameTime)
    {
        this.frames = frames;
        this.frameTime = frameTime;
        currentFrame = 0;
        timeCounter = 0;
    }

    public void Update(GameTime gameTime)
    {
        timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
        if (timeCounter >= frameTime)
        {
            currentFrame = (currentFrame + 1) % frames.Count;
            timeCounter -= frameTime;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(frames[currentFrame], position, Color.White);
    }
}