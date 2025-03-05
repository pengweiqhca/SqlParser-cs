namespace SqlParser.Ast;
#if NETFRAMEWORK
public interface IIfNotExists
{
    bool IfNotExists { get; init; }
}

public static class IIfNotExistsExtensions
{
    public const string IfNotExistsPhrase = "IF NOT EXISTS";
    public const string IfExistsPhrase = "IF EXISTS";

    public static string? IfNotExistsText(this IIfNotExists target) => target.IfNotExists ? $"{IfNotExistsPhrase}" : null;
}
#else
public interface IIfNotExists
{
    public const string IfNotExistsPhrase = "IF NOT EXISTS";
    public const string IfExistsPhrase = "IF EXISTS";

    bool IfNotExists { get; init; }

    string? IfNotExistsText => IfNotExists ? $"{IfNotExistsPhrase}" : null;
}
#endif
