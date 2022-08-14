using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace nottouhou;

public class Player {
    private Vector2 position;
    private float speed;
    private float rotation;
    private Texture2D texture;

    public void Init(Vector2 newPosition, float newSpeed) {
        position = newPosition;
        speed = newSpeed;
    }

    public void Load(Texture2D newTexture) {
        texture = newTexture;
    }

    public void GetInput() {
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            position.X -= speed;
        } else if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            position.X += speed;
        }
        
    }
}