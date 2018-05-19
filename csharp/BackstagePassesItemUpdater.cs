using System;

namespace csharp
{
    class BackstagePassesItemUpdater : IItemUpdater
    {
        public void Update(Item item)
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

        private bool HasPassed(Item item)
        {
            return item.SellIn == 0;
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
            }
            else
            {
                return 1;
            }
        }
    }
}
