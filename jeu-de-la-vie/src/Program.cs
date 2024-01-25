using System.Configuration;
using jeu_de_la_vie.logic;
using jeu_de_la_vie.render;
using Raylib_CsLo;

public static class Program {
    
    public static void Main(string[] args) {

        Settings settings = Settings.GetInstance();
        
        // == Configure & init window
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(settings.Width, settings.Height, "Jeu de la vie");
        Raylib.SetTargetFPS(20);
        Raylib.MaximizeWindow();
        
        
        // Init game of life
        var gameOfLife = new GameOfLife(settings.NumberOfSquaresVertical, settings.NumberOfSquaresHorizontal);
        gameOfLife.RandomBoard();
        
        int squareSize = settings.Width / gameOfLife.Matrix.GetLength(0);
        var renderMatrix = new RenderMatrix(squareSize);
        
        // == Main loop ==
        while (!Raylib.WindowShouldClose()) {
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);
            
            // update matrix
            gameOfLife.Update();
            
            // render all squares
            renderMatrix.MakeRenderMatrix(gameOfLife.Matrix);
            
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}
