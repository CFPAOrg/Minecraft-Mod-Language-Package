using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spider.Tests
{
    public class UtilsTests
    {
        [Theory]
        [InlineData("2724357", "SkyFactory4-4.0.8.zip", "https://edge.forgecdn.net/files/2724/357/SkyFactory4-4.0.8.zip")]
        public static void JoinDownloadUrlTest(string fileId,string fileName,string expected)
        {
            Assert.Equal(expected,Utils.JoinDownloadUrl(fileId,fileName));
        }
    }
}
