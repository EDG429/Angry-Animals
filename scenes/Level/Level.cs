using Godot;
using System;

public partial class Level : Node2D
{
    [Export] private Marker2D _animalStart;
    [Export] private PackedScene _animalScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SignalManager.Instance.OnAnimalDied += OnAnimalDied;
        OnAnimalDied();
    }

    private void OnAnimalDied()
    {
        Animal newAnimal = _animalScene.Instantiate<Animal>();
        newAnimal.Position = _animalStart.Position;
        AddChild(newAnimal);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void _Process(double delta)
    {
        if(Input.IsKeyPressed(Key.Q))
        {
            GameManager.LoadMain();
        }
    }

    public override void _ExitTree()
    {
        SignalManager.Instance.OnAnimalDied -= OnAnimalDied;
    }

}
