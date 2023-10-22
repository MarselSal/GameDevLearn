using Godot;
using System;

public partial class ball : CharacterBody2D
{
	public const float Speed = 500.0f;

	public Vector2 velocity = Vector2.Zero;

    public override void _Ready()
    {
        base._Ready();
		// alterar a seed para Randomize
		GD.Randomize();
		velocity.X = _RandomizeDirection(-1,1);
		velocity.Y = _RandomizeDirection(-0.8f, 0.8f);
    }


    public override void _PhysicsProcess(double delta)
	{

		Velocity = velocity * Speed;
		MoveAndSlide();
	}

	// funcao para randomizar a direcao q a bola vai começar
	private float _RandomizeDirection(float velocityNegative, float velocityPositive){
		float[] valor = {velocityNegative, velocityPositive};
		// vai randomizar uma das duas posicoes do array
		return valor[GD.Randi() % 2];
	}
}
