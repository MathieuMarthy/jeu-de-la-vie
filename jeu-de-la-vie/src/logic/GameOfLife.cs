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
    
    private List<int> _neighborsPosition = new List<int> {-1, 0, 1};

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

    public void Update() {
        for (int verticalIndex = 0; verticalIndex < this._verticalLen; verticalIndex++) {
            for (int horizontalIndex = 0; horizontalIndex < this._horizontalLen; horizontalIndex++) {
                this.UpdateSquare(verticalIndex, horizontalIndex);
            }
        }
    }

    private int GetNumberOfAliveNeighbors(int verticalIndex, int horizontalIndex) {
        int neighborsAlive = 0;
        
        foreach (var i in this._neighborsPosition) {
            foreach (var j in this._neighborsPosition) {
                // skip the square itself
                if (i == 0 && j == 0) {
                    continue;
                }
                
                int neighborVerticalIndex = verticalIndex + i;
                int neighborHorizontalIndex = horizontalIndex + j;
                
                // skip if the neighbor is out of bounds
                if (neighborVerticalIndex < 0 || neighborVerticalIndex >= this._verticalLen) {
                    continue;
                }
                if (neighborHorizontalIndex < 0 || neighborHorizontalIndex >= this._horizontalLen) {
                    continue;
                }

                // if the square is alive, increment the counter
                if (this.Matrix[neighborVerticalIndex, neighborHorizontalIndex].IsAlive()) {
                    neighborsAlive++;
                }
            }
        }

        return neighborsAlive;
    }
    
    private void UpdateSquare(int verticalIndex, int horizontalIndex) {
        int neighborsAlive = this.GetNumberOfAliveNeighbors(verticalIndex, horizontalIndex);

        if (this.Matrix[verticalIndex, horizontalIndex].IsAlive()) {
            if (neighborsAlive is < 2 or > 3) {
                this.Matrix[verticalIndex, horizontalIndex].Die();
            }
        } else {
            if (neighborsAlive == 3) {
                this.Matrix[verticalIndex, horizontalIndex].Born();
            }
        }
    }
}
