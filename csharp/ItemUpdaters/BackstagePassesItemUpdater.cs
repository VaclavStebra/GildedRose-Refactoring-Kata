using System;

namespace csharp.ItemUpdaters
{
    class BackstagePassesItemUpdater : AbstractItemUpdater
    {
        public override void Update(Item item)
        {
            if (HasPassed(item))
            {
                item.Quality = 0;
            }
            else
            {
                int increaseRate = GetQualityChangeRate(item);
                item.Quality = Math.Min(50, item.Quality + increaseRate);
            }

            item.SellIn--;
        }

        private int GetQualityChangeRate(Item item)
        {
            if (item.SellIn < 6)
            {
                return 3;
            }
            else if (item.SellIn < 11)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
