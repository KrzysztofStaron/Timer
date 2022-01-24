using Godot;
using System;

public class timer : Node2D
{
	private Timer isDoneTimer;
	bool isDone = false; // true when text green
	bool start = false; // true when timer goes brrr
	float time = 0;
	public float lastTime = 0;

	[Signal]
	public delegate void setText(string txt);

	public override void _Ready() {
		isDoneTimer = GetNode<Timer>("Timer");
	}

	public override void _Process(float delta)
	{
		if (start){
			time += delta;
			lastTime = time;
			TimeSpan t = TimeSpan.FromSeconds(Math.Round(time, 3));
			TimeSpan interval = new TimeSpan(2, 14, 18);

			string Milliseconds = Mathf.Round(t.Milliseconds/10)+"";
			
			if (Milliseconds.Length == 1){
				Milliseconds = "0" + Milliseconds;
			}

			string Seconds = t.Seconds+"";
			
			if (Seconds.Length == 1){
				Seconds = "0" + Seconds;
			}

			string Minutes = t.Minutes+"";

			if (Minutes.Length == 1){
				Minutes = "0" + Minutes;
			}

			
			string text = Minutes+"."+Seconds+"."+Milliseconds;
			this.EmitSignal("setText", text);
		} else {
			time = 0;
		}
	}

	private void _on_down() {
		GD.Print("down");
		setColor(new Color("ffffff"));
		isDoneTimer.Start(0.5f);
		if (start) {
			on_stop();
		}
		start = false;
	}

	private void on_stop(){
		GD.Print("end");
		GetNode<Button>("Button").Disabled = true;
		GetNode<Node2D>("../onStopButtons").Visible = true;
	}

	private void _on_up() {
		setColor(new Color("646464"));
		if (isDone) {
			GD.Print("start");
			start = true;
		}
		isDone = false;
		isDoneTimer.Stop();
	}
	
	private void _on_timeout()
	{
		if (GetNode<Button>("Button").Disabled) {
			return;
		}
		isDone = true;
		setColor(new Color("00ff00"));
		this.EmitSignal("setText", "00.00.00");
	}
	
	public void _canStartTrue()
	{
		GetNode<Button>("Button").Disabled = false;
		GetNode<Node2D>("../onStopButtons").Visible = false;
		this.EmitSignal("setText", "00.00.00");
	}

	private void setColor(Color color)
	{
		GetNode<RichTextLabel>("text").Modulate = color;
	}
}
