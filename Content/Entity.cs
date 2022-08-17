using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace nottouhou.Content;

public class Entity : GraphicsManager
{
    protected float speed;
    public float rotation = 0f;

    private Vector2 origin, dest;

    public int screenWidth, screenHeight;

    public Entity(int newscreenWidth, int newscreenHeight, Vector2 newPosition, float newSpeed) {
        screenHeight = newscreenHeight;
        screenWidth = newscreenWidth;
        position = newPosition;
        speed = newSpeed;
    }

    public void setDest(Vector2 destination) {
        origin = position;
        dest = destination;
    }

    public void MoveTowards(float elapsedGameTime) {
        float distance = speed * elapsedGameTime;
        if (position != dest && position != origin) {
            position.X += distance;
            position.Y += distance;
        }
    }
    
    public void CheckPosition()
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
        
        // if colluded with:
        // change colour to red/change texture
    }

}