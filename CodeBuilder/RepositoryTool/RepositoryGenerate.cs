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
using CodeBuilder.Code.Template;
using CodeBuilder.DbTool;

namespace CodeBuilder.RepositoryTool
{
    /// <summary>
    /// 数据访问层生成器
    /// </summary>
    public class RepositoryGenerate: CodeGenerate
    {
        private readonly DataTable _dbTable;
        private readonly DbGenerate _dbGenerate;
        public string RepositoryNamespace { get; set; } = "Aescr.IRepository";
        public RepositoryGenerate(DbGenerate dbGenerate)
        {
            _dbGenerate = dbGenerate;
            _dbTable= _dbGenerate.GetTableFlat();
        }
        private readonly List<string> _modeList=new List<string>();
        private void GenerateDbIRepository()
        {
            for (int index = 0; index < _dbTable.Rows.Count;index++)
            {
                DataRow dataRow = _dbTable.Rows[index];
                if (string.IsNullOrWhiteSpace(dataRow["表名"].ToString())==false)
                {
                    var ft= CreateFile();
                    ft.DownloadPath=DownloadPath + "/IRepository";
                    var nt= ft.CreateNamespace();
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

        private void GenerateDbRepository()
        {
            for (int index = 0; index < _dbTable.Rows.Count; index++)
            {
                DataRow dataRow = _dbTable.Rows[index];
                if (string.IsNullOrWhiteSpace(dataRow["表名"].ToString()) == false)
                {
                    var ft = CreateFile();
                    ft.DownloadPath = DownloadPath + "/Repository";
                    var nt = ft.CreateNamespace();
                    nt.NamespaceName = RepositoryNamespace;
                    var ct = nt.CreateClass();
                    var tableName = dataRow["表名"].ToString();
                    var tname = tableName.Replace("_", "");
                    ct.ClassName = tname + "Repository";
                    ct.BaseClass = new ClassTemplate {ClassName = "EfRepository"};
                    var it= ct.CreateInterface();
                    it.InterfaceName = "I" + tname + "Repository";
                    #region 添加
                    {
                        var mt = ct.CreateMethod();
                        mt.Remark = "添加" + dataRow["表说明"].ToString() + "数据";
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
                        var mt = ct.CreateMethod();
                        mt.Remark = "通过Id删除" + dataRow["表说明"].ToString() + "数据";
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
                        var mt = ct.CreateMethod();
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
                        var mt = ct.CreateMethod();
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

        private void GenerateDbInputModel()
        {
            var dt = _dbTable;
            var nameText = RepositoryNamespace ?? "Aescr.Model";
            for (int index = 0; index < dt.Rows.Count;)
            {
                DataRow dataRow = dt.Rows[index];
                var inputFile = CreateFile();
                inputFile.DownloadPath = DownloadPath + "/InputModel";
                var viewFile = CreateFile();
                viewFile.DownloadPath = DownloadPath + "/ViewModel";
                var updateFile = CreateFile();
                updateFile.DownloadPath = DownloadPath + "/InputModel";
                var namespaceTemplate = inputFile.CreateNamespace();
                namespaceTemplate.NamespaceName = nameText;
                var viewTemplate= namespaceTemplate.DeepClone();
                viewFile.AddNamespace(viewTemplate);
                var updateTemplate = namespaceTemplate.DeepClone();
                updateFile.AddNamespace(updateTemplate);
                ClassTemplate classTemplate = new ClassTemplate();
                classTemplate.ClassName = dataRow["表名"].ToString();
                classTemplate.ClassName = classTemplate.ClassName.Replace("_", "");
                classTemplate.RealName = dataRow["表名"].ToString();
                classTemplate.Comment = new Code.Template.CommentTemplate();
                classTemplate.Comment.CommentName = dataRow["表说明"].ToString();
                do
                {
                    DataRow tempRow = dt.Rows[index];
                    var field = new Code.Template.FieldTemplate();
                    var comment = new Code.Template.CommentTemplate();
                    field.FieldName = tempRow["字段名"].ToString();
                    comment.CommentName = tempRow["字段说明"].ToString();
                    field.DbType = tempRow["类型"].ToString();
                    field.MaxLength = tempRow["长度"].ToString().ToInt64();
                    field.MinLength = 0;
                    field.Comment = comment;
                    field.IsProperty = true;
                    field.IsKey = tempRow["主键"].ToString() == "√";
                    field.CanNull = tempRow["允许空"].ToString() == "√";
                    if (_dbGenerate.DbType == DataBaseType.MsSQL)
                    {
                        field.FieldTypeName = DbToCsharpType.MsSqlToCsharpType(tempRow["类型"].ToString());
                    }
                    else if (_dbGenerate.DbType == DataBaseType.MySQL)
                    {
                        field.FieldTypeName = DbToCsharpType.MySqlToCsharpType(tempRow["类型"].ToString());
                    }

                    if (field.CanNull==false)
                    {
                        classTemplate.AddField(field);
                        var inputClass= classTemplate.DeepClone();
                        var viewClass = classTemplate.DeepClone();
                        var updateClass = classTemplate.DeepClone();
                        inputClass.ClassName = "Input" + inputClass.ClassName;
                        namespaceTemplate.AddClass(inputClass);
                        viewClass.ClassName = "View" + viewClass.ClassName;
                        viewTemplate.AddClass(viewClass);
                        updateClass.ClassName = "Update" + updateClass.ClassName;
                        updateTemplate.AddClass(updateClass);
                    }
                    index++;
                    if (index == dt.Rows.Count)
                    {
                        break;
                    }
                } while (string.IsNullOrWhiteSpace(dt.Rows[index]["表名"].ToString()));
            }
        }
        public new void Save()
        {
            GenerateDbIRepository();
            GenerateDbRepository();
            GenerateDbInputModel();
            base.Save();
        }
    }
}
