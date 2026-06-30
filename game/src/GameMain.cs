using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanterDefense;

public class GameMain : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Texture2D TextureRect;
    public int Width {get; set;} public int Height{get; set;}
    public float AspectRatio {get; set;} = 16.0f / 9.0f;

    public GameMain()
    {
        _graphics = new GraphicsDeviceManager(this);
        int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        if (width >= height * AspectRatio)
        {
            Height = (int)(height * 0.8f);
            Width = (int)(Height * AspectRatio);
        }
        else
        {
            Width = (int)(width * 0.8f);
            Height = (int)(Width / AspectRatio);
        }
        _graphics.PreferredBackBufferWidth = Width;
        _graphics.PreferredBackBufferHeight = Height;
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Window.Title = "Planter Defense";
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        TextureRect = new Texture2D(GraphicsDevice, 1, 1);
        TextureRect.SetData(new[] {Color.White});
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        float scaleX = (float)Width / 1280f;
        float scaleY = (float)Height / 720f;
        
        // 2. 크기 조정 행렬 생성
        Matrix scaleMatrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);

        // 3. SpriteBatch를 시작할 때 행렬 적용
        _spriteBatch.Begin(transformMatrix: scaleMatrix);
         Rectangle myRectangle = new Rectangle(320, 180, 640, 360);
        _spriteBatch.Draw(TextureRect, myRectangle, Color.Red);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
