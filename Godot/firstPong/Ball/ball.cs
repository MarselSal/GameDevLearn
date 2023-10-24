using Godot;
using System;

public partial class ball : CharacterBody2D
{
	public const float Speed = 400.0f;

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

		// para numa colisao, mas da ferramentas para dar bounce
		// deve ser multiplicado por delta
		KinematicCollision2D collision_obj = MoveAndCollide(velocity * Speed * (float)delta);
		// retorna um KinematicCollision

		if(collision_obj != null){
			// normal eh a direcao que a superficie esta olhando
			Vector2 normal = collision_obj.GetNormal();
			velocity = velocity.Bounce(normal);
		}

	}

	// funcao para randomizar a direcao q a bola vai começar
	private float _RandomizeDirection(float velocityNegative, float velocityPositive){
		float[] valor = {velocityNegative, velocityPositive};
		// vai randomizar uma das duas posicoes do array
		return valor[GD.Randi() % 2];
	}
}
