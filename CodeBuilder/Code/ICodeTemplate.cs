namespace CodeBuilder.Code
{
    public interface ICodeTemplate
    {
        ICodeTemplate ImportNamespace(params string[] names);
        void Save(string path);
        ICodeTemplate SetClass(string className, string comment, bool isInterface = false, params string[] inheritors);
        ICodeTemplate SetClass(string nSpace, string className, string comment, params string[] inheritors);
        ICodeTemplate SetInterfaceMethod(string methodName, string returnType, params string[] parameterTypes);
        ICodeTemplate SetNamespace(string name);
        ICodeTemplate SetProperty(string typeName, string propertyName, string comment = "");
    }
}