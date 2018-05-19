namespace csharp.ItemUpdaters
{
    class ItemUpdaterFactory
    {
        public static IItemUpdater GetItemUpdater(string name)
        {
            if (name == "Aged Brie")
            {
                return new AgedBrieItemUpdater();
            }
            else if (name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackstagePassesItemUpdater();
            }
            else if (name == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasItemUpdater();
            }
            else
            {
                return new NormalItemUpdater();
            }
        }
    }
}
