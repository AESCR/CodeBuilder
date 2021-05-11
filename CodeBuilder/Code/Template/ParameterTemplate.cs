#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 单位 运管家
// 版权所有。 
//
// 文件名：ParameterTemplate
// 文件功能描述：
//
// 
// 创建者：名字 AESCR
// 时间：2021/5/8 17:00:32
//
// 修改人：
// 时间：
// 修改说明：
//
// 修改人：
// 时间：
// 修改说明：
//
// 版本：V1.0.0
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 参数模板
    /// </summary>
    [Serializable]
    public class ParameterTemplate
    {
        /// <summary>
        /// 参数类型
        /// </summary>
        public string ParameterTypeName { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 参数注释
        /// </summary>
        public string Remark { get; set; }
    }
}
