﻿using System.Collections.Generic;
using NutzCode.InMemoryIndex;
using Shoko.Models.Server;

namespace Shoko.Server.Repositories.Cached
{
    public class TvDB_ImagePosterRepository : BaseCachedRepository<TvDB_ImagePoster, int>
    {
        private PocoIndex<int, TvDB_ImagePoster, int> SeriesIDs;
        private PocoIndex<int, TvDB_ImagePoster, int> TvDBIDs;

        public override void PopulateIndexes()
        {
            SeriesIDs = new PocoIndex<int, TvDB_ImagePoster, int>(Cache, a => a.SeriesID);
            TvDBIDs = new PocoIndex<int, TvDB_ImagePoster, int>(Cache, a => a.Id);
        }

        public override void RegenerateDb()
        {
        }

        protected override int SelectKey(TvDB_ImagePoster entity)
        {
            return entity.TvDB_ImagePosterID;
        }

        private TvDB_ImagePosterRepository()
        {
        }

        public static TvDB_ImagePosterRepository Create()
        {
            return new TvDB_ImagePosterRepository();
        }

        public TvDB_ImagePoster GetByTvDBID(int id)
        {
            return TvDBIDs.GetOne(id);
        }

        public List<TvDB_ImagePoster> GetBySeriesID(int seriesID)
        {
            return SeriesIDs.GetMultiple(seriesID);
        }
    }
}