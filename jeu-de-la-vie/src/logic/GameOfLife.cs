using jeu_de_la_vie.models;

namespace jeu_de_la_vie.logic;

public class GameOfLife {
    public Square[,] Matrix {
        get;
        private set;
    }
    private readonly int _verticalLen;
    private readonly int _horizontalLen;
    private readonly Random _random = new ();

    public GameOfLife(int verticalLen, int horizontalLen) {
        this._verticalLen = verticalLen;
        this._horizontalLen = horizontalLen;
        this.Matrix = new Square[verticalLen, horizontalLen];
    }

    private Square GetRandomSquare() {
        int randomValue = this._random.Next(0, 2);
        return new Square(randomValue);
    }

    public void RandomBoard() {
        for (int verticalIndex = 0; verticalIndex < this._verticalLen; verticalIndex++) {
            for (int horizontalIndex = 0; horizontalIndex < this._horizontalLen; horizontalIndex++) {
                this.Matrix[verticalIndex, horizontalIndex] = this.GetRandomSquare();
            }
        }
    }
}
