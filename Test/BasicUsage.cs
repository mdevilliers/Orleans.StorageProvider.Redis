using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans;
using Orleans.Runtime.Host;
using Test.Interfaces;

namespace Test
{
    [TestClass]
    public class BasicUsage
    {
        [TestMethod]
        public async Task BasicSmokeTest()
        {
            var guid = Guid.NewGuid();
            var grain = PersonFactory.GetGrain(guid);
            await grain.SetName("John", "Smith");
                
            var result = await grain.SayHello();
            Assert.AreEqual(result, "Hello from John Smith - again (1)");

            var grain2 = PersonFactory.GetGrain(guid);
            var result2 = await grain2.SayHello();
            Assert.AreEqual(result2, "Hello from John Smith - again (2)");
        }



        static SiloHost siloHost;
        static AppDomain hostDomain;

        static void InitSilo(string[] args)
        {
            siloHost = new SiloHost("Primary");
            siloHost.ConfigFileName = "DevTestServerConfiguration.xml";
            siloHost.DeploymentId = "1";
            siloHost.InitializeOrleansSilo();
            var ok = siloHost.StartOrleansSilo();
            if (!ok) throw new SystemException(string.Format("Failed to start Orleans silo '{0}' as a {1} node.", siloHost.Name, siloHost.Type));
        }

        [ClassInitialize]
        public static void GrainTestsClassInitialize(TestContext testContext)
        {

            hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
            });

            GrainClient.Initialize("DevTestClientConfiguration.xml");
        }

        [ClassCleanup]
        public static void GrainTestsClassCleanUp()
        {
            hostDomain.DoCallBack(() =>
            {
                siloHost.Dispose();
                siloHost = null;
                AppDomain.Unload(hostDomain);
            });
            var startInfo = new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = "/F /IM vstest.executionengine.x86.exe",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            Process.Start(startInfo);
        }
    }
}
