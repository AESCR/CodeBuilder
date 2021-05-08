#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 单位 运管家
// 版权所有。 
//
// 文件名：InterfaceTemplate
// 文件功能描述：
//
// 
// 创建者：名字 AESCR
// 时间：2021/5/8 17:09:50
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
    public class InterfaceTemplate
    {
        /// <summary>
        /// 接口名称
        /// </summary>
        public string InterfaceName { get; set; }
        /// <summary>
        /// 父类接口
        /// </summary>
        public List<InterfaceTemplate> BaseInterface { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public List<MethodTemplate> Methods { get; set; }

        /// <summary>
        /// 获取全部方法 包含上上级接口方法
        /// </summary>
        public List<MethodTemplate> GetAllMethods()
        {
            List<MethodTemplate> m=new List<MethodTemplate>();
            FindBaseMethods(this);
            return m;
            void FindBaseMethods(InterfaceTemplate @interface)
            {
                m.AddRange(Methods);
                if (@interface.BaseInterface == null) return;
                foreach (InterfaceTemplate interfaceTemplate in @interface.BaseInterface)
                {
                    m.AddRange(interfaceTemplate.Methods);
                    FindBaseMethods(interfaceTemplate);
                }
            }
        
        }
    }
}
