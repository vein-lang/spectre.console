namespace Spectre.Console;

/// <summary>
/// Represents console output.
/// </summary>
public class AnsiConsoleOutput : IAnsiConsoleOutput
{
    /// <inheritdoc/>
    public TextWriter Writer { get; }

    /// <inheritdoc/>
    public virtual bool IsTerminal
    {
        get
        {
            if (Writer.IsStandardOut())
            {
                return !System.Console.IsOutputRedirected;
            }

            if (Writer.IsStandardError())
            {
                return !System.Console.IsErrorRedirected;
            }

            return false;
        }
    }

    /// <inheritdoc/>
    public virtual int Width => ConsoleHelper.GetSafeWidth(Constants.DefaultTerminalWidth);

    /// <inheritdoc/>
    public virtual int Height => ConsoleHelper.GetSafeHeight(Constants.DefaultTerminalWidth);

    /// <summary>
    /// Initializes a new instance of the <see cref="AnsiConsoleOutput"/> class.
    /// </summary>
    /// <param name="writer">The output writer.</param>
    public AnsiConsoleOutput(TextWriter writer)
    {
        Writer = writer ?? throw new ArgumentNullException(nameof(writer));
    }

    /// <inheritdoc/>
    public void SetEncoding(Encoding encoding)
    {
        if (Writer.IsStandardOut() || Writer.IsStandardError())
        {
            System.Console.OutputEncoding = encoding;
        }
    }
}