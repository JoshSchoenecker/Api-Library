using System.Collections.Generic;

namespace apiLibrary.DB
{

    public static class FakeDB
    {
        
        public static List<Book> Books = new List<Book>()
        {
            new Book("Where the Sidewalk Ends", "Shel Silverstein"),
            new Book("Eragon", "Christopher Paolini"),
            new Book("Children Of Blood And Bone", "Henry Holt"),
            new Book("The Drowned Cities", "Paolo Bacigalupi")
        };
        public static List<Drink> Drinks = new List<Drink>()
        {
            new Drink("Black Pour-over Coffee", "Hot purified water poured over freshly ground medium roast beans.", 2.50m),
            new Drink("Mocha", "Only the finest dark chocolate & cream used, with the best espresso.", 5.00m),
            new Drink("Smoothie", "A mix of resh fruit, yogurt, and squeezed daily OJ.", 5.75m),
            new Drink("RedBull", "A 12oz. can of cold RedBull", 3.75m)
        };

    }

}