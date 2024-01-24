using jeu_de_la_vie.logic;
using jeu_de_la_vie.render;
using Raylib_CsLo;

public static class Program {
    
    const int WIDTH = 1280;
    const int HEIGHT = 720;
    
    public static void Main(string[] args) {
        
        // init window
        Raylib.InitWindow(WIDTH, HEIGHT, "Jeu de la vie");
        Raylib.SetTargetFPS(60);
        
        // init game of life
        var gameOfLife = new GameOfLife(30);
        gameOfLife.RandomBoard();
        
        // Main loop
        while (!Raylib.WindowShouldClose()) {
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);
            
            Raylib.DrawText("Hello, world!", WIDTH / 2, HEIGHT / 2, 20, Raylib.WHITE);
            
            // render all squares
            RenderMatrix.MakeRenderMatrix(gameOfLife.Matrix);
            
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}
