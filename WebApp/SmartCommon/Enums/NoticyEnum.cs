using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCommon.Enums
{
    /// <summary>
    /// 消息通知的方式None = 0,Mail = 1
    /// </summary>
    public enum NoticyEnum
    {
        [Description("不发送")]
        None = 0,
        [Description("发送邮件")]
        Mail = 1
    }
}
