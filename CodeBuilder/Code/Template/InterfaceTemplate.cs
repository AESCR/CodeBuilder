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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    [Serializable]
    public class InterfaceTemplate
    { 
        /// <summary>
        /// 备注
        /// </summary>
        public CommentTemplate Comment { get; set; }
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
                if (Methods!=null)
                {
                    m.AddRange(@interface.Methods);
                }
                if (@interface.BaseInterface == null) return;
                foreach (InterfaceTemplate interfaceTemplate in @interface.BaseInterface)
                {
                    FindBaseMethods(interfaceTemplate);
                }
            }
        
        }

        public MethodTemplate CreateMethod()
        {
            if (Methods==null)
            {
                Methods=new List<MethodTemplate>();
            }
            MethodTemplate methodTemplate = new MethodTemplate {IsInterface = true};
            Methods.Add(methodTemplate);
            return methodTemplate;
        }
        public string Generate()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                //设置注释
                if (string.IsNullOrWhiteSpace(Comment?.CommentName) == false)
                {
                    stringWriter.Write(Comment.Generate());
                }
                stringWriter.Write($"public interface {InterfaceName}");
                if (BaseInterface!=null&&BaseInterface.Count>0)
                {
                    stringWriter.Write(":");
                    foreach (var @interface in BaseInterface)
                    {
                        stringWriter.Write($",{@interface.InterfaceName}");
                    }
                }
                stringWriter.WriteLine();
                stringWriter.WriteLine("{");
                //方法
                foreach (MethodTemplate method in Methods)
                {
                    using (StringReader stringReader = new StringReader(method.Generate()))
                    {
                        while (stringReader.Peek() != -1)
                        {
                            stringWriter.WriteLine("\t" + stringReader.ReadLine());
                        }
                    }
                }
                stringWriter.WriteLine("}");
                return stringWriter.ToString();
            }
        }
    }
}
