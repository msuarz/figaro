using System.Diagnostics;
using fit;

namespace Figaro {

    public class DebugFixture : Fixture {

        public DebugFixture() { Debugger.Launch(); }
    }
}