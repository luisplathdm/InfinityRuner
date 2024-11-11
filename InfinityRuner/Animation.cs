public class Animation
{
    protected List<String> AnimationOne = new List<String>();
    protected List<String> AnimationTwo = new List<String>();
    protected List<String> AnimationThree = new List<String>();
    protected List<String> AnimationDead = new List<String>();
    public bool Loop = true;
    protected int AnimationTadalla = 1;
    bool Brush = true;
    int MainFrame = 1;
    protected Image compImagem;
    public Animation(Image imagem)
    {
        compImagem = imagem;
    }
    public void Stop()
    {
        Brush = true;
    }
    public void Play()
    {
        Brush = false;
    }
    public void SetAnimationTadalla(int A)
    {
        AnimationTadalla = A;
    }
    public void Drawn()
    {
        if (Brush)
            return;
        string NomeArquivo = "";
        int AnimationHeigth = 0;
        if (AnimationTadalla == 1)
        {
            NomeArquivo = AnimationOne[MainFrame];
            AnimationHeigth = AnimationOne.Count;
        }
        else if (AnimationTadalla == 2)
        {
            NomeArquivo = AnimationTwo[MainFrame];
            AnimationHeigth = AnimationTwo.Count;
        }
        else if (AnimationTadalla == 3)
        {
            NomeArquivo = AnimationThree[MainFrame];
            AnimationHeigth = AnimationThree.Count;
        }
        compImagem.Source = ImageSource.FromFile(NomeArquivo);
        MainFrame++;
        if (MainFrame >= AnimationHeigth)
        {
            if (Loop)
                MainFrame = 0;
            else
            {
                Brush = true;
                OnStop();
            }
        }
    }
    public virtual void OnStop()
    {

    }
}