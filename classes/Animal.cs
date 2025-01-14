using Godot;
using System;

public partial class Animal : RigidBody2D
{
	public enum AnimalState {READY, DRAG, RELEASE}
	[Export] private Label _debugLabel;
	[Export] private AudioStreamPlayer2D _stretchSound;
	[Export] private AudioStreamPlayer2D _launchSound;
	[Export] private AudioStreamPlayer2D _kickSound;
	[Export] private Sprite2D _arrow;
	[Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier;

	private AnimalState _state = AnimalState.READY;
	private float _arrowScaleX = 0.0f;
	private Vector2 _start = Vector2.Zero;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ConnectSignals();
		InitializeVariables();
		GD.Print("On Screen Exited!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		UpdateDebugLabel();
	}

	private void InitializeVariables()
	{
		_start = Position;
		_arrowScaleX = _arrow.Scale.X;
		_arrow.Hide();
	}

	private void UpdateDebugLabel()
	{
		_debugLabel.Text = $"St:{_state} Sl:{Sleeping}";
	}

	private void OnScreenExited()
	{
		throw new NotImplementedException();
	}	

	private void ConnectSignals()
	{
		_visibleOnScreenNotifier.ScreenExited += OnScreenExited;
		SleepingStateChanged += OnSleepingStateChanged;
		InputEvent += OnInputEvent;
	}
	
	private void OnSleepingStateChanged()
	{
		//throw new NotImplementedException();
	}
	private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		//throw new NotImplementedException();
		GD.Print(@event);
		if(_state == AnimalState.READY && @event.IsActionPressed("drag"))
		{
			GD.Print("Drag");
		}
	}
}