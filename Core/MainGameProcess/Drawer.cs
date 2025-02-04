using Microsoft.Xna.Framework;

namespace MishaTheRodantSlayer.Core.MainGameProcess;

public partial class GameProcess : Game
{
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // _spriteBatch.Begin();
        gsm.Draw(_spriteBatch);
        // gameScene.DrawScene(_spriteBatch, gameScene.GetCameraPosition(), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        // mainCharacter.Draw(_spriteBatch, GraphicsDevice);
        // _spriteBatch.End();

        base.Draw(gameTime);
    }
}