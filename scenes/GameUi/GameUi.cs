using Godot;
using System;

public partial class GameUi : Control
{
    [Export] private Label _levelLabel;
    [Export] private Label _attemptsLabel;
    [Export] private VBoxContainer _vb2;
    [Export] private AudioStreamPlayer _gameSound;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{ 
        _levelLabel.Text = $"Level {ScoreManager.GetLevelSelected()}";       

        SignalManager.Instance.OnLevelComplete += OnLevelComplete;
        SignalManager.Instance.OnAttemptUpdated += OnAttemptUpdated;
	}

    public override void _ExitTree()
    {
        SignalManager.Instance.OnLevelComplete -= OnLevelComplete;
        SignalManager.Instance.OnAttemptUpdated -= OnAttemptUpdated;
    }

    private void OnAttemptUpdated(int num)
    {
        _attemptsLabel.Text = $"Attempts: {num}";
    }


    private void OnLevelComplete()
    {
        _vb2.Show();
        _gameSound.Play();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        if(_vb2.Visible && Input.IsKeyPressed(Key.Space))
        {
            GameManager.LoadMain();
        }
	}
}
