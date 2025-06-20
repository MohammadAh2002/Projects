using Data_Access_Layer;
using DTO_Layer;
using Helper_Layer;

namespace Business_Logic_Layer
{
    public class UserLogsBLL
    {

        public static bool Logout(long ID, DateTime? LoginTime)
        {
            if (UserLogsDAL.Logout(ID, LoginTime))
            {
                clsGlobal.CurrentUserID = -1;
                clsGlobal.CurrentUserLoginTime = null;

                return true;
            }

            return false;

        }

        public static bool Logout()
        {

            if (UserLogsDAL.Logout(clsGlobal.CurrentUserID, clsGlobal.CurrentUserLoginTime))
            {
                clsGlobal.CurrentUserID = -1;
                clsGlobal.CurrentUserLoginTime = null;

                return true;
            }

            return false;
        }

        public static List<stUserLogsHistory>? UserLogsHistory(long ID)
        {
            return UserLogsDAL.UserLogsHistory(ID);
        }


    }
}
