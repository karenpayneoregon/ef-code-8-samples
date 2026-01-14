using System.Text;

namespace NorthWind2020ConsoleApp;

public sealed class ConsoleEncodingScope : IDisposable
{
    private readonly Encoding _output;
    private readonly Encoding _input;

    public ConsoleEncodingScope()
    {
        _output = Console.OutputEncoding;
        _input = Console.InputEncoding;

        Console.OutputEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        Console.InputEncoding = Encoding.UTF8;
    }

    public void Dispose()
    {
        Console.OutputEncoding = _output;
        Console.InputEncoding = _input;
    }
}