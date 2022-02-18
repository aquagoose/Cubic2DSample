using System.Numerics;
using Cubic2D;
using Cubic2D.Entities.Components;

namespace Cubic2DTemplate;

public class MyScript : Component
{
    protected override void Initialize()
    {
        base.Initialize();

        Transform.Scale = new Vector2(2f);
    }

    protected override void Update()
    {
        base.Update();

        Transform.Rotation += 1f * Time.DeltaTime;

        if (Input.KeysDown(Keys.W, Keys.Up))
            Transform.Position.Y += 10 * Time.DeltaTime;
        if (Input.KeysDown(Keys.S, Keys.Down))
            Transform.Position.Y -= 10 * Time.DeltaTime;
        if (Input.KeysDown(Keys.D, Keys.Left))
            Transform.Position.X += 10 * Time.DeltaTime;
        if (Input.KeysDown(Keys.A, Keys.Right))
            Transform.Position.X -= 10 * Time.DeltaTime;
    }
}