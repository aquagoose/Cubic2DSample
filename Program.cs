using Cubic2D.Scenes;
using Cubic2D.Windowing;
using Cubic2DSample;

GameSettings settings = new GameSettings()
{
    Title = "Cubic2D Sample",
    Resizable = true
};

using CubicGame game = new CubicGame(settings);
SceneManager.RegisterScene(typeof(MyScene), "main");
game.Run();