using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class RoomHall
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public RoomHall AddRoomHall(string roomHallName, string roomHallKey)
        {
            RoomHall obj = new RoomHall() 
            {
                RoomHallName = roomHallName,
                RoomHallKey = roomHallKey,
                Deleted = false
            };
            AddToRoomHall(obj);
            return obj;
        }

        public List<RoomHall> GetRoomHallList()
        {
            return RoomHall.Where(i => i.Deleted == false).OrderBy(i => i.RoomHallKey).ToList();
        }

        public RoomHall GetRoomHallByObjectId(int objectId)
        {
            return RoomHall.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
