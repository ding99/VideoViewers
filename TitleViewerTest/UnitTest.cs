
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TitleViewer;

namespace TitleViewerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ContentTest()
        {
            string title_test = "TITLE001";
            string bulletText_test = "BULLETTEXT001";
            string description_test = "DESCRIPTION001";
            string id_test = "ID001";
            int runningTime_test = 1001;

            Content content = new Content(title_test, bulletText_test, description_test, id_test, runningTime_test);

            Assert.AreEqual(title_test, content.title);
            Assert.AreEqual(bulletText_test, content.bulletText);
            Assert.AreEqual(description_test, content.description);
            Assert.AreEqual(id_test, content.id);
            Assert.AreEqual(runningTime_test, content.runningTime);
        }
    }
}
