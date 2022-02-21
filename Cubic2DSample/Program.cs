using Cubic2D.Scenes;
using Cubic2D.Windowing;
using Cubic2DSample;

// Every Cubic2D game must have some settings attached to it.
// Here you can set various properties, such as window title, resolution (size), number of audio channels, etc.
GameSettings settings = new GameSettings()
{
    Title = "Cubic2D Sample",
    Resizable = true
};

// Every Cubic2D game must have at least once scene registered. We do that here.
using CubicGame game = new CubicGame(settings);
SceneManager.RegisterScene(typeof(MyScene), "main");
game.Run();