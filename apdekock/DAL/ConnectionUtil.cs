using System;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ConnectionUtil
    {
        public string GetConnectionString(int relPathDepth)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseEntitiesConnection"].ConnectionString;

            const string pathSeperator = "\\";

            var solutionPath = AppDomain.CurrentDomain.BaseDirectory
                .Split(new[] { pathSeperator }, StringSplitOptions.None)
                .TakeWhile(r => r != "bin").ToArray();

            var pathElements = solutionPath.Take(solutionPath.Length - relPathDepth).ToArray();

            var relPathBuilder = new StringBuilder();
            foreach (string folder in pathElements)
            {
                relPathBuilder.Append(folder);
                relPathBuilder.Append(pathSeperator);
            }
            relPathBuilder.Append(@"DAL\Database");

            return connectionString.Replace("|DataDirectory|", relPathBuilder.ToString());
        }
    }
}