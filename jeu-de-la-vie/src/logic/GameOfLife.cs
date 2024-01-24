using jeu_de_la_vie.models;

namespace jeu_de_la_vie.logic;

public class GameOfLife {
    public Square[,] Matrix {
        get;
        private set;
    }
    private readonly int _len;
    private readonly Random _random = new ();

    public GameOfLife(int len) {
        this._len = len;
        this.Matrix = new Square[len, len];
    }

    private Square GetRandomSquare() {
        int randomValue = this._random.Next(0, 2);
        return new Square(randomValue);
    }

    public void RandomBoard() {
        for (int i = 0; i < this._len; i++) {
            for (int j = 0; j < this._len; j++) {
                this.Matrix[i, j] = this.GetRandomSquare();
            }
        }
    }
}
