using Godot;
using System;

public partial class ball : CharacterBody2D
{
	public const float Speed = 100.0f;

	public Vector2 velocity = Vector2.Zero;

    public override void _Ready()
    {
        base._Ready();
		velocity.X = _RandomizeDirection();
		velocity.Y = _RandomizeDirection();
    }


    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = new Vector2(- Speed, -Speed);
		
	

		Velocity = velocity;
		MoveAndSlide();
	}

	// funcao para randomizar a direcao q a bola vai começar
	private int _RandomizeDirection(){
		int[] valor = {-1,1};
		// vai randomizar uma das duas posicoes do array
		return valor[GD.Randi() % 2];
	}
}
