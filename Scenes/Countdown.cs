using Godot;

public class Countdown : Control
{
    [Export] public int DurationInSeconds = 30;

    [Export] public int WarningTimeInSeconds = 15;

    [Export] public string WarningColor = "FF0000";

    private Timer _timer;

    private Label _text;

    private int _time_remaining;

    [Signal]
    public delegate void TimerFinished();

    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");

        _time_remaining = DurationInSeconds;

        _timer.Connect("timeout", this, nameof(_on_Countdown_timeout));

        _text = GetNode<Label>("Content/Text");

        _text.Text = _format_time(_time_remaining);

        Start();
    }

    public void Start()
    {
        _timer.Start();
    }

    private string _format_time(int timeRemaining)
    {
        var minutes = timeRemaining / 60;
        var seconds = timeRemaining % 60;

        string formattedString = "";
        formattedString += minutes + ":";

        if (seconds < 10)
        {
            formattedString += "0";
        }

        formattedString += seconds;
        return formattedString;
    }

    public void _on_Countdown_timeout()
    {
        _time_remaining -= 1;

        _text.Text = _format_time(_time_remaining);

        if (_time_remaining == 0)
        {
            EmitSignal(nameof(TimerFinished));
            _timer.Stop();
            return;
        }

        if (_time_remaining <= WarningTimeInSeconds)
        {
            _text.AddColorOverride("font_color", new Color(WarningColor));
            GetNode<TextureRect>("Content/Icon").Texture = GD.Load<Texture>("res://Art/UI/raster/timer_warning.png");
        }
    }
}
