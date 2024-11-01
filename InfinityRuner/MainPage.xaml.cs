namespace InfinityRuner;

public partial class MainPage : ContentPage
{
	//Atributos//
	//------------------------------------------------------------------------//

	bool Isdead = false;
	// se está morto
	bool Isjumping = false;
	//se está pulando

	//------------------------------------------------------------------------//

	const int TimeToFrame = 25;
	//fps

	//------------------------------------------------------------------------//

	int SpeedOne = 0;
	//velocidade da primeira camada no caso 
	// a camada que fica por ultimo

	int SpeedTwo = 0;
	//velocidade da segunda camada

	int SpeedTree = 0;
	// velocidade da terceira camada

	int PrimalFloorSpeed = 0;
	//velocidade do chão ou do boneco tbm

	int WindowHeigth = 0;
	//altura da janela 

	int WindowWidth = 0;
	//largura da janela

	//------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
	}
//------------------------------------------------------------------------//
	Initializer()
	{

	}
//------------------------------------------------------------------------//
    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		FixScreenSize(w, h);
		calculateSpeed(w);
    }
	//------------------------------------------------------------------------//

	void FixScreenSize (double w, double h)
	{
		foreach (var A in HSLayerOne.Children)
		(A as Image).WidthRequest = w;
		foreach (var A in HSLayerTwo.Children)
		(A as Image).WidthRequest = w;
		foreach (var A in HSLayerTree.Children)
		(A as Image).WidthRequest = w;
		foreach (var A in HSLayerPrimalfloor.Children)
		(A as Image).WidthRequest = w;
        
		 HSLayerOne.WidthRequest = w * 1.5;
		 HSLayerTwo.WidthRequest = w * 1.5;
		 HSLayerTree.WidthRequest = w * 1.5;
		 HSLayerPrimalfloor.WidthRequest = w * 1.5;
	}
}

