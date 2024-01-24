using Raylib_CsLo;

public static class Program {
    
    const int WIDTH = 1280;
    const int HEIGHT = 720;
    
    public static void Main(string[] args) {
        
        // init window
        Raylib.InitWindow(WIDTH, HEIGHT, "Jeu de la vie");
        Raylib.SetTargetFPS(60);
        
        // Main loop
        while (!Raylib.WindowShouldClose()) {
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);
            
            Raylib.DrawText("Hello, world!", WIDTH / 2, HEIGHT / 2, 20, Raylib.WHITE);
            
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}
