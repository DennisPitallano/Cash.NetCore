namespace Cash.NetCore.Extensions
{
    internal static class StringExtensions
    {

        public static string AppendValue(this string query, string? value)
        {
            return query.Replace("{value}", value);
        }

        public static string AppendValue(this string query, int? value)
        {
            return AppendValue(query, value.ToString());
        }
        public static string AppendValue(this string query, object value)
        {
            return query.Replace("{value}", value.ToString());
        }

        public static string AddParam(this string query, string? action)
        {
            return action!.StartsWith('/') ? $"{query}{action}" : $"{query}/{action}";
        }
        
        public static string AddParam(this string query, int action)
        {
            return action.ToString().StartsWith('/') ? $"{query}{action}" : $"{query}/{action}";
        }
        
        public static string AddParam(this string query, bool action)
        {
            return action.ToString().StartsWith('/') ? $"{query}{action}" : $"{query}/{action}";
        }

        public static string AddQueryString(this string query, string? name, object? value)
        {
            return query.Contains("?") ? $"{query}&{name}={value}" : $"{query}?{name}={value}";
        }
    }
}
