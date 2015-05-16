using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Floor
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public Floor AddFloor(string floorName, string floorKey)
        {
            Floor obj = new Floor() 
            {
                FloorName = floorName,
                FloorKey = floorKey,
                Deleted = false
            };
            AddToFloor(obj);
            return obj;
        }

        public List<Floor> GetFloorList()
        {
            return Floor.Where(i => i.Deleted == false).OrderBy(i => i.FloorName).ToList();
        }

        public Floor GetFloorByObjectId(int objectId)
        {
            return Floor.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
