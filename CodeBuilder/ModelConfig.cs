namespace CodeBuilder
{
    public class ModelConfig
    {
        private string _setNamespace;
        private string _savePath;
        public string DataAddress { get; set; }
        public string DataAccount { get; set; }
        public string DataPassword { get; set; }

        public string SavePath
        {
            get
            {
                if (string.IsNullOrEmpty(_savePath))
                {
                    return "";
                }

                return _savePath;
            }
            set => _savePath = value;
        }

        public string Namespace
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_setNamespace))
                {
                    return "AESCR.Model";
                }
                return _setNamespace;
            }
            set => _setNamespace = value;
        }
    }
}