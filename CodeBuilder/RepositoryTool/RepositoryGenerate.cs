#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 单位 运管家
// 版权所有。 
//
// 文件名：RepositoryGenerate
// 文件功能描述：
//
// 
// 创建者：名字 AESCR
// 时间：2021/5/10 16:51:57
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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuilder.Code.Generate;

namespace CodeBuilder.RepositoryTool
{
    /// <summary>
    /// 数据访问层生成器
    /// </summary>
    public class RepositoryGenerate: CodeGenerate
    {
        private DataTable _dbTable;
        public string RepositoryNamespace { get; set; } = "Aescr.IRepository";
        public RepositoryGenerate(DataTable dataTable)
        {
            _dbTable = dataTable;
        }
        private List<string> _modeList=new List<string>();
        private void GenerateDbIRepository()
        {
            for (int index = 0; index < _dbTable.Rows.Count;index++)
            {
                DataRow dataRow = _dbTable.Rows[index];
                if (string.IsNullOrWhiteSpace(dataRow["表名"].ToString())==false)
                {
                    var nt= CreateNamespace();
                    nt.NamespaceName = RepositoryNamespace;
                    var it= nt.CreateInterface();
                    var tableName = dataRow["表名"].ToString();
                    var tname = tableName.Replace("_", "");
                    it.InterfaceName= "I"+ tname + "Repository";

                    #region 添加

                    {
                        var mt = it.CreateMethod();
                        mt.Remark = "添加" + dataRow["表说明"].ToString()+"数据";
                        mt.MethodName = $"Add{tname}";
                        mt.ReturnName = "bool";
                        var addPt = mt.CreateParameter();
                        addPt.ParameterName = "model";
                        addPt.ParameterTypeName = $"Input{tname}";
                        addPt.Remark = $"添加{ dataRow["表说明"].ToString()}实体!";
                        _modeList.Add(addPt.ParameterTypeName);
                        addPt.Remark = dataRow["表说明"].ToString();
                    }
                    #endregion

                    #region 删除
                    {
                        var mt = it.CreateMethod();
                        mt.Remark = "通过Id删除" + dataRow["表说明"].ToString()+"数据";
                        mt.MethodName = $"Delete{tname}";
                        mt.ReturnName = "bool";
                        var addPt = mt.CreateParameter();
                        addPt.ParameterName = "id";
                        addPt.ParameterTypeName = "string";
                        addPt.Remark = dataRow["表说明"].ToString();
                    }
                    #endregion

                    #region 修改

                    {
                        var mt = it.CreateMethod();
                        mt.Remark = "通过修改" + dataRow["表说明"].ToString() + "数据";
                        mt.MethodName = $"Update{tname}";
                        mt.ReturnName = "bool";
                        var addPt = mt.CreateParameter();
                        addPt.ParameterName = "model";
                        addPt.ParameterTypeName = $"Edit{tname}";
                        addPt.Remark = $"编辑{ dataRow["表说明"].ToString()}实体!";
                        _modeList.Add(addPt.ParameterTypeName);
                        addPt.Remark = dataRow["表说明"].ToString();
                    }
                    #endregion

                    #region 查询

                    {
                        var mt = it.CreateMethod();
                        mt.Remark = "查询" + dataRow["表说明"].ToString() + "的数据";
                        mt.MethodName = $"SelectData";
                        var addPt = mt.CreateParameter();
                        addPt.ParameterName = "model";
                        addPt.ParameterTypeName = $"Select{tname}";
                        addPt.Remark = $"查询的{ dataRow["表说明"].ToString()}实体!";
                        mt.ReturnName = $"List<View{tname}>";
                        _modeList.Add(addPt.ParameterTypeName);
                        _modeList.Add($"View{tname}");
                        addPt.Remark = dataRow["表说明"].ToString();
                    }

                    #endregion
                }
            }
        }

        public new void Save()
        {
            GenerateDbIRepository();
            base.Save();
        }
    }
}
