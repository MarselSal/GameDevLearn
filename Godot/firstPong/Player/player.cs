using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
	
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Vector2.Zero;

		if(Input.IsActionPressed("ui_up")){
			direction.Y -= 1; 
		}else if(Input.IsActionPressed("ui_down")){
			direction.Y += 1;
		}
		
		velocity.Y = Speed * direction.Y;

		Velocity = velocity;
		MoveAndSlide();
	}
}
