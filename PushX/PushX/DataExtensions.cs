namespace PushX
{
    public static class DataExtensions
    {
        private static System.Web.Script.Serialization.JavaScriptSerializer serialz = null;

        /// <summary>
        /// Converts data to json string
        /// </summary>
        /// <param name="data">represents data</param>
        /// <returns></returns>
        public static string ToJson(this object data)
        {
            if (serialz == null)
            {
                serialz = new System.Web.Script.Serialization.JavaScriptSerializer();
            }

            return serialz.Serialize(data);
        }
    }
}
