namespace jeu_de_la_vie.logic;

public class Settings {
    private static Settings? _instance;

    public int Width { get; private set; }  = 1920;
    public int Height { get; private set; } = 1080;
    public int NumberOfSquaresHorizontal { get; private set; } = 200;
    public int NumberOfSquaresVertical { get; private set; } = 200;

    private Settings() { }
    
    public static Settings GetInstance() {
        return _instance ??= new Settings();
    }
}
