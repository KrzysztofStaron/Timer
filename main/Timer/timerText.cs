using Godot;
using System;

public class timerText : RichTextLabel
{
	[Export] public string textToShow = "00.00.00";
	[Export] public int maxChars = 35;

	void setText(string txt) {
		textToShow = txt;
	}

	public override void _Process(float delta)
	{
		string spaces = "";
		for (int i = 0; i < (maxChars - textToShow.Length) / 2; i++)
		{
			spaces += " ";
		}
		Text = spaces + "" + textToShow; 
	}
}
