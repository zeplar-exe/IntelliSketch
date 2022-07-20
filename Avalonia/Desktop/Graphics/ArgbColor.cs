namespace Desktop.Graphics;

public record ArgbColor(byte A = 0, byte R = 0, byte G = 0, byte B = 0)
{
    public static ArgbColor Transparent => new();
    public static ArgbColor White => new(255, 255, 255, 255);
    public static ArgbColor Black => new(255);
    
    public static ArgbColor Red => new(255, 255);
    public static ArgbColor Green => new(255, 0, 255);
    public static ArgbColor Blue => new(255, 0, 0, 255);
}