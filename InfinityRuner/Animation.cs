using FFImageLoading.Maui;

public class Animation
{
    protected List<String> Animation01 = new List<String>();
    protected List<String> Animation02 = new List<String>();
    protected List<String> Animation03 = new List<String>();
    protected List<String> AnimationDead = new List<String>();
    public bool Loop = true;
    protected int AnimationTadalla = 1;
    bool Brush = true;
    int MainFrame = 1;

    protected CachedImageView ImageView;
    public Animation(CachedImageView imagem)
    {
        ImageView = imagem;
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
            NomeArquivo = Animation01[MainFrame];
            AnimationHeigth = Animation01.Count;
        }
        else if (AnimationTadalla == 2)
        {
            NomeArquivo = Animation02[MainFrame];
            AnimationHeigth = Animation02.Count;
        }
        else if (AnimationTadalla == 3)
        {
            NomeArquivo = Animation03[MainFrame];
            AnimationHeigth = Animation03.Count;
        }
       
        ImageView.Source = ImageSource.FromFile(NomeArquivo);
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