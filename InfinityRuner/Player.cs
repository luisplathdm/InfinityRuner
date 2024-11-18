using FFImageLoading.Maui;

namespace InfinityRunner
{
   public class Jogador : Animation
    {
//------------------------------------------------------------//

        public Jogador(CachedImageView a) : base(a)
        {
            for (int numero = 1; numero <= 5; numero++)
                Animation01.Add($"animation01{numero.ToString("D2")}.png");

            for (int numero2 = 1; numero2 <= 2; numero2++)
                AnimationDead.Add($"morto{numero2.ToString("D2")}.png");
        }

//------------------------------------------------------------//

        public void Morto()
        {
            Loop = false;
            SetAnimationTadalla(2);
        }

//------------------------------------------------------------//

        public void Run()
        //aqui é qie o jogo começou 
        // pq sim
        {
            Loop = true;
            SetAnimationTadalla(1);
            Play();
        }

        public void MoveY(int S)
        // esse muda o valor 
        {
            ImageView.TranslationY+=S;
        }

        public double GetY( ) 
        // esse metodo pega o valor 
        {
            return ImageView.TranslationY;
        }

        public void SetY(double A)
        // esse retorna a imagem com o valor trocado 
        {
            ImageView.TranslationY =A;
        } 
        // todos esses metodos estão chamamdo a imagem e puxando o
        // valor dela e depois mandando de volta com a mudança constate

//------------------------------------------------------------//
    }
}