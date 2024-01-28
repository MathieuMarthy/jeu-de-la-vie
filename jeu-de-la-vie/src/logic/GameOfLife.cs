using jeu_de_la_vie.models;
using Raylib_CsLo;

namespace jeu_de_la_vie.logic;

public class GameOfLife {
    public Square[,] Matrix {
        get;
        private set;
    }
    private readonly int _verticalLen;
    private readonly int _horizontalLen;
    private readonly Random _random = new();
    
    private readonly List<int> _neighborsPosition = new List<int> {-1, 0, 1};

    public GameOfLife(int verticalLen, int horizontalLen) {
        this._verticalLen = verticalLen;
        this._horizontalLen = horizontalLen;
        this.Matrix = new Square[verticalLen, horizontalLen];
        
        // init matrix
        for (int i = 0; i < verticalLen; i++) {
            for (int j = 0; j < horizontalLen; j++) {
                this.Matrix[i, j] = new Square(0);
            }
        }
    }

    private Square GetRandomSquare() {
        int randomValue = this._random.Next(0, 2);
        return new Square(randomValue);
    }
    
    public void InitRandom() {
        for (int verticalIndex = 0; verticalIndex < this._verticalLen; verticalIndex++) {
            for (int horizontalIndex = 0; horizontalIndex < this._horizontalLen; horizontalIndex++) {
                this.Matrix[verticalIndex, horizontalIndex] = this.GetRandomSquare();
            }
        }
    }

    public void InitFrog() {
        this.Matrix[10, 11].Born();
        this.Matrix[10, 12].Born();
        this.Matrix[10, 13].Born();
        this.Matrix[11, 10].Born();
        this.Matrix[11, 11].Born();
        this.Matrix[11, 12].Born();
    }

    public void Update() {
        
        Square [,] newMatrix = new Square[this._verticalLen, this._horizontalLen];
        for (int verticalIndex = 0; verticalIndex < this._verticalLen; verticalIndex++) {
            for (int horizontalIndex = 0; horizontalIndex < this._horizontalLen; horizontalIndex++) {
                newMatrix[verticalIndex, horizontalIndex] = this.UpdateSquare(verticalIndex, horizontalIndex);
            }
        }
        
        this.Matrix = newMatrix;
    }

    private int GetNumberOfAliveNeighbors(int verticalIndex, int horizontalIndex) {
        int neighborsAlive = 0;
        
        foreach (var i in this._neighborsPosition) {
            foreach (var j in this._neighborsPosition) {
                // skip the square itself
                if (i == 0 && j == 0) continue;

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
    
    private Square UpdateSquare(int verticalIndex, int horizontalIndex) {
        int neighborsAlive = this.GetNumberOfAliveNeighbors(verticalIndex, horizontalIndex);

        if (this.Matrix[verticalIndex, horizontalIndex].IsAlive()) {
            if (neighborsAlive is < 2 or > 3) {
                return new Square(0);
            }
        } else if (neighborsAlive == 3) {
            return new Square(1);
        }

        return new Square(this.Matrix[verticalIndex, horizontalIndex].IsAlive() ? 1 : 0);
    }
}
