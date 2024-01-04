using NUnit.Framework;
using PicoSystems.Infrastructure;

namespace NUntitTest.Xml
{
    [TestFixture]
    public class CheckPathTests
    {
        [Test]
        public void CheckXmlPathTest_True()
        {
            var pathBindBidSubmittalIMGP = PicoSystemsSettings.pathBindBidSubmittalIMGP;
            Assert.That(File.Exists(pathBindBidSubmittalIMGP));
            var pathBindNotification = PicoSystemsSettings.pathBindNotification;
            Assert.That(File.Exists(pathBindNotification));
        }
    }
}
