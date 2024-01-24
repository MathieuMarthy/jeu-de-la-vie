using System.Numerics;
using Raylib_CsLo;

namespace jeu_de_la_vie.models;

public class Square {
    private int _state;
    
    public Square(int state) {
        this._state = state;
    }
    
    public bool IsAlive() {
        return this._state == 1;
    }
    
    public Color GetColor() {
        return this._state == 1 ? Raylib.WHITE : Raylib.BLACK;
    }
}
