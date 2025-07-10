using Godot;
using System;

public partial class Stats : Node2D
{
    [Export] public float Hp { get; set; } = 10;
    [Export] public float Def { get; set; } = 10;
    [Export] public float Atk { get; set; } = 10;

    Label statText;
    Sprite2D sprite;
    AnimationController aniPlayer;

    public override void _Ready()
    {
        statText = GetNode<Label>("StatText");
        sprite = GetParent<Node2D>().GetNode<Sprite2D>("Sprite");
        aniPlayer = GetParent<Node2D>().GetNode<AnimationController>("%AnimationPlayer");
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
        statText.Text = $"HP: {Hp}";
    }

    public void TakeDmg(float dmg)
    {
        aniPlayer.PlayHurt();
        Hp -= Mathf.Floor(dmg);
        UpdateText();
    }
}
