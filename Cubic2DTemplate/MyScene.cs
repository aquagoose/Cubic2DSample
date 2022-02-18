using System.Drawing;
using System.Numerics;
using Cubic2D.Entities;
using Cubic2D.Entities.Components;
using Cubic2D.Render;
using Cubic2D.Render.Text;
using Cubic2D.Scenes;
using Cubic2D.Utilities;

namespace Cubic2DTemplate;

public class MyScene : Scene
{
    private Font _font;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        World.ClearColor = Color.CornflowerBlue;

        _font = new Font(Game, "Content/arial.ttf");

        Texture2D texture = new Texture2D(Game, "Content/awesomeface.png");

        Entity entity = new Entity(new Transform()
        {
            Position = new Vector2(100),
            Origin = texture.Size.ToVector2() / 2f
        });
        entity.AddComponent(typeof(Sprite), texture);
    }

    protected override void Draw()
    {
        base.Draw();

        _font.Draw(Graphics.SpriteRenderer, 24,
            "Welcome to [c=red]C[c=orange]u[c=yellow]b[c=green]i[c=blue]c[c=darkblue]2[c=purple]D!", new Vector2(10),
            Color.White, 0, Vector2.Zero, Vector2.One);
    }
}