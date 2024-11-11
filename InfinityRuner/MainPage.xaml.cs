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

	//------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
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
		Drawn();
	}

	//------------------------------------------------------------------------//

	void FixScreenSize(double w, double h)
	{
		foreach (var A in HSLayerOne.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in HSLayerTwo.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in HSLayerThree.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in HSLayerPrimalfloor.Children)
			(A as Image).WidthRequest = w;

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
	}

	//------------------------------------------------------------------------//
	async Task Drawn()
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

