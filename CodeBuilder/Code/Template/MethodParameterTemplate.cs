﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 方法测试模板
    /// </summary>
    public class MethodParameterTemplate
    {
        /// <summary>
        /// 是泛型
        /// </summary>
        public bool IsGenerics { get; set; } = false;
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