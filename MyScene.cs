using System.Drawing;
using System.Numerics;
using Cubic2D;
using Cubic2D.Entities;
using Cubic2D.Entities.Components;
using Cubic2D.Render;
using Cubic2D.Render.Text;
using Cubic2D.Scenes;
using Cubic2D.Utilities;

namespace Cubic2DSample;

public class MyScene : Scene
{
    private Font _font;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        // In this case, the ClearColor represents the background colour of the game window.
        World.ClearColor = Color.MediumPurple;

        _font = new Font(Game, "Content/arial.ttf");

        Texture2D texture = new Texture2D(Game, "Content/awesomeface.png");

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
        
        if (Input.KeyPressed(Keys.Escape))
            Game.Close();
    }

    // Like update, this draw override isn't needed, however it allows you to add custom draw calls into your game that
    // an entity with a sprite wouldn't normally achieve.
    protected override void Draw()
    {
        base.Draw();
        
        Graphics.SpriteRenderer.Begin();

        _font.Draw(Graphics.SpriteRenderer, 32,
            "Welcome to [c=red]C[c=orange]u[c=yellow]b[c=green]i[c=blue]c[c=darkblue]2[c=purple]D[c=red]!",
            new Vector2(10), Color.White, 0, Vector2.Zero, Vector2.One);
        
        Graphics.SpriteRenderer.End();
    }
}