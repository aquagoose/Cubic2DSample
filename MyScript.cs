using System.Numerics;
using Cubic2D;
using Cubic2D.Entities.Components;

namespace Cubic2DSample;

public class MyScript : Component
{
    // The initialize method is called once, when the script is initialised.
    protected override void Initialize()
    {
        base.Initialize();

        Transform.Scale = new Vector2(0.5f);
    }

    // Update is called once per frame.
    protected override void Update()
    {
        base.Update();

        // Use DeltaTime to perform framerate-independent tasks. In this case, we use it for rotation and movement.
        // This means that the object will always move & rotate at the same speed, regardless of the framerate.
        Transform.Rotation += 1f * Time.DeltaTime;

        // You can use Input.KeyDown() too, but here we use Input.KeysDown() as it supports checking multiple different
        // keys without using multiple if statements.
        if (Input.KeysDown(Keys.W, Keys.Up))
            Transform.Position.Y -= 100 * Time.DeltaTime;
        if (Input.KeysDown(Keys.S, Keys.Down))
            Transform.Position.Y += 100 * Time.DeltaTime;
        if (Input.KeysDown(Keys.D, Keys.Right))
            Transform.Position.X += 100 * Time.DeltaTime;
        if (Input.KeysDown(Keys.A, Keys.Left))
            Transform.Position.X -= 100 * Time.DeltaTime;

        if (Input.MouseButtonDown(MouseButtons.Left))
            Transform.Position = Input.MousePosition;
    }
}