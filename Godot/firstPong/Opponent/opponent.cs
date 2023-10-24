using Godot;
using System;

public partial class opponent : CharacterBody2D
{
	public const float Speed = 300.0f;

	[Export]
	public CharacterBody2D ball;

    public override void _Ready()
    {
        base._Ready();
		if(ball == null){
			ball = GetNode<CharacterBody2D>("../Ball");
		}
		
    }

    public override void _PhysicsProcess(double delta)
	{
	
		Vector2 velocity = Velocity;

		velocity.Y = Speed * opponent_direction();

		Velocity = velocity;
		MoveAndSlide();
	}

	// mudar a direcao do oponente baseado na posicao da bola
	public int opponent_direction(){
		Vector2 ballPos = ball.Position;

		//caso a dif absolutado entre a bola e o openente seja maior que 25
		if(Mathf.Abs(ballPos.Y - Position.Y) > 25){
			if(ballPos.Y < Position.Y){
				return - 1;
			}else return 1;
		}else{
			return 0;
		}
	}
}
