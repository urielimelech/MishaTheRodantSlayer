using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;

namespace MishaTheRodantSlayer.Core.MainGameProcess;
public partial class GameProcess : Game
{
    protected override void Update(GameTime gameTime)
    {
        gsm.Update(gameTime);

        if (Data.ExitGame)
        {
            Exit();
        }
        
        base.Update(gameTime);
    }
}