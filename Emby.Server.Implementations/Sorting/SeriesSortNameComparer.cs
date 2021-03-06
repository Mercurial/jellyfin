using System;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Sorting;
using MediaBrowser.Model.Querying;

namespace Emby.Server.Implementations.Sorting
{
    class SeriesSortNameComparer : IBaseItemComparer
    {
        /// <summary>
        /// Compares the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        public int Compare(BaseItem x, BaseItem y)
        {
            return string.Compare(GetValue(x), GetValue(y), StringComparison.CurrentCultureIgnoreCase);
        }

        private static string GetValue(BaseItem item)
        {
            var hasSeries = item as IHasSeries;

            return hasSeries != null ? hasSeries.FindSeriesSortName() : null;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => ItemSortBy.SeriesSortName;
    }
}
