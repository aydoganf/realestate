﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AdvertPhoto
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AdvertPhoto AddAdvertPhoto(string photoName, string smallPhotoName, int? advertObjectId, int? projectObjectId, int sortOrder)
        {
            AdvertPhoto obj = new AdvertPhoto() 
            {
                PhotoName = photoName,
                SmallPhotoName = smallPhotoName,
                AdvertObjectId = advertObjectId,
                ProjectObjectId = projectObjectId,
                SortOrder = sortOrder,
                Deleted = false
            };
            AddToAdvertPhoto(obj);
            return obj;
        }

        public List<AdvertPhoto> GetAdvertPhotoListByAdvertObjectId(int advertObjectId)
        {
            return AdvertPhoto.Where(i => i.AdvertObjectId == advertObjectId && i.Deleted == false).OrderBy(i => i.SortOrder).ToList();
        }

        public AdvertPhoto GetAdvertPhotoByObjectId(int objectId)
        {
            return AdvertPhoto.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
