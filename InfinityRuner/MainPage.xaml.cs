using InfinityRunner;

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

	int SpeedThree = 0;
	// velocidade da terceira camada

	int PrimalFloorSpeed = 0;
	//velocidade do chão ou do boneco tbm

	int WindowHeigth = 0;
	//altura da janela 

	int WindowWidth = 0;
	//largura da janela

	Jogador jogador;

	//------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
		jogador= new Jogador(imgJogador);
		jogador.Run();
	}

	//------------------------------------------------------------------------//

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		FixScreenSize(w, h);
		CalculateSpeed(w);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenhar();
		jogador.Drawn();
		//Aqui é oque faz o cenarrio e talvz
		//o personagem apaeceranddno
	}

	//------------------------------------------------------------------------//

	void FixScreenSize(double w, double h)
	{
		foreach (var LayerOne in HSLayerOne.Children)
			(LayerOne as Image).WidthRequest = w;
		
		foreach (var Layertwo in HSLayerTwo.Children)
			(Layertwo as Image).WidthRequest = w;
		
		foreach (var ALayerthre in HSLayerThree.Children)
			(ALayerthre as Image).WidthRequest = w;
		
		foreach (var LayerDoChão in HSLayerPrimalfloor.Children)
			(LayerDoChão as Image).WidthRequest = w;

		HSLayerOne.WidthRequest = w * 1.5;
		HSLayerTwo.WidthRequest = w * 1.5;
		HSLayerThree.WidthRequest = w * 1.5;
		HSLayerPrimalfloor.WidthRequest = w * 1.5;
	}

	//------------------------------------------------------------------------//
	void CalculateSpeed(double w)
	{
		SpeedOne = (int)(w * 0.001);
		SpeedTwo = (int)(w * 0.004);
		SpeedThree = (int)(w * 0.008);
		PrimalFloorSpeed = (int)(w * 0.01);
		CharacterSpeed = (int) (width * 0.012);
	}

	//------------------------------------------------------------------------//
	async Task Desenhar()
	{
		while (!Isdead)
		{
			ManageScenes();
			await Task.Delay(TimeToFrame);
		}
	}

	//------------------------------------------------------------------------//
	void MoveScene()
	{
		HSLayerOne.TranslationX -= SpeedOne;
		HSLayerTwo.TranslationX -= SpeedTwo;
		HSLayerThree.TranslationX -= SpeedThree;
		HSLayerPrimalfloor.TranslationX -= PrimalFloorSpeed;
		HSLayerPrimalfloor.TranslationX -= CharacterSpeed;
	}

	//------------------------------------------------------------------------//
	void ManageScenes()
	{
		MoveScene();
		ManageScene(HSLayerOne);
		ManageScene(HSLayerTwo);
		ManageScene(HSLayerThree);
		ManageScene(HSLayerPrimalfloor);
	}


	//------------------------------------------------------------------------//

	void ManageScene(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}


	//------------------------------------------------------------------------//
}

