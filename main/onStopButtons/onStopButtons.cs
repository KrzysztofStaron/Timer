using Godot;
using System;

public class onStopButtons : Node2D
{
	private void _save()
	{
		GD.Print(GetNode<timer>("../timer").lastTime);
		GetNode<timer>("../timer")._canStartTrue();
	}

	private void _2sec()
	{
		GD.Print(GetNode<timer>("../timer").lastTime + 2);
		GetNode<timer>("../timer")._canStartTrue();
	}

	private void _dnf()
	{
		GetNode<timer>("../timer")._canStartTrue();
	}
}
