

namespace CodeBuilder.DbTool
{
    public class DbConnect
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public string GetConnection(DataBaseType dbType)
        {
            switch (dbType)
            {
                case DataBaseType.MsSQL:
                    return
                        $"Data Source = {Ip.Trim()},{Port}; User ID = {Account }; Password = { Password}";
                case DataBaseType.MySQL:
                    return $"Server={Ip.Trim()};Port={Port};Uid={Account};Pwd={Password}";
                default:
                    return
                        $"Data Source = {Ip.Trim()},{Port}; User ID = {Account }; Password = { Password}";
            }
        }
    }
}
