using System.Drawing;
using System.Numerics;
using Cubic2D;
using Cubic2D.Entities;
using Cubic2D.Entities.Components;
using Cubic2D.GUI;
using Cubic2D.Render;
using Cubic2D.Render.Text;
using Cubic2D.Scenes;
using Cubic2D.Utilities;

namespace Cubic2DSample;

public class MyScene : Scene
{
    private Font _font;
    private int _clicks;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        // In this case, the ClearColor represents the background colour of the game window.
        World.ClearColor = Color.MediumPurple;

        // The UI theme doesn't have a font set by default - before you can use it you need to set its font.
        _font = new Font("Content/arial.ttf");
        UI.Theme.Font = _font;

        Texture2D texture = new Texture2D("Content/awesomeface.png");

        // Entities in Cubic2D use components to add certain properties to the entity. You can add Sprites, and custom
        // scripts to the entity.
        Entity entity = new Entity(new Transform()
        {
            Position = Game.Window.Size.ToVector2() / 2f,
            Origin = texture.Size.ToVector2() / 2f
        });
        entity.AddComponent(typeof(Sprite), texture);
        entity.AddComponent(typeof(MyScript));
        AddEntity("MyEntity", entity);
    }

    // The update override isn't needed, it's just to add scene-wide logic to your game.
    protected override void Update()
    {
        base.Update();

        // Here we are using Cubic2D's ImGUI (immediate mode GUI) system to draw a button and a couple labels to the
        // screen. This button is in an if statement, which is triggered whenever the button is clicked.
        if (UI.Button(Anchor.BottomRight, new Rectangle(-10, -10, 200, 100), "Click me!"))
            _clicks++;

        UI.Label(Anchor.TopRight, new Point(-10, 10), $"Clicks: {_clicks}", 24);

        // We can gather various metrics from Cubic2D, including the framerate, the total number of sprites drawn in
        // this frame, and the number of draw calls it is making to the GPU.
        // It deals with this stuff automatically so you don't need to worry about it much, but there are ways to improve
        // performance.
        UI.Label(Anchor.BottomLeft, Point.Empty,
            $"METRICS:\nFPS: {Time.Fps}\nFrames: {Time.TotalFrames}\nDelta time: {Time.DeltaTime}\nSprites drawn: {Metrics.SpritesDrawn}\nDraw calls: {Metrics.DrawCalls}",
            12);
        
        // Close the game if the escape key is pressed!
        if (Input.KeyPressed(Keys.Escape))
            Game.Close();
    }

    // Like update, this draw override isn't needed, however it allows you to add custom draw calls into your game that
    // an entity with a sprite wouldn't normally achieve.
    protected override void Draw()
    {
        base.Draw();

        // We can also do bog standard text drawing. It even supports changing the colour midway through!
        // The font object generates a font atlas on the fly when it's needed, but caches it after the fact to save
        // processing time. You can clear the cache if you want, just perform _font.ClearAtlasCache()
        // Don't do this often though as it will have to regenerate any new font atlases.
        _font.Draw(Graphics.SpriteRenderer, 32,
            "Welcome to [c=red]C[c=orange]u[c=yellow]b[c=green]i[c=blue]c[c=darkblue]2[c=purple]D[c=red]!",
            new Vector2(10), Color.White, 0, Vector2.Zero, Vector2.One);
    }
}