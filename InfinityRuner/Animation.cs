using FFImageLoading.Maui;
using InfinityRuner;

public class Animation
{
    // classe utlizada para gerenciar todos os aspectos da animação//

    //------------------------------------------------------------------------//

    protected List<String> Animation01 = new List<String>();

    protected List<String> Animation02 = new List<String>();

    protected List<String> Animation03 = new List<String>();

    protected List<String> AnimationDead = new List<String>();
    // aqui são as listas das minhas imagens que criam uma impressão
    // quadro por quadro qeu gera uma animação

    protected CachedImageView ImageView;


    //------------------------------------------------------------------------//
    public bool Loop = true;
    // looping que diz quando jogo acaba

    bool Brush = true;
    // faz a animação para ou brochar

    //------------------------------------------------------------------------//

    protected int AnimationTadalla = 1;
    // não para nunca faz a animação continuar

    //------------------------------------------------------------------------//

    int MainFrame = 1;
    // é o frame atual que é utilizado pra
    //fps


    //------------------------------------------------------------------------//


    public Animation(CachedImageView image)
    {
        ImageView = image;
    }

    //------------------------------------------------------------------------//
    public void Stop()
    {
        Brush = true;
        // aqui o cabra não se aguentou e brochou 
        // ai acabou tudo 
    }

    public void Play()
    {
        Brush = false;
        // aqui tá dizendo que ela não Bruxou ou não parou
    }

    public void SetAnimationTadalla(int A)
    {
        AnimationTadalla = A;
        // aqui é oque a matem a animação ativa 
    }

    //------------------------------------------------------------------------//
    public void Drawn()
    {
        if (Brush)
            return;
        string NomeDoArquivo = "";
        int AnimationHeigth = 0;

        if (AnimationTadalla == 1)
        {
            NomeDoArquivo = Animation01[MainFrame];
            AnimationHeigth = Animation01.Count;
            // aqui a gente conta a imagem um e atribui um valor 
            // e pela frente é o mesmo assim que atribui um valor
            // ele troca de imagem 
        }
        else if (AnimationTadalla == 2)
        {
            NomeDoArquivo = Animation02[MainFrame];
            AnimationHeigth = Animation02.Count;
            // a segunda imagem que quando a primeira troca o valor dela 
            // no frame atual essa aparece e tambem troca o valor dela 
            // chamando a proxima
        }
        else if (AnimationTadalla == 3)
        {
            NomeDoArquivo = Animation03[MainFrame];
            AnimationHeigth = Animation03.Count;
            // essa seria a ultima imagem que aparece gerando 
            //uma animação com tres imagens
        }

        ImageView.Source = ImageSource.FromFile(NomeDoArquivo);
        MainFrame++;

        if (MainFrame >= AnimationHeigth)
        {
            if (Loop)
            {
                MainFrame = 0;
            // aqui a gente utiliza o looping para dizer que 
            //quando todas as imagens forem utilizadas ele zera 
            // fazendo um looping infinito do personagem correndo
            }
            else
            {
                Brush = true;
                // senão estiver dentro do looping é quando
                // o personagem morre e então o jogo é pausado
                QuandoParar();
            }
        }
    }


    public virtual void QuandoParar()
    {

    }
    //------------------------------------------------------------------------//
}