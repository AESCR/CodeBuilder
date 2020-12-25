using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.CSharpCode
{
    public class ClassGenerate
    {
        public ClassGenerate()
        {
            _cSharp.ImportNamespace.Add("System");
            _cSharp.ImportNamespace.Add("System.Linq");
            _cSharp.ImportNamespace.Add("System.Text");
            _cSharp.ImportNamespace.Add("System.Threading.Tasks");
            _cSharp.ImportNamespace.Add("System.Collections.Generic");
        }
        private readonly CodeTemplate _cSharp=new CodeTemplate();
        public ClassGenerate SetNamespace(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            _cSharp.NamespaceName = name;
            return this;
        }

        public ClassGenerate UsingNamespace(params string[] names)
        {
            var r= names.ToList();
            _cSharp.ImportNamespace.AddRange(r);
            _cSharp.ImportNamespace = _cSharp.ImportNamespace.Distinct().ToList();
            return this;
        }
        public ClassGenerate SetComment(string name)
        {
            _cSharp.Comment=new CommentTemplate();
            _cSharp.Comment.CommentName = name;
            _cSharp.Comment.ParameterComment=new List<string>();
            _cSharp.Comment.ReturnComment = null;
            return this;
        }
        public ClassGenerate SetBase(params CodeTemplate[] baseCode)
        {
            _cSharp.BaseTemplate.AddRange(baseCode);
            return this;
        }
        public ClassGenerate SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            _cSharp.ClassName = name;
            return this;
        }

        public MethodGenerate CreateMethod()
        {
            var m = new MethodGenerate();
            return m;
        }
        public ClassGenerate AddMethods(MethodGenerate method)
        {
            _cSharp.Methods.Add(method.Generate());
            return this;
        }
        /// <summary>
        /// 生成一个代码模板
        /// </summary>
        public CodeTemplate Generate()
        {
            return _cSharp;
        }
    }

    public class MethodGenerate
    {
        private MethodTemplate method=new MethodTemplate();
        public MethodTemplate Generate()
        {
            return method;
        }

        public MethodGenerate SetName(string name,string @return= "void")
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            method.MethodName = name;
            method.ReturnType = @return;
            return this;
        }

        public MethodGenerate SetComment(string @comment, string @return="")
        {
            if (method.Comment == null)
            {
                this.method.Comment = new CommentTemplate();
            }
            method.Comment.CommentName = @comment;
            if (method.ReturnType!= "void")
            {
                this.method.Comment.ReturnComment = @return;
            }
            else
            {
                method.Comment.ReturnComment = null;
            }
            return this;
        }

        public MethodGenerate SetParameterComment(List<string> parameters)
        {
            if (method.Comment==null)
            {
                this.method.Comment = new CommentTemplate();
            }
            method.Comment.ParameterComment.AddRange(parameters);
            return this;
        }
    }
}
