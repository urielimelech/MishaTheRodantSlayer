using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameData.Camera;
public class GameScene
{
    Texture2D backgroundTexture;
    Vector2 cameraPosition;

    public GameScene()
    {
        backgroundTexture = null;
    }
    public GameScene(Texture2D backgroundTexture)
    {
        this.backgroundTexture = backgroundTexture;
    }
    public void Initialize()
    {
        cameraPosition = Vector2.Zero;
    }
    public void SetBackgroundTexture(Texture2D backgroundTexture)
    {
        this.backgroundTexture = backgroundTexture;
    }
    public Texture2D LoadBackgroundContent()
    {
        return backgroundTexture;
    }
    public void DrawScene(SpriteBatch spriteBatch, Vector2 cameraPosition, int screenWidth, int screenHeight)
    {
        int backgroundTextureWidth = backgroundTexture.Width;
        int backgroundTextureHeight = backgroundTexture.Height;

        float offsetX = cameraPosition.X % backgroundTextureWidth;
        float offsetY = cameraPosition.Y % backgroundTextureHeight;

        for (int x = -1; x <= screenWidth / backgroundTextureWidth + 1; x++)
        {
            for (int y = -1; y <= screenHeight / backgroundTextureHeight + 1; y++)
            {
                spriteBatch.Draw(backgroundTexture,
                new Vector2(x * backgroundTextureWidth - offsetX, y * backgroundTextureHeight - offsetY), Color.White);
            }
        }
    }
    public void UpdateCameraPosition(int screenWidth, int screenHeight, Vector2 playerPosition)
    {
        cameraPosition = playerPosition - new Vector2(screenWidth / 2, screenHeight / 2);
    }
    public Vector2 GetCameraPosition()
    {
        return cameraPosition;
    }
}