using Godot;

public class FPSCounter : Panel
{
    [Export] public bool ShowCounter = true;

    private Label _label;

    public override void _Ready()
    {
        _label = GetNode<Label>("Counter");
    }

    public override void _Process(float delta)
    {
        if (ShowCounter)
        {
            _label.GetParent<Panel>().Show();
            _label.Text = "FPS: " + Mathf.Floor(1 / delta);
        }
        else
        {
            _label.GetParent<Panel>().Hide();
        }
    }
}
