using SqlParser.Ast;
using SqlParser.Dialects;
using SqlParser.Tokens;
using static SqlParser.Ast.SelectItem;

namespace SqlParser.Tests;

public static class Extensions
{
    public static void RunParserMethod(this IEnumerable<Dialect> dialects, string sql, Action<Parser> action)
    {
        foreach (var dialect in dialects)
        {
            var parser = new Parser();
            parser.TryWithSql(sql, dialect);
            action(parser);
        }
    }

    public static Expression AsExpr(this SelectItem item)
    {
        return item switch
        {
            UnnamedExpression u => u.Expression,
            SelectItem.ExpressionWithAlias e => e.Expression,
            _ => throw new NotImplementedException("AsExpr extension method needs a new Increment match added")
        };
    }

    #if NETFRAMEWORK
    public static IList<Token> Tokenize(this Tokenizer tokenizer, string sql)
        => tokenizer.Tokenize(sql.AsSpan(), new GenericDialect());

    public static IList<Token> Tokenize(this Tokenizer tokenizer, string sql, Dialect dialect)
        => tokenizer.Tokenize(sql.AsSpan(), dialect);

    public static Sequence<Statement> Parse(this SqlQueryParser parser, string sql, ParserOptions? options = null)
        => parser.Parse(sql.AsSpan());

    public static Sequence<Statement> Parse(this SqlQueryParser parser, string sql, Dialect dialect, ParserOptions? options = null)
        => parser.Parse(sql.AsSpan(), dialect, options);

    public static Sequence<Statement> ParseSql(this Parser parser, string sql, ParserOptions? options = null)
        => parser.ParseSql(sql.AsSpan(), options);

    public static Sequence<Statement> ParseSql(this Parser parser, string sql, Dialect dialect, ParserOptions? options = null)
        => parser.ParseSql(sql.AsSpan(), dialect, options);

    public static Parser TryWithSql(this Parser parser, string sql, Dialect dialect, ParserOptions? options = null)
        => parser.TryWithSql(sql.AsSpan(), dialect, options);
#endif
}
