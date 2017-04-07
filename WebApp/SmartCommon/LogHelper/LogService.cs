using SmartCommon.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCommon.LogHelper
{
    public class LogService
    {

        /// <summary>记录异常日志信息</summary>
        /// <param name="exception">异常</param>
        /// <param name="extContent">拓展内容信息</param>        
        /// <param name="requestParams">查询请求参数</param>
        /// <param name="responseStr">返回值</param>
        /// <param name="noticyType">消息通知的方式None = 0,Mail = 1</param>
        public static void WriteErrorLog(Exception exception, string extContent = "", string requestParams = "", string responseStr = "", int noticyType = 0)
        {
            //异步发送记录日志
            Task.Factory.StartNew(() =>
            {
                NoticyEnum sendnoticy = (NoticyEnum)noticyType;
                var stackTrace = new StackTrace(true);
                var method = stackTrace.GetFrame(1).GetMethod();
                var serviceName = "";
                if (null != method) serviceName = method.Name;
                string logContent = string.Empty;
                if (null != exception)
                {
                    logContent = exception.Message.ToString();
                }
            });
        }
        /// <summary>记录日志信息</summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="requestParams">查询请求参数</param>        
        /// <param name="extContent">拓展内容信息</param>        
        /// <param name="requestParams">查询请求参数</param>
        /// <param name="responseStr">返回值</param>
        /// <param name="noticyType">消息通知的方式None = 0,Mail = 1,Sms = 2,MailAndSms = 3</param>
        public static void WriteLog(string logContent, string extContent = "", string requestParams = "", string responseStr = "", int noticyType = 0)
        {
            Task.Factory.StartNew(() =>
            {

                NoticyEnum sendnoticy = (NoticyEnum)noticyType;
                var stackTrace = new StackTrace(true);
                var method = stackTrace.GetFrame(1).GetMethod();
                var serviceName = "";
                if (null != method) serviceName = method.Name;


            });
        }
    }
}
