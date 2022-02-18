using Cubic2D.Scenes;
using Cubic2D.Windowing;
using Cubic2DTemplate;

GameSettings settings = new GameSettings()
{
    Title = "Cubic2D Template",
    Resizable = true
};

using CubicGame game = new CubicGame(settings);
SceneManager.RegisterScene(typeof(MyScene), "main");
game.Run();