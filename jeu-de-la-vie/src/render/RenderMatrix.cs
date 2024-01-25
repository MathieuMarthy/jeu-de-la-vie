using jeu_de_la_vie.models;
using Raylib_CsLo;

namespace jeu_de_la_vie.render;

public class RenderMatrix {
    private int _squareSize;
    
    public RenderMatrix(int squareSize) {
        this._squareSize = squareSize;
    }
    
    public void MakeRenderMatrix(Square[,] squares) {
        for (int i = 0; i < squares.GetLength(0); i++) {
            for (int j = 0; j < squares.GetLength(0); j++) {
                Square square = squares[i, j];
                
                if (square.IsAlive()) {
                    Raylib.DrawRectangle(
                        i * this._squareSize,
                        j * this._squareSize,
                        this._squareSize,
                        this._squareSize,
                        square.GetColor()
                    );
                }
            }
        }
    }
}
