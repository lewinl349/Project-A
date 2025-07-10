using Godot;
using System;

public partial class Stats : Node2D
{
    [Export] public float Hp { get; set; } = 10;
    [Export] public float Def { get; set; } = 10;
    [Export] public float Atk { get; set; } = 10;

    [Export] public Label StatText { get; set; }

    public override void _Ready()
    {
        UpdateText();
    }

    public float GetStat(StatType type)
    {
        return type switch
        {
            StatType.HP => Hp,
            StatType.DEF => Def,
            StatType.ATK => Atk,
            _ => 0,
        };

    }

    public void UpdateText()
    {
        StatText.Text = $"HP: {Hp}";
    }

    public void TakeDmg(float dmg)
    {
        Hp -= Mathf.Floor(dmg);
        UpdateText();
    }
}
