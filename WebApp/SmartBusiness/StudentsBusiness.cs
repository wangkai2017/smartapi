using SmartIBusiness;
using System;
using System.Collections.Generic;
using SmartEntity;
using Chloe.SqlServer;
using SmartCommon.DbHelper;
using SmartCommon.ConstHelper;

namespace SmartBusiness
{
    public class StudentsBusiness : IStudentsBusiness
    {
        /* DbContext 是非线程安全的，正式使用不能设置为 static */
        public List<T_Students> GetStudentList()
        {
            using (var context = new MsSqlContext(DbHelper.ConnectionString, DatabaseNameConst.DBTest))
            {
                var entity = context.Query<T_Students>();
                return entity.Where(e => e.Id > 0).ToList();
            }
        }
    }
}
