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
                if (Items[i].Name == "Aged Brie")
                {
                    UpdateAgedBrieItem(Items[i]);
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePassesItem(Items[i]);
                }
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    UpdateSulfurasItem(Items[i]);
                }
                else
                {
                    UpdateNormalItem(Items[i]);
                }               
            }
        }

        private void UpdateNormalItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality--;
            }
        }

        private void UpdateAgedBrieItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality++;
            }
        }

        private void UpdateSulfurasItem(Item item)
        {
            // never updates
        }

        private void UpdateBackstagePassesItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
