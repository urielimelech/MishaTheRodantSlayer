using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;

namespace MishaTheRodantSlayer.Scenes
{
    internal class MenuScene : Component
    {
        private const int BUTTON_COUNT = 4;
        private Button[] buttonsArr = new Button[BUTTON_COUNT];
        private MouseState mouseState, previousMouseState;
        private Rectangle mouseRectangle = new Rectangle(0, 0, 1, 1);

        internal override void LoadContent(ContentManager content)
        {
            const int BUTTON_MARGIN = 150;
            for (int i = 0; i < BUTTON_COUNT; i++)
            {
                buttonsArr[i] = new Button
                {
                    TextureName = $"menu_00{i}"
                };
                buttonsArr[i].LoadContent(content);
                buttonsArr[i].Rectangle = new Rectangle(Data.ScreenWidth / 2 - buttonsArr[i].Texture.Width / 2, BUTTON_MARGIN + i * BUTTON_MARGIN, buttonsArr[i].Texture.Width, buttonsArr[i].Texture.Height);
            }
        }

        internal override void Update(GameTime gameTime)
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            mouseRectangle.X = mouseState.X;
            mouseRectangle.Y = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                if (mouseRectangle.Intersects(buttonsArr[0].Rectangle))
                {
                    Data.CurrentScene = Data.Screens.Game;
                }
                else if (mouseRectangle.Intersects(buttonsArr[1].Rectangle))
                {
                    Data.CurrentScene = Data.Screens.Settings;
                }
                // else if (mouseRectangle.Intersects(buttonsArr[2].rectangle))
                // {
                //     Data.CurrentScene = Data.Screens.Credits;
                // }
                else if (mouseRectangle.Intersects(buttonsArr[3].Rectangle))
                {
                    Data.ExitGame = true;
                }
            }
            if (mouseRectangle.Intersects(buttonsArr[0].Rectangle) && mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Data.CurrentScene = Data.Screens.Game;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < BUTTON_COUNT; i++)
            {
                mouseState = Mouse.GetState();
                buttonsArr[i].Draw(spriteBatch, mouseRectangle, mouseState);
            }
            spriteBatch.End();
        }
    }
}