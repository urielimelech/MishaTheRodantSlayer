using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Main;

public partial class MishaTheRodantSlayer : Game
{
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        gameScene.SetBackgroundTexture(Content.Load<Texture2D>("field_background"));
        mainCharacter.SetCharacterTexture(Content.Load<Texture2D>(mainCharacter.GetStandingFrameName()));
        List<Texture2D> movementFrame = mainCharacter.GetMovementFrameNames().ConvertAll(Content.Load<Texture2D>);
        mainCharacter.SetAnimationTextures(movementFrame);
    }
}
