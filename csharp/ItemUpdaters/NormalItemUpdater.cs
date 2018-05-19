using System;

namespace csharp
{
    class NormalItemUpdater : AbstractItemUpdater
    {
        public override void Update(Item item)
        {
            int decreaseRate = GetQualityChangeRate(item);
            item.Quality = Math.Max(0, item.Quality - decreaseRate);
            item.SellIn--;
        }

        private int GetQualityChangeRate(Item item)
        {
            return HasPassed(item) ? 2 : 1;
        }
    }
}
