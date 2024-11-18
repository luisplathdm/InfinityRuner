﻿using InfinityRunner;

namespace InfinityRuner;

public partial class MainPage : ContentPage
{
	//Atributos//
	//  *
	//  *
	//  *     cobrinha
	//  *     
	//  *
	//  *
	//  <>

	//------------------------------------------------------------------------//

	bool Isdead = false;
	// se está morto

	bool Isjumping = false;
	//se está pulando

	bool IsOnFloor = true;
	// se está no chão

	bool IsOnAir = false;
	// se está no ar

	//------------------------------------------------------------------------//

	const int TimeToFrame = 25;
	//fps
	const int JumpingPower = 8;
	// aqui a gente diz quanro persionagem sobe  em cada clique

	const int MaxtimeJumping = 6;
	//aqui a gente declara o tempo maximo que ele pode ficar em cada clique 

	const int MaxTimeInAir = 4;
	//tempo no ar que se pode deixar

	const int MintimeJumping = 4;
	// e aqui tempo minimo

	const int GravityPower = 6;
	// aqui a força com que ele cai no chão

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

	int CharacterSpeed = 0;
	//velocidade do personagen que atualmente
	//nem está aparecendo 

	int TimeJumping = 0;
	// Aqui a gente vai dizer quando ele estiver pulando

	int TimeInAir = 0;
	// quando ele pulo, o personagen, el fica um leve tempo
	//flutuando e é isso que esse atributo vai fazer para a gente

	//------------------------------------------------------------------------//

	Jogador jogador;
	//estou declarando para que de certo 

	//------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
		jogador = new Jogador(imgJogador);
		jogador.Run();
	}

	//------------------------------------------------------------------------//

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		FixScreenSize(w, h);
		CalculateSpeed(w);
	}

	//------------------------------------------------------------------------//

	void ManageGravity()
	{
		if
		(jogador.GetY() < 0)
			jogador.MoveY(GravityPower);

		else if
		(jogador.GetY() >= 0)

		{
			jogador.SetY(0);
			IsOnFloor = true;
		}
	}
     
    //------------------------------------------------------------------------//
	void AplicaPulo()
	{
		IsOnFloor = false;
		if (Isjumping && TimeJumping >= MaxtimeJumping)
		{
			Isjumping = false;
			IsOnAir = false;
			TimeInAir = 0;
		}
		else if (IsOnAir && TimeInAir >= MaxTimeInAir)
		{
			IsOnAir = false;
			Isjumping = false;
			TimeJumping = 0;
			TimeInAir = 0;
		}
		else if (Isjumping && TimeJumping < MaxtimeJumping)
		{
			jogador.MoveY(-JumpingPower);
			TimeJumping++;
		}
		else if (IsOnAir)
			TimeInAir++;
	}

	//------------------------------------------------------------------------//
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
			// aqui a gente estápuxando os stacklayout do xaml
			// e dizendo que são crianças para

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
		CharacterSpeed = (int)(w * 0.012);
	}

	//------------------------------------------------------------------------//
	async Task Desenhar()
	{
		while (!Isdead)
			if (!Isjumping && !IsOnAir)
			{
				ManageGravity();
				jogador.Drawn();
				ManageScenes();
			}
			else
				AplicaPulo();

		await Task.Delay(TimeToFrame);
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
    void OnGridTapped(object sender, TappedEventArgs e)
	{
		if(IsOnFloor)
		  Isjumping = true;
	}

	//------------------------------------------------------------------------//
}

