using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;
using MishaTheRodantSlayer.Scenes;

namespace MishaTheRodantSlayer.Managers
{
    internal partial class GameStateManager : Component
    {
        private MenuScene menuScene = new MenuScene();
        private GameScene1 gameScene = new GameScene1();

        internal override void LoadContent(ContentManager content)
        {
            menuScene.LoadContent(content);
            gameScene.LoadContent(content);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentScene)
            {
                case Data.Screens.Menu:
                    menuScene.Update(gameTime);
                    break;
                case Data.Screens.Game:
                    gameScene.Update(gameTime);
                    break;
                case Data.Screens.Settings:
                    break;
                default:
                    break;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentScene)
            {
                case Data.Screens.Menu:
                    menuScene.Draw(spriteBatch);
                    break;
                case Data.Screens.Game:
                    gameScene.Draw(spriteBatch);
                    break;
                case Data.Screens.Settings:
                    break;
                default:
                    break;
            }
        }

        // public GameState CurrentGameState { get; private set; }
    }
}