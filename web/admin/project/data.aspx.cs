using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class admin_project_data : BasePage
{
    private Project FieldCurrentProject;
    public Project CurrentProject
    {
        get
        {
            if (FieldCurrentProject == default(Project))
            {
                FieldCurrentProject = DBProvider.GetProjectByObjectId(Convert.ToInt32(Request.QueryString["project"]));
            }
            return FieldCurrentProject;
        }
    }

    private static readonly string[] _validExtensions = { "image/gif", "image/jpeg", "image/jpg", "image/png" };


    #region Helpers
    protected void Page_Load(object sender, EventArgs e)
    {
        SetTab();
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlTown.Items.Insert(0, new ListItem("Önce il seçiniz", ""));
        ddlDistrict.Items.Insert(0, new ListItem("Önce ilçe seçiniz", ""));

        if (CurrentProject == null)
        {
            pnlNoProject.Visible = true;
            pnlNoProjectForPhoto.Visible = true;
        }
        else
        {
            #region Project Detail

            ddlCity.SelectedValue = CurrentProject.CityObjectId.ToString();
            ddlTown.SelectedValue = CurrentProject.TownObjectId.ToString();
            ddlDistrict.SelectedValue = CurrentProject.DistrictObjectId.ToString();

            tbProjectName.Text = CurrentProject.ProjectName;
            tbProjectHousingCount.Text = CurrentProject.ProjectHousingCount.ToString();
            tbProjectTotalArea.Text = CurrentProject.ProjectTotalArea.ToString();
            tbAreaRange.Text = CurrentProject.AreaRange;
            tbRoomOptions.Text = CurrentProject.RoomOptions;
            tbDeliveryDate.Text = CurrentProject.DeliveryDate;
            tbProjectDescription.Text = CurrentProject.ProjectDescription;
            hfLat.Value = CurrentProject.Latitude;
            hfLong.Value = CurrentProject.Longitude;
            hfAddress.Value = CurrentProject.GAddress;
            hfCurrentProject.Value = CurrentProject.ObjectId.ToString();

            if (!CurrentProject.IsActive)
            {
                lbntActivate.Visible = true;
                pnlActiveStatus.Visible = true;
            }
            else
            {
                lbtnDeactivate.Visible = true;
            }

            #endregion

            #region Project Housing

            pnlProjectAdvert.Visible = true;
            
            BindProjectAdvert();
            if (Request.QueryString["project_status"] == "0")
            {
                pnlProjectAdded.Visible = true;
            }

            #endregion

            #region Project Photo

            pnlProjectPhoto.Visible = true;
            BindProjectPhoto();

            
            #endregion
        }
    }

    protected void SetTab()
    {
        if (Request.QueryString["tab"] != null)
        {
            string script = "setTab('" + Request.QueryString["tab"] + "')";
            ClientScript.RegisterStartupScript(GetType(), "setTabKey", script, true);
        }
    }

    protected void BindProjectAdvert()
    {
        rptProjectAdvert.DataSource = CurrentProject.ProjectAdvertRelation.Where(i => !i.Deleted);
        rptProjectAdvert.DataBind();
    }

    protected void BindProjectPhoto()
    {
        rptProjectPhotos.DataSource = CurrentProject.AdvertPhoto.Where(i => !i.Deleted);
        rptProjectPhotos.DataBind();
    }
    #endregion
    
    #region Dropdown Events
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTown.Items.Clear();

        if (ddlCity.SelectedValue != "")
        {
            ddlTown.DataSource = DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCity.SelectedValue));
            ddlTown.DataBind();
            ddlTown.Items.Insert(0, new ListItem("İlçe seçiniz", ""));
        }
        else
        {
            ddlTown.Items.Insert(0, new ListItem("Önce il seçiniz", ""));
        }
    }
    protected void ddlTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDistrict.Items.Clear();

        if (ddlTown.SelectedValue != "")
        {
            ddlDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(Convert.ToInt32(ddlTown.SelectedValue));
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Semt seçiniz", ""));
        }
        else
        {
            ddlDistrict.Items.Insert(0, new ListItem("Önce ilçe seçiniz", ""));
        }
    }
    #endregion

    #region Button Clicks
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string _city = ddlCity.SelectedValue;
        string _town = ddlTown.SelectedValue;
        string _district = ddlDistrict.SelectedValue;
        string _projectName = tbProjectName.Text.Trim();
        string _projectDescription = tbProjectDescription.Text.Trim();
        string _projectHousingCount = tbProjectHousingCount.Text.Trim();
        string _projectTotalArea = tbProjectTotalArea.Text.Trim();
        string _areaRange = tbAreaRange.Text.Trim();
        string _roomOptions = tbRoomOptions.Text.Trim();
        string _deliveryDate = tbDeliveryDate.Text.Trim();

        if (!string.IsNullOrEmpty(_projectName) && !string.IsNullOrEmpty(_projectDescription) && !string.IsNullOrEmpty(_town) && !string.IsNullOrEmpty(_city))
        {
            int cityId = Convert.ToInt32(_city);
            int townId = Convert.ToInt32(_town);
            int districtId = Convert.ToInt32(_district);
            int? projectHousingCount = null, projectTotalArea = null;
            if (!string.IsNullOrEmpty(_projectHousingCount))
                projectHousingCount = Convert.ToInt32(_projectHousingCount);
            if (!string.IsNullOrEmpty(_projectTotalArea))
                projectTotalArea = Convert.ToInt32(_projectTotalArea);

            City city = DBProvider.GetCityByObjectId(cityId);
            Town town = DBProvider.GetTownByObjectId(townId);
            District district = DBProvider.GetDistrictByObjectId(districtId);


            if (CurrentProject == null)
            {
                #region Create Project

                Project obj = DBProvider.AddProject(_projectName, _projectDescription, projectHousingCount, projectTotalArea, _areaRange, _roomOptions, _deliveryDate, false,
                    cityId, city.CityName, townId, town.TownName, districtId, district.DistrictName, hfLat.Value, hfLong.Value, hfAddress.Value);
                DBProvider.SaveChanges();
                Response.Redirect("data.aspx?project=" + obj.ObjectId.ToString() + "&project_status=0&tab=tab2");

                #endregion
            }
            else
            {
                CurrentProject.ProjectName = _projectName;
                CurrentProject.ProjectDescription = _projectDescription;
                CurrentProject.ProjectHousingCount = projectHousingCount;
                CurrentProject.ProjectTotalArea = projectTotalArea;
                CurrentProject.AreaRange = _areaRange;
                CurrentProject.RoomOptions = _roomOptions;
                CurrentProject.DeliveryDate = _deliveryDate;
                CurrentProject.CityObjectId = cityId;
                CurrentProject.CityName = city.CityName;
                CurrentProject.TownObjectId = townId;
                CurrentProject.TownName = town.TownName;
                CurrentProject.DistrictObjectId = districtId;
                CurrentProject.DistrictName = district.DistrictName;

                DBProvider.SaveChanges();
                BindData();
                SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle,
                    ApplicationGenericControls.OperationStatus.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
            }

        }

    }

    protected void btnSaveProjectAdvertRelation_Click(object sender, EventArgs e)
    {
        pnlProjectAdded.Visible = false;
        if (!string.IsNullOrEmpty(tbProjectAdvertHousingName.Text.Trim()) && !string.IsNullOrEmpty(tbProjectAdvertRelated.Text.Trim()))
        {
            Advert advert = DBProvider.GetAdvertByAdvertNumber(tbProjectAdvertRelated.Text);
            if (advert != null)
            {
                ProjectAdvertRelation relation = DBProvider.AddProjectAdvertRelation(CurrentProject.ObjectId, advert.ObjectId, tbProjectAdvertHousingName.Text.Trim());
                advert.ProjectObjectId = CurrentProject.ObjectId;
                DBProvider.SaveChanges();

                BindProjectAdvert();
                SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle,
                    ApplicationGenericControls.Operations.ProjectAdvert.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
                tbProjectAdvertHousingName.Text = string.Empty;
                tbProjectAdvertRelated.Text = string.Empty;
            }
            else
            {
                SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusERRORTitle,
                    ApplicationGenericControls.Operations.ProjectAdvert.StatusERRORDescription, ApplicationGenericControls.OperationStatus.StatusERRORCSS);
            }
        }
    }

    protected void lbntActivate_Click(object sender, EventArgs e)
    {
        CurrentProject.IsActive = true;
        DBProvider.SaveChanges();

        lbntActivate.Visible = false;
        lbtnDeactivate.Visible = true;
        pnlActiveStatus.Visible = false;
    }

    protected void lbtnDeactivate_Click(object sender, EventArgs e)
    {
        CurrentProject.IsActive = false;
        DBProvider.SaveChanges();

        lbntActivate.Visible = true;
        lbtnDeactivate.Visible = false;
        pnlActiveStatus.Visible = true;
    }

    protected void btnSavePicture_Click(object sender, EventArgs e)
    {
        string[] allowedExtensions = new string[] { "jpg", "gif", "jpeg", "png" };
        if (fuPic.HasFile && _validExtensions.Contains(fuPic.PostedFile.ContentType))
        {
            FileProcess fp = new FileProcess();
            string pic = fp.UploadImageConstantSize(fuPic.PostedFile.InputStream, 570, 425, "~/uploads/");
            string picSmall = fp.UploadImageConstantSize(fuPic.PostedFile.InputStream, 270, 201, "~/uploads/");

            if (!string.IsNullOrEmpty(pic))
            {
                AdvertPhoto photo = DBProvider.AddAdvertPhoto(pic, picSmall, null, CurrentProject.ObjectId, 0);
                DBProvider.SaveChanges();
                if (photo != null)
                {
                    SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, 
                        ApplicationGenericControls.Operations.AdvertPhoto.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
                    BindProjectPhoto();
                }
                else
                {
                    SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusERRORTitle, 
                        ApplicationGenericControls.Operations.AdvertPhoto.StatusERRORDescription, ApplicationGenericControls.OperationStatus.StatusERRORCSS);
                }
            }
        }
        else
        {
            SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusERRORTitle, ApplicationGenericControls.Operations.AdvertPhoto.StatusERRORDescription, ApplicationGenericControls.OperationStatus.StatusERRORCSS);
        }

        string script = "setTab('tab2');";
        RegisterStartupScript("setTabKey", script);
    }
    #endregion
    
    #region Repeater Events
    protected void rptProjectPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deletePhoto")
        {
            int photoId = Convert.ToInt32(e.CommandArgument);
            AdvertPhoto photo = DBProvider.GetAdvertPhotoByObjectId(photoId);
            photo.Delete();
            DBProvider.SaveChanges();

            BindProjectPhoto();
            SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, 
                ApplicationGenericControls.Operations.AdvertPhoto.StatusDELETEDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
            string script = "setTab('tab2');";
            RegisterStartupScript("setTabKey", script);
        }
    }    

    protected void rptProjectAdvert_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deleteProjectAdvert")
        {
            int advertProjectId = Convert.ToInt32(e.CommandArgument);
            ProjectAdvertRelation relation = DBProvider.GetProjectAdvertRelationByObjectId(advertProjectId);
            relation.Delete();
            DBProvider.SaveChanges();

            BindProjectAdvert();
            SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, 
                ApplicationGenericControls.Operations.ProjectAdvert.StatusDELETEDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
            string script = "setTab('tab3');";
            RegisterStartupScript("setTabKey", script);
        }
    }
    #endregion

}