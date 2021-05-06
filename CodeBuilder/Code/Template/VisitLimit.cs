using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 访问限制
    /// </summary>
    public enum VisitLimit
    {
        [Description("public")] Public,
        [Description("protected")] Protected,
        [Description("private")] Private
    }
}
