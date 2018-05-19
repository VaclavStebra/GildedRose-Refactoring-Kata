using System;

namespace csharp.ItemUpdaters
{
    class AgedBrieItemUpdater : AbstractItemUpdater
    {
        public override void Update(Item item)
        {
            int increaseRate = GetQualityChangeRate(item);
            item.Quality = Math.Min(50, item.Quality + increaseRate);
            item.SellIn--;
        }

        private int GetQualityChangeRate(Item item)
        {
            return HasPassed(item) ? 2 : 1;
        }
    }
}
