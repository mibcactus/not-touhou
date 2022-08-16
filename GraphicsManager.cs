using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace nottouhou;

public class GraphicsManager
{
    public Texture2D texture;
    public Vector2 position;
    private GraphicsDeviceManager _graphics;

    private SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);

    public GraphicsManager()
    {
        _graphics = new GraphicsDeviceManager(this);
    }


    public void SetTexture(Texture2D newTexture) {
        texture = newTexture;
    }
    
    public void Draw()
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(texture, position, Color.White);
        _spriteBatch.End();
        
    }

    public void Draw(Color colour)
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(texture, position, colour);
        _spriteBatch.End();
    }
    
}