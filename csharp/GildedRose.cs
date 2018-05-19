using System;
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
            int decreaseRate = HasPassed(item) ? 2 : 1;
            item.Quality = Math.Max(0, item.Quality - decreaseRate);
            item.SellIn--;
        }

        private bool HasPassed(Item item)
        {
            return item.SellIn == 0;
        }

        private void UpdateAgedBrieItem(Item item)
        {
            int increaseRate = GetQualityChangeRate(item);
            item.Quality = Math.Min(50, item.Quality + increaseRate);
            item.SellIn--;
        }

        private int GetQualityChangeRate(Item item)
        {
            return HasPassed(item) ? 2 : 1;
        }

        private void UpdateSulfurasItem(Item item)
        {
            // never updates
        }

        private void UpdateBackstagePassesItem(Item item)
        {
            if (HasPassed(item))
            {
                item.Quality = 0;
            }
            else
            {
                int increaseRate = GetQualityChangeRateForBackStagePasses(item);
                item.Quality = Math.Min(50, item.Quality + increaseRate);
            }            

            item.SellIn--;
        }

        private int GetQualityChangeRateForBackStagePasses(Item item)
        {
            if (item.SellIn < 6)
            {
                return 3;
            }
            else if (item.SellIn < 11)
            {
                return 2;
            } else
            {
                return 1;
            }
        }
    }
}
