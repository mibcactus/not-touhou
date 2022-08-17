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
    private float elapsedGameTime;

    private int screenWidth;
    private int screenHeight;
    
    private Vector2 centre;
    private Color[] colours = {Color.Red, Color.Purple, Color.Blue, Color.Azure, Color.Green, Color.Yellow, Color.Orange};
    private int currentColour = 0;

    private string[] debugDirections = new[] {"left", "right", "up", "down"};

    private DateTime timeWhenPressedDebug = new DateTime();
    private bool debug = false;
    
    
    private SpriteFont _font;
    
    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        screenWidth = _graphics.PreferredBackBufferWidth;
        screenHeight = _graphics.PreferredBackBufferHeight;
        centre = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        _player  = new Player(screenWidth, screenHeight, centre, 250);
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("file");
        _player.SetTexture(Content.Load<Texture2D>("crab"));
        
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        if (Keyboard.GetState().IsKeyDown(Keys.R) && DateTime.Now > timeWhenPressedDebug.AddSeconds(0.2)) {
            debug = !debug;
            timeWhenPressedDebug = DateTime.Now;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.G)) {
            if (currentColour >= 6) {
                currentColour = 0;
            } else {
                currentColour++;
            }
        }
        

        elapsedGameTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
        _player.GetInput(elapsedGameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CadetBlue);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_player.texture, _player.position, colours[currentColour]);

        if(debug) {
            _spriteBatch.DrawString(_font, "DEBUG", new Vector2(20,20), Color.Black);
            for (int i = 0; i < 4; i++) {
                _spriteBatch.DrawString(_font, debugDirections[i] + ": " + _player.currentDirections[i],
                    new Vector2(20, 20 * (i + 2)), Color.Black);
            }
            
        }
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
