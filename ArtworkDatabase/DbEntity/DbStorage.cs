using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkDatabase.DbEntity
{
    public static class DbStorage
    {
        public static ArtGalleryWorkersEntities DB_s { get; set; } = new ArtGalleryWorkersEntities();
    }

}

