namespace TDDCursusLibrary
{
    public class Woord(string woord)
    {
        public bool IsPalindroom()
        {
            return woord == new string(woord.ToCharArray().Reverse().ToArray());
        }
    }
}
