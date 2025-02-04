using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;

namespace MishaTheRodantSlayer.Core.MainGameProcess;
public partial class GameProcess : Game
{
    protected override void Update(GameTime gameTime)
    {
        // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        //     Exit();

        gsm.Update(gameTime);

        if (Data.ExitGame)
        {
            Exit();
        }

        // mainCharacter.Update(Keyboard.GetState(), gameTime);
        // gameScene.UpdateCameraPosition(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, mainCharacter.GetCharacterPosition());

        base.Update(gameTime);
    }
}