namespace CSharpPFOefeningen
{
    public class X
    {
        const string xBestand = @"C:\Data\x.txt";
        //alle posts in omgekeerde chronologische volgorde
        public List<Post> LeesAllePosts()
        {
            if (File.Exists(xBestand))
            {
                var posts = LeesPosts();
                return posts.OrderByDescending(t => t.Tijdstip).ToList();
            }
            else
            {
                throw new Exception("Het bestand " + xBestand +
                " is niet gevonden!");
            }
        }

        //alle posts van één gebruiker
        public List<Post> LeesPostsVan(string naam)
        {
            return LeesAllePosts().Where(
            t => t.Naam.ToUpper() == naam.ToUpper()).ToList();
        }
        //een post wegschrijven naar het bestand
        public void SchrijfPost(Post post)
        {
            try
            {
                using var schrijver = new StreamWriter(xBestand, true);
                //nieuwe post wordt achteraan toegevoegd (parameter true)
                schrijver.WriteLine($" {post.Naam} *" +
                $" {post.Bericht} *{post.Tijdstip} ");
            }
            catch (IOException)
            {
                throw new Exception("Fout bij het schrijven naar het bestand!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //posts inlezen uit bestand
        private List<Post> LeesPosts()
        {
            List<Post> allePosts = [];
            string? postlijn;
            string[] postgegevens;
            string naam;
            string bericht;
            DateTime tijdstip;
            try
            {
                using var lezer = new StreamReader(xBestand);
                while ((postlijn = lezer.ReadLine()) != null)
                {
                    postgegevens = postlijn.Split('*');
                    naam = postgegevens[0];
                    bericht = postgegevens[1];
                    tijdstip = DateTime.Parse(postgegevens[2]);
                    allePosts.Add(new Post()
                    {
                        Naam = naam,
                        Bericht = bericht,
                        Tijdstip = tijdstip
                    });
                }
                return allePosts;
            }
            catch (IOException)
            {
                throw new Exception("Fout bij het openen/lezen van het bestand!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
