using GameData.Camera;
using GameData.Character;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MishaTheRodantSlayer.Main;

public partial class MishaTheRodantSlayer : Game
{
    GameScene gameScene;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MainCharacter mainCharacter;

    public MishaTheRodantSlayer()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        gameScene = new GameScene();
    }

    protected override void Initialize()
    {
        gameScene.Initialize();
        mainCharacter = new MainCharacter();

        base.Initialize();
    }
}