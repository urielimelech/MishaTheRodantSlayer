using Microsoft.Xna.Framework;

namespace MishaTheRodantSlayer.Core.MainGameProcess;

public partial class GameProcess : Game
{
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        gsm.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}