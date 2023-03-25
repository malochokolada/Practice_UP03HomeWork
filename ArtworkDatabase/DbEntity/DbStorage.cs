using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkDatabase.DbEntity
{
    public static class DbStorage
    {
        public static Art_GalleryEntities DB_s { get; set; } = new Art_GalleryEntities();
    }

}

