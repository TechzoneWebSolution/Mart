﻿using System.Web;
using System;

namespace Blog.Common
{
    public class ProjectSession
    {
        /// <summary>
        /// Gets or sets the client connection string.
        /// </summary>
        /// <value>The client connection string.</value>
        public static string ClientConnectionString
        {
            get
            {
                if (HttpContext.Current.Session["ConnectionString"] == null)
                {
                    return Configurations.ConnectionString;
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["ConnectionString"]);
                }
            }

            set
            {
                HttpContext.Current.Session["ConnectionString"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        public static int AdminUserID
        {
            get
            {
                if (HttpContext.Current.Session["AdminUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AdminUserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminUserID"] = value;
            }
        }
        public static int CustomerId
        {
            get
            {
                if (HttpContext.Current.Session["CustomerId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["CustomerId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CustomerId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the company id of the logged in user.
        /// </summary>
        public static string CompanyId
        {
            get
            {
                if (HttpContext.Current.Session["CompanyId"] == null)
                {
                    return "MA==";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CompanyId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CompanyId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department id of the logged in user.
        /// </summary>
        public static string DepartmentId
        {
            get
            {
                if (HttpContext.Current.Session["DepartmentId"] == null)
                {
                    return "MA==";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["DepartmentId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["DepartmentId"] = value;
            }
        }


        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string DepartmentName
        {
            get
            {
                if (HttpContext.Current.Session["DepartmentName"] == null)
                {
                    return "No Department";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["DepartmentName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["DepartmentName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string CustomerName
        {
            get
            {
                if (HttpContext.Current.Session["CustomerName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CustomerName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CustomerName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string AggregatorName
        {
            get
            {
                if (HttpContext.Current.Session["AggregatorName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AggregatorName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AggregatorName"] = value;
            }
        }


        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        public static int SubAdminUserID
        {
            get
            {
                if (HttpContext.Current.Session["SubAdminUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["SubAdminUserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["SubAdminUserID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the SubAdminResetUserID identifier.
        /// </summary>
        public static int SubAdminResetUserID
        {
            get
            {
                if (HttpContext.Current.Session["SubAdminResetUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["SubAdminResetUserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["SubAdminResetUserID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the admin user.
        /// </summary>
        /// <value>The name of the admin user.</value>
        public static string AdminUserName
        {
            get
            {
                if (HttpContext.Current.Session["AdminUserName"] == null)
                {
                    return "Admin";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AdminUserName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminUserName"] = value;
            }
        }

        public static string CheckType
        {
            get
            {
                if (HttpContext.Current.Session["CheckType"] == null)
                {
                    return "0";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CheckType"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CheckType"] = value;
            }
        }


        public static string StepsRemaining
        {
            get
            {
                if (HttpContext.Current.Session["StepsRemaining"] == null)
                {
                    return "StepsRemaining";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["StepsRemaining"]);
                }
            }

            set
            {
                HttpContext.Current.Session["StepsRemaining"] = value;
            }
        }


        public static string CheckLastDate
        {
            get
            {
                if (HttpContext.Current.Session["CheckLastDate"] == null)
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CheckLastDate"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CheckLastDate"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public static int UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["UserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public static int UserType
        {
            // UserType - 1 = Admin
            // UserType - 2 = Customers
            get
            {
                if (HttpContext.Current.Session["UserType"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["UserType"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserType"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["UserName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static string Mobile
        {
            get
            {
                if (HttpContext.Current.Session["Mobile"] == null)
                {
                    return "Mobile";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Mobile"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Mobile"] = value;
            }
        }

        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session["Email"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Email"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string Menu
        {
            get
            {
                if (HttpContext.Current.Session["Menu"] == null)
                {
                    return "Menu";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Menu"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Menu"] = value;
            }
        }

        public static int SubscriptionId
        {
            get
            {
                if (HttpContext.Current.Session["SubscriptionId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["SubscriptionId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["SubscriptionId"] = value;
            }
        }

        public static int InstituteId
        {
            get
            {
                if (HttpContext.Current.Session["InstituteId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["InstituteId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["InstituteId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the access token of the facebook user.
        /// </summary>
        /// <value>The value of the facebook user access token.</value>
        public static string AccessToken
        {
            get
            {
                if (HttpContext.Current.Session["AccessToken"] == null)
                {
                    return "AccessToken";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AccessToken"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AccessToken"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        /// <value>
        /// The plan.
        /// </value>        


        /// <summary>
        /// Gets or sets the facebook business ads Id.
        /// </summary>
        /// <value>The value of the facebook business ads Id.</value>
        public static string BusinessAdAccountID
        {
            get
            {
                if (HttpContext.Current.Session["BusinessAdAccountID"] == null)
                {
                    return "BusinessAdAccountID";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessAdAccountID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessAdAccountID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the facebook business campaign Id.
        /// </summary>
        /// <value>The value of the facebook business campaign Id.</value>
        public static string BusinessCampaignId
        {
            get
            {
                if (HttpContext.Current.Session["BusinessCampaignId"] == null)
                {
                    return "BusinessCampaignId";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessCampaignId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessCampaignId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the facebook business adset Id.
        /// </summary>
        /// <value>The value of the facebook business adset Id.</value>
        public static string BusinessAdsetId
        {
            get
            {
                if (HttpContext.Current.Session["BusinessAdsetId"] == null)
                {
                    return "BusinessAdsetId";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessAdsetId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessAdsetId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the facebook business ads Id.
        /// </summary>
        /// <value>The value of the facebook business ads Id.</value>
        public static string BusinessAdsID
        {
            get
            {
                if (HttpContext.Current.Session["BusinessAdsID"] == null)
                {
                    return "BusinessAdsID";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessAdsID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessAdsID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["PageSize"] != null)
                {
                    if (ConvertTo.Integer(HttpContext.Current.Session["PageSize"]) == 0)
                    {
                        HttpContext.Current.Session["PageSize"] = Configurations.PageSize;
                    }

                    return ConvertTo.Integer(HttpContext.Current.Session["PageSize"]);

                }
                else
                {
                    return 10;
                }
            }

            set
            {
                HttpContext.Current.Session["PageSize"] = value;
            }
        }
        public static int TestID
        {
            get
            {
                if (HttpContext.Current.Session["TestID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["TestID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["TestID"] = value;
            }
        }

        public static DateTime StartTime
        {
            get
            {
                if (HttpContext.Current.Session["StartTime"] == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return (DateTime)(HttpContext.Current.Session["StartTime"]);
                }
            }

            set
            {
                HttpContext.Current.Session["StartTime"] = value;
            }
        }

        public static int Result
        {
            get
            {
                if (HttpContext.Current.Session["Result"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["Result"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Result"] = value;
            }
        }

        public static bool IsAdmin
        {
            get
            {
                if (HttpContext.Current.Session["IsAdmin"] == null)
                {
                    return false;
                }
                else
                {
                    return ConvertTo.Boolean(HttpContext.Current.Session["IsAdmin"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsLogin"] = value;
            }
        }

        public static string Otp
        {
            get
            {
                if (HttpContext.Current.Session["Otp"] == null)
                {
                    return "Otp";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Otp"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Otp"] = value;
            }
        }


        public static string OtpType
        {
            get
            {
                if (HttpContext.Current.Session["OtpType"] == null)
                {
                    return "OtpType";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["OtpType"]);
                }
            }

            set
            {
                HttpContext.Current.Session["OtpType"] = value;
            }
        }

        public static string Password
        {
            get
            {
                if (HttpContext.Current.Session["Password"] == null)
                {
                    return "Password";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Password"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Password"] = value;
            }
        }

        public static string IsVerified
        {
            get
            {
                if (HttpContext.Current.Session["IsVerified"] == null)
                {
                    return "Not Verified";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["IsVerified"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsVerified"] = value;
            }
        }

        public static string IsExists
        {
            get
            {
                if (HttpContext.Current.Session["IsExists"] == null)
                {
                    return "No";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["IsExists"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsExists"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        public static int AdminRoleID
        {
            get
            {
                if (HttpContext.Current.Session["AdminRoleID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AdminRoleID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminRoleID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int TempId
        {
            get
            {
                if (HttpContext.Current.Session["TempId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["TempId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["TempId"] = value;
            }
        }
       
        /// <summary>
        /// Gets or sets the profile of the admin/subadmin user.
        /// </summary>       
        public static string UserProfile
        {
            get
            {
                if (HttpContext.Current.Session["UserProfile"] == null)
                {
                    return "UserProfile";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["UserProfile"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserProfile"] = value;
            }
        }

        public static bool IsOrganizationCount
        {
            get
            {
                if (HttpContext.Current.Session["IsOrganizationCount"] == null)
                {
                    return true;
                }
                else
                {
                    return ConvertTo.Boolean(HttpContext.Current.Session["IsOrganizationCount"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsOrganizationCount"] = value;
            }
        }
    }
}