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
    private Texture2D bgTexture;

    private int screenWidth;
    private int screenHeight;
    private int bgTexWidth;
    
    private Vector2 centre;
    private Color[] colours = {Color.White, Color.Red, Color.Purple, Color.Blue, Color.Azure, Color.Yellow, Color.Orange};
    private int currentColour = 0;

    private string[] debugDirections = new[] {"left", "right", "up", "down"};

    private DateTime timeWhenPressedDebug = new DateTime();
    private bool debug = false;
    private bool attack = false;
    
    
    private SpriteFont _font;
    
    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        screenWidth = _graphics.PreferredBackBufferWidth;
        screenHeight = _graphics.PreferredBackBufferHeight;
        centre = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        //IsFixedTimeStep = true;
        //TargetElapsedTime = new TimeSpan(0,0,0,1/60);
    }

    protected override void Initialize() {
        _player  = new Player(screenWidth, screenHeight, centre, 250);
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("file");
        _player.SetTexture(Content.Load<Texture2D>("griffin"));
        bgTexture = Content.Load<Texture2D>("sky");
        bgTexWidth = bgTexture.Width;

    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        if (Keyboard.GetState().IsKeyDown(Keys.R) && DateTime.Now > timeWhenPressedDebug.AddSeconds(0.2)) {
            debug = !debug;
            timeWhenPressedDebug = DateTime.Now;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.G) && DateTime.Now > timeWhenPressedDebug.AddSeconds(0.2)) {
            if (currentColour >= 6) {
                currentColour = 0;
            } else {
                currentColour++;
            }
            timeWhenPressedDebug = DateTime.Now;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Space) && DateTime.Now > timeWhenPressedDebug.AddSeconds(0.2))
            attack = true;
        else {
            attack = false;
        }
        

        //elapsedGameTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
        _player.GetInput((float) gameTime.ElapsedGameTime.TotalSeconds);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CadetBlue);

        
        
        
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        
        for (int j = 0; j < (screenWidth/bgTexWidth)+1; j++) { 
            for (int k = 0; k < (screenHeight/bgTexWidth)+1; k++) {
                _spriteBatch.Draw(bgTexture, new Vector2(j*bgTexWidth, k*bgTexWidth), Color.White);
            }
        }
        _spriteBatch.Draw(_player.texture, _player.position, colours[currentColour]);

        if(debug) {
            _spriteBatch.DrawString(_font, "DEBUG (press r)", new Vector2(20,20), Color.Black);
            for (int i = 0; i < 4; i++)
                _spriteBatch.DrawString(_font, debugDirections[i] + ": " + _player.currentDirections[i], new Vector2(20, 20 * (i + 2)), Color.Black);
            
            _spriteBatch.DrawString(_font, "X Position: " + _player.position.X, new Vector2(20, 120) , Color.Black);
            _spriteBatch.DrawString(_font, "Y Position: " + _player.position.Y, new Vector2(20, 140) , Color.Black);
            _spriteBatch.DrawString(_font, "Player size: " + _player.texture.Width + " x " + _player.texture.Width, new Microsoft.Xna.Framework.Vector2(20, 180), Color.Black);
            _spriteBatch.DrawString(_font, "Attack: " + attack, new Vector2(20, 200), Color.Black );
        }
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    //private void Attack() {}
}
