namespace Spectre.Console;

/// <summary>
/// A column showing task progress in percentage.
/// </summary>
public sealed class PercentageColumn : ProgressColumn
{
    /// <summary>
    /// Gets or sets the style for a non-complete task.
    /// </summary>
    public Style Style { get; set; } = Style.Plain;

    /// <summary>
    /// Gets or sets the style for a completed task.
    /// </summary>
    public Style CompletedStyle { get; set; } = Color.Green;

    /// <summary>
    /// Gets or sets the style for a failed task.
    /// </summary>
    public Style FailedStyle { get; set; } = new Style(foreground: Color.Red);

    /// <inheritdoc/>
    public override IRenderable Render(RenderOptions options, ProgressTask task, TimeSpan deltaTime)
    {
        var percentage = (int)task.Percentage;
        if (task.IsFailed)
            return new Text($"{percentage}%", FailedStyle).RightJustified();
        var style = percentage == 100 ? CompletedStyle : Style ?? Style.Plain;
        return new Text($"{percentage}%", style).RightJustified();
    }

    /// <inheritdoc/>
    public override int? GetColumnWidth(RenderOptions options)
    {
        return 4;
    }
}