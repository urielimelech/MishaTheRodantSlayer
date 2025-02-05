using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Core.MainGameProcess;
public partial class GameProcess : Game
{
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        gsm.LoadContent(Content);
    }
}
