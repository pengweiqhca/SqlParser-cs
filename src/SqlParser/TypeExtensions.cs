namespace SqlParser;

#if NETFRAMEWORK
internal static class TypeExtensions
{
    public static bool IsAssignableTo(this Type childType, Type objectType) => objectType.IsAssignableFrom(childType);
}
#endif
