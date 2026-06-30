using ObserverDesignPattern;

//Aandeel aandeel = new(1, "HetAandeel", 50);
//var larry = new Aandeelhouder("Larry");
//var james = new Aandeelhouder("James");
//var overheid = new Overheid();
//aandeel.AddObserver(larry);
//aandeel.AddObserver(james);
//aandeel.AddObserver(overheid);
//Console.WriteLine(aandeel.SetKoers(39));
//Console.WriteLine("-----");
//aandeel.RemoveObserver(james);
//Console.WriteLine(aandeel.SetKoers(40));

// oefening
Brand brand = new("Somersstraat 22");
brand.AddObserver(new Bewoner("Pete"));
brand.AddObserver(new Brandweerman("Blusman2"));
brand.AddObserver(new Bewoner("Cindy"));
brand.AddObserver(new Brandweerman("Blusman1"));
Console.WriteLine(brand.BreektUit());