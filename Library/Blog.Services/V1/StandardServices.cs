using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Entities.V1;
using Blog.Services.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Blog.Services.V1
{
    public class StandardServices : AbstractStandardServices
    {
        private AbstractStandardDao abstractStandardDao;

        public StandardServices(AbstractStandardDao abstractStandardDao)
        {
            this.abstractStandardDao = abstractStandardDao;
        }

        public override SuccessResult<AbstractStandard> StandardById(int Id)
        {
            return this.abstractStandardDao.StandardById(Id);
        }
        public override PagedList<AbstractStandard> StandardSelectAll(PageParam pageParam, string search)
        {
            return this.abstractStandardDao.StandardSelectAll(pageParam, search);
        }

        public override SuccessResult<AbstractStandard> InsertUpdateStandards(AbstractStandard abstractStandard, IEnumerable<HttpPostedFileBase> news_Json, IEnumerable<HttpPostedFileBase> Live_Json = null, IEnumerable<HttpPostedFileBase> Blog_Json = null)
        {
            AbstractStandard abstractDocuments = new Standard();
            var camp = this.abstractStandardDao.InsertUpdateStandards(abstractStandard);
            SuccessResult<AbstractStandard> campgn = new SuccessResult<AbstractStandard>();
            if (camp.Code == 200)
            {
                if (Live_Json != null)
                {
                    if (Live_Json.ElementAt(0) != null && camp != null)
                    {
                        abstractDocuments.Path = "Standard/" + camp.Item.Id + "/";
                        abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/" + camp.Item.Id + "/");
                        var file = Live_Json.ElementAt(0);
                        string imgName = string.Empty;
                        if (!Directory.Exists(abstractDocuments.AvatarFolder))
                        {
                            Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                        }
                        file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                        string avatarpath = abstractDocuments.AvatarFolder + imgName;
                        abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                        if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                        {
                            S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                        }
                        abstractStandard.Live_json = abstractDocuments.DocumentPath;
                        abstractStandard.Id = camp.Item.Id;
                        campgn = this.abstractStandardDao.InsertUpdateStandards(abstractStandard);
                    }
                }
                if (Blog_Json != null)
                {
                    if (Blog_Json.ElementAt(0) != null && camp != null)
                    {
                        abstractDocuments.Path = "Standard/" + camp.Item.Id + "/";
                        abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/" + camp.Item.Id + "/");
                        var file = Blog_Json.ElementAt(0);
                        string imgName = string.Empty;
                        if (!Directory.Exists(abstractDocuments.AvatarFolder))
                        {
                            Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                        }
                        file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                        string avatarpath = abstractDocuments.AvatarFolder + imgName;
                        abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                        if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                        {
                            S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                        }
                        abstractStandard.Blog_json = abstractDocuments.DocumentPath;
                        abstractStandard.Id = camp.Item.Id;
                        campgn = this.abstractStandardDao.InsertUpdateStandards(abstractStandard);
                    }
                }
                if (news_Json != null)
                {
                    if (news_Json.ElementAt(0) != null && camp != null)
                    {
                        abstractDocuments.Path = "Standard/" + camp.Item.Id + "/";
                        abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/" + camp.Item.Id + "/");
                        var file = news_Json.ElementAt(0);
                        string imgName = string.Empty;
                        if (!Directory.Exists(abstractDocuments.AvatarFolder))
                        {
                            Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                        }
                        file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                        string avatarpath = abstractDocuments.AvatarFolder + imgName;
                        abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                        if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                        {
                            S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                        }
                        abstractStandard.News_json = abstractDocuments.DocumentPath;
                        abstractStandard.Id = camp.Item.Id;
                        campgn = this.abstractStandardDao.InsertUpdateStandards(abstractStandard);
                    }
                }
            }
            return camp;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDate(string Key, string Date = "")
        {
            return this.abstractStandardDao.StandardByIdByDate(Key, Date);
        }

        public override bool StandardBannerJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> Banner_json = null)
        {
            AbstractStandard abstractDocuments = new Standard();
            SuccessResult<AbstractStandard> abstractStandard = new SuccessResult<AbstractStandard>();
            if (Banner_json != null)
            {
                if (Banner_json.ElementAt(0) != null && StandardId > 0)
                {
                    abstractDocuments.Path = "Standard/Banner/" + StandardId + "/";
                    abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/Banner/" + StandardId + "/");
                    var file = Banner_json.ElementAt(0);
                    string imgName = string.Empty;
                    if (!Directory.Exists(abstractDocuments.AvatarFolder))
                    {
                        Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                    }
                    file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                    string avatarpath = abstractDocuments.AvatarFolder + imgName;
                    abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                    if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                    {
                        S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                    }
                    string Banner_json_file = abstractDocuments.DocumentPath;
                    var campgn = this.abstractStandardDao.StandardBannerJsonUpdate(StandardId, Banner_json_file);
                }
            }
            return true;
        }

        public override bool StandardHomeScrrenJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> HomeScreen_json = null)
        {
            AbstractStandard abstractDocuments = new Standard();
            SuccessResult<AbstractStandard> abstractStandard = new SuccessResult<AbstractStandard>();
            if (HomeScreen_json != null)
            {
                if (HomeScreen_json.ElementAt(0) != null && StandardId > 0)
                {
                    abstractDocuments.Path = "Standard/HomeScreen/" + StandardId + "/";
                    abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/HomeScreen/" + StandardId + "/");
                    var file = HomeScreen_json.ElementAt(0);
                    string imgName = string.Empty;
                    if (!Directory.Exists(abstractDocuments.AvatarFolder))
                    {
                        Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                    }
                    file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                    string avatarpath = abstractDocuments.AvatarFolder + imgName;
                    abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                    if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                    {
                        S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                    }
                    string HomeScreen_json_file = abstractDocuments.DocumentPath;
                    var campgn = this.abstractStandardDao.StandardHomeScrrenJsonUpdate(StandardId, HomeScreen_json_file);
                }
            }
            return true;
        }
        public override SuccessResult<AbstractStandard> StandardByIdByDateForHomeScreenJson(string Key, string Date = "")
        {
            return this.abstractStandardDao.StandardByIdByDateForHomeScreenJson(Key, Date);
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForBannerJson(string Key, string Date = "")
        {
            return this.abstractStandardDao.StandardByIdByDateForBannerJson(Key, Date);
        }

        public override SuccessResult<AbstractStandard> StandardByKeyLetestVersion(string Key)
        {
            return this.abstractStandardDao.StandardByKeyLetestVersion(Key);
        }
        public override bool StandardOtherAppDataJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> OtherAppData_JSON = null)
        {
            AbstractStandard abstractDocuments = new Standard();
            SuccessResult<AbstractStandard> abstractStandard = new SuccessResult<AbstractStandard>();
            if (OtherAppData_JSON != null)
            {
                if (OtherAppData_JSON.ElementAt(0) != null && StandardId > 0)
                {
                    abstractDocuments.Path = "Standard/OtherAppData/" + StandardId + "/";
                    abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/OtherAppData/" + StandardId + "/");
                    var file = OtherAppData_JSON.ElementAt(0);
                    string imgName = string.Empty;
                    if (!Directory.Exists(abstractDocuments.AvatarFolder))
                    {
                        Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                    }
                    file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                    string avatarpath = abstractDocuments.AvatarFolder + imgName;
                    abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                    if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                    {
                        S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                    }
                    string OtherAppDataJson = abstractDocuments.DocumentPath;
                    var campgn = this.abstractStandardDao.StandardOtherAppDataJsonUpdate(StandardId, OtherAppDataJson);
                }
            }
            return true;
        }
        public override bool StandardCompetativeExamsJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> CompetativeExams_JSON = null)
        {
            AbstractStandard abstractDocuments = new Standard();
            SuccessResult<AbstractStandard> abstractStandard = new SuccessResult<AbstractStandard>();
            if (CompetativeExams_JSON != null)
            {
                if (CompetativeExams_JSON.ElementAt(0) != null && StandardId > 0)
                {
                    abstractDocuments.Path = "Standard/CompetativeExams/" + StandardId + "/";
                    abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/CompetativeExams/" + StandardId + "/");
                    var file = CompetativeExams_JSON.ElementAt(0);
                    string imgName = string.Empty;
                    if (!Directory.Exists(abstractDocuments.AvatarFolder))
                    {
                        Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                    }
                    file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                    string avatarpath = abstractDocuments.AvatarFolder + imgName;
                    abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                    if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                    {
                        S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                    }
                    string CompetativeExamsJson = abstractDocuments.DocumentPath;
                    var campgn = this.abstractStandardDao.StandardCompetativeExamsJsonUpdate(StandardId, CompetativeExamsJson);
                }
            }
            return true;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForOtherAppData(string Key, string Date = "")
        {
            return this.abstractStandardDao.StandardByIdByDateForOtherAppData(Key, Date);
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForCompetativeExams(string Key, string Date = "")
        {
            return this.abstractStandardDao.StandardByIdByDateForCompetativeExams(Key, Date);
        }

        public override bool StandardOtherPDFMeterialUpdate(int StandardId, IEnumerable<HttpPostedFileBase> OtherPDFMeterialFile= null)
        {
            AbstractStandard abstractDocuments = new Standard();
            SuccessResult<AbstractStandard> abstractStandard = new SuccessResult<AbstractStandard>();
            if (OtherPDFMeterialFile != null)
            {
                if (OtherPDFMeterialFile.ElementAt(0) != null && StandardId > 0)
                {
                    abstractDocuments.Path = "Standard/OtherPDFMeterial/" + StandardId + "/";
                    abstractDocuments.AvatarFolder = HttpContext.Current.Server.MapPath("~/Standard/OtherPDFMeterial/" + StandardId + "/");
                    var file = OtherPDFMeterialFile.ElementAt(0);
                    string imgName = string.Empty;
                    if (!Directory.Exists(abstractDocuments.AvatarFolder))
                    {
                        Directory.CreateDirectory(abstractDocuments.AvatarFolder);
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        imgName = DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName;
                    }
                    file.SaveAs(abstractDocuments.AvatarFolder + imgName);
                    string avatarpath = abstractDocuments.AvatarFolder + imgName;
                    abstractDocuments.DocumentPath = abstractDocuments.Path + imgName;
                    if (!string.IsNullOrWhiteSpace(abstractDocuments.DocumentPath) && !string.IsNullOrWhiteSpace(avatarpath))
                    {
                        S3FileUpload(avatarpath, abstractDocuments.DocumentPath);
                    }
                    string OtherPDFMeterial = abstractDocuments.DocumentPath;
                    var campgn = this.abstractStandardDao.StandardOtherPDFMeterialUpdate(StandardId, OtherPDFMeterial);
                }
            }
            return true;
        }
        public override SuccessResult<AbstractStandard> StandardByIdByDateForOtherPDFMeterial(string Key, string Date = "")
        {
            return this.abstractStandardDao.StandardByIdByDateForOtherPDFMeterial(Key, Date);
        }

    }
}
