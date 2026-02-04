using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary;
using PhysicsLibrary.Controllers;
using PhysicsLibrary.Sprites;
using PhysicsLibrary.Commands;
using MonoGameLibrary.Graphics;

namespace PhysicsLibrary;

public class Game1 : Core
{
    private Peg _peg;
    private Ball _ball;
    //private DrawLine _mouseLine;
    private MouseController _mouseController;

// textures
    private Texture2D _ballTexture;
    private TextureRegion _bluePeg;
    private TextureRegion _bluePegHit;

// positions
    private Vector2 _center;
    private Vector2 _anchor;
    //private Vector2 _mousePos;

    private float _screenWidth;
    private float _screenHeight;

    public Game1() : base("physics test", 1280, 720, false) { }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _screenWidth = Window.ClientBounds.Width;
        _screenHeight = Window.ClientBounds.Height;
        _mouseController = new MouseController(this);

        _center = new Vector2(_screenWidth, _screenHeight) * 0.5f;
        _anchor = new Vector2(_screenWidth, 0) * 0.5f;


        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/pegTexture.xml");

        _bluePeg = atlas.GetRegion("bluePeg");
        _bluePegHit = atlas.GetRegion("bluePegHit");

        _ballTexture = Content.Load<Texture2D>("images/pinball");

        _peg = new Peg(_bluePeg, _bluePegHit);
        _peg.Position = _center;

        _ball = new Ball(_ballTexture, this, _peg) ;
        _ball.Position = _center;
        _ball.Velocity = Vector2.Zero;
    }

    protected override void Update(GameTime gameTime)
    {        
        _mouseController.Update(gameTime);
        _ball.Update(gameTime);
        _peg.Update(gameTime);

        //_mouseLine = new DrawLine(SpriteBatch, _anchor, _mousePos, Color.White);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _ball.Draw(SpriteBatch);
        _peg.Draw(SpriteBatch);
        //_mouseLine.Execute();

        SpriteBatch.End();

        base.Draw(gameTime);
    }

    public void FireBall(Vector2 velocity)
    {
        _ball.Position = _anchor;
        _ball.Velocity = velocity;
    }
}
