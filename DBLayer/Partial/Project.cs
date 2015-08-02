using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Project
    {
        public void Delete()
        {
            Deleted = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public string PrimaryProjectPhoto
        {
            get
            {
                if (this.AdvertPhoto.FirstOrDefault(i => i.Deleted == false) != null)
                {
                    return this.AdvertPhoto.FirstOrDefault(i => i.Deleted == false).PhotoName;
                }
                else
                {
                    return "no-photo.jpg";
                }
            }
        }

        public string PrimarySmallProjectPhoto
        {
            get
            {
                if (this.AdvertPhoto.FirstOrDefault(i => i.Deleted == false) != null)
                {
                    return this.AdvertPhoto.FirstOrDefault(i => i.Deleted == false).SmallPhotoName;
                }
                else
                {
                    return "no-photo.jpg";
                }
            }
        }
    }

    public partial class RealEstateEntities
    {
        public Project AddProject(string projectName, string projectDescription, int? projectHousingCount, 
            int? projectTotalArea, string areaRange, string roomOptions, string deliveryDate, bool isActive, 
            int cityObjectId, string cityName, int townObjectId, string townName, int districtObjectId, string districtName, string latitude, string longitude, string gAddress)
        {
            Project obj = new Project()
            {
                ProjectName = projectName,
                ProjectDescription = projectDescription,
                ProjectHousingCount = projectHousingCount,
                ProjectTotalArea = projectTotalArea,
                AreaRange = areaRange,
                RoomOptions = roomOptions,
                DeliveryDate = deliveryDate,
                IsActive = isActive,
                CityObjectId = cityObjectId,
                CityName = cityName,
                TownObjectId = townObjectId,
                TownName = townName,
                DistrictObjectId = districtObjectId,
                DistrictName = districtName,
                Latitude = latitude,
                Longitude = longitude,
                GAddress = gAddress,
                Deleted = false
            };
            AddToProject(obj);
            return obj;
        }

        public Project GetProjectByObjectId(int objectId)
        {
            return Project.FirstOrDefault(i => i.ObjectId == objectId && !i.Deleted);
        }

        public Project GetProjectActiveByObjectId(int objectId)
        {
            return Project.FirstOrDefault(i => i.ObjectId == objectId && !i.Deleted && i.IsActive);
        }

        public List<Project> GetProjectList()
        {
            return Project.OrderByDescending(i => i.ObjectId).ToList();
        }

        public List<Project> SearchProject(int cityObjectId, int? townObjectId, int? districtObjectId)
        {
            return Project.Where(i=> i.CityObjectId == cityObjectId 
            && (townObjectId.HasValue ? i.TownObjectId == townObjectId : true) 
            && (districtObjectId.HasValue ? i.DistrictObjectId == districtObjectId : true) && i.IsActive && !i.Deleted).ToList();
        }

        public List<Project> AdvancedProjectSearch(int cityId, bool townParam, int[] townArr = null)
        {
            return Project.Where(i => i.IsActive && !i.Deleted &&
            (cityId != -1 ? i.CityObjectId == cityId : true) && 
            (townParam ? townArr.Contains(i.TownObjectId) : true)).ToList();
        }

        public List<Project> GetRecentlyProjects()
        {
            return Project.Where(i => !i.Deleted && i.IsActive).OrderByDescending(i => i.ObjectId).ToList();
        }
    }
}
