using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class AssemblyHandler
    {
        #region Assembly Initialize
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            context.WriteLine("Assembly Init");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {

        }
        #endregion
    }
}
