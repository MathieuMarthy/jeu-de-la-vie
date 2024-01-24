using jeu_de_la_vie.models;
using Raylib_CsLo;

namespace jeu_de_la_vie.render;

public class RenderMatrix {
    
    public static void MakeRenderMatrix(Square[,] squares) {
        for (int i = 0; i < squares.GetLength(0); i++) {
            for (int j = 0; j < squares.GetLength(0); j++) {
                Square square = squares[i, j];
                
                if (square.IsAlive()) {
                    Raylib.DrawRectangle(i * 10, j * 10, 10, 10, square.GetColor());
                }
            }
        }
    }
}
