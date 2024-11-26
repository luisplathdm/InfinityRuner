namespace InfinityRuner;
public class Inimigo
{
    Image ImageView;
    public Inimigo(Image A)
    {
        ImageView = A;
    }
    public void MoveX(double B)
    {
        ImageView.TranslationX -= B;
    }
    public double GetX ()
    {
        return ImageView.TranslationX;
    }
    public void Reset()
    {
        ImageView.TranslationX = 500;
    }
}
