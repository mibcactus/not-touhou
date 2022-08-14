using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace nottouhou.Content;

public class entity
{
    public Vector2 position;
    public float speed;
    public float rotation = 0f;
    public Texture2D texture;

    public int screenWidth, screenHeight;

    public entity(int newscreenWidth, int newscreenHeight, Vector2 newPosition, float newSpeed)
    {
        screenHeight = newscreenHeight;
        screenWidth = newscreenWidth;
        position = newPosition;
        speed = newSpeed;
    }

    public void setPosition(Vector2 newPosition)
    {
        position = newPosition;
    }

    public void AddTexture(Texture2D newTexture) {
        texture = newTexture;
    }

    public void checkPosition()
    {
        if (position.X > screenWidth - texture.Width / 2) {
            position.X = screenWidth - texture.Width / 2;
        } else if (position.X < texture.Width / 2) {
            position.X = texture.Width / 2;
        }
        
        if (position.Y > screenHeight- texture.Height / 2) {
            position.Y = screenHeight- texture.Height / 2;
        } else if (position.Y < texture.Height / 2) {
            position.Y = texture.Height / 2;
        }
    }
}