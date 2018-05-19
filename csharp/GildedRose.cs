using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                IItemUpdater itemUpdater;

                if (Items[i].Name == "Aged Brie")
                {
                    itemUpdater = new AgedBrieItemUpdater();
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    itemUpdater = new BackstagePassesItemUpdater();
                }
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    itemUpdater = new SulfurasItemUpdater();
                }
                else
                {
                    itemUpdater = new NormalItemUpdater();
                }

                itemUpdater.Update(Items[i]);
            }
        }
    }
}
