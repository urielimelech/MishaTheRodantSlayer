// using GameData.Camera;
// using GameData.Character;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MishaTheRodantSlayer.Core.Basics;
using MishaTheRodantSlayer.Core.GameArtifacts;
using MishaTheRodantSlayer.Managers;
using MishaTheRodantSlayer.Scenes;

namespace MishaTheRodantSlayer.Core.MainGameProcess;
public partial class GameProcess : Game
{
    // GameScene gameScene;
    // MenuScene menuScene;
    public static GraphicsDeviceManager graphics;
    private GameStateManager gsm;
    private SpriteBatch _spriteBatch;
    // private MainCharacter mainCharacter;

    public GameProcess()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        // gameScene = new GameScene();
        // menuScene = new MenuScene();
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = Data.ScreenWidth;
        graphics.PreferredBackBufferHeight = Data.ScreenHeight;
        graphics.ApplyChanges();

        gsm = new GameStateManager();

        // gameScene.Initialize();
        // mainCharacter = new MainCharacter();

        base.Initialize();
    }
}