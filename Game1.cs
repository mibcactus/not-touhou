using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = System.Numerics.Vector2;

namespace nottouhou;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private Vector3 colour;
    private float elapsedGameTime;

    private int screenWidth;
    private int screenHeight;
    
    private Vector2 centre;
    private Color[] colours = {Color.Red, Color.Purple, Color.Blue, Color.Cyan,  Color.Azure, Color.Green, Color.GreenYellow, Color.Yellow, Color.Orange, Color.Tomato};
    private int currentColour = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        screenWidth = _graphics.PreferredBackBufferWidth;
        screenHeight = _graphics.PreferredBackBufferHeight;
        centre = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        _player  = new Player(screenWidth, screenHeight, centre, 250);
        colour = new Vector3(0, 0, 0);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _player.SetTexture(Content.Load<Texture2D>("tim muller yoghurt"));
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        elapsedGameTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

        _player.GetInput(elapsedGameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        
        _player.Draw(colours[currentColour]);
        
        if (currentColour == colours.Length)
            currentColour = 0;
        else {
            currentColour++;
        }

        base.Draw(gameTime);
    }
}
