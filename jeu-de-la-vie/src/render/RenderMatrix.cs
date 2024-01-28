using jeu_de_la_vie.models;
using Raylib_CsLo;

namespace jeu_de_la_vie.render;

public class RenderMatrix {
    private readonly int _squareSize;
    
    public RenderMatrix(int squareSize) {
        this._squareSize = squareSize;
    }
    
    public void MakeRenderMatrix(Square[,] squares) {
        for (int i = 0; i < squares.GetLength(0); i++) {
            for (int j = 0; j < squares.GetLength(1); j++) {
                Square square = squares[i, j];
                
                if (square.IsAlive()) {
                    Raylib.DrawRectangle(
                        j * this._squareSize,
                        i * this._squareSize,
                        this._squareSize,
                        this._squareSize,
                        square.GetColor()
                    );
                }
            }
        }
    }
}
