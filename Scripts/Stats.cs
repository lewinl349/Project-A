using Godot;
using System;

public partial class Stats : Node
{
    [Export]
    public int Hp { get; set; } = 10;
    [Export]
    public int Def { get; set; } = 10;
    [Export]
    public int Atk { get; set; } = 10;

    [Export]
    public Label StatText;

    public int Position { get; set; } = 1;

    public override void _Ready()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        GD.Print(StatText.Text);
        StatText.Text = $"HP: {Hp} Pos: {Position}";
    }
}
