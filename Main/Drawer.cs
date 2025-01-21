using Microsoft.Xna.Framework;

namespace MishaTheRodantSlayer.Main;

public partial class MishaTheRodantSlayer
{
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        gameScene.DrawScene(_spriteBatch, gameScene.GetCameraPosition(), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        mainCharacter.Draw(_spriteBatch, GraphicsDevice);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}