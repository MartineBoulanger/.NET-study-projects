namespace CSharpPFCursus
{
    internal static class StringExtensions
    {
        extension(string s)
        {
            public string ToUpperFirst()
            {
                return char.ToUpper(s[0]) + s.Substring(1);
            }

            public string Right(int aantal)
            {
                if (s.Length <= aantal) return s;
                return s.Substring(s.Length - aantal);
            }

            public int WordCount { get => s.Split([' ', '.', ',', '?']).Length; }

            public static string GenerateCode(int lengte)
            {
                string toegelatenTekens = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var code = new char[lengte];
                var random = new Random();
                for (int i = 0; i < lengte; i++)
                {
                    code[i] = toegelatenTekens[random.Next(toegelatenTekens.Length)];
                }
                return new string(code);
            }
        }
    }
}
