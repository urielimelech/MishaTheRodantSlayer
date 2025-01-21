using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MishaTheRodantSlayer.Main;

public partial class MishaTheRodantSlayer : Game
{
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        mainCharacter.Update(Keyboard.GetState(), gameTime);
        gameScene.UpdateCameraPosition(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, mainCharacter.GetCharacterPosition());

        base.Update(gameTime);
    }
}