using System;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using NUnit.Framework;
using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
using TestMethodAttribute = NUnit.Framework.TestAttribute;
#endif

namespace CLanguage.Tests
{
	public class ArduinoTestMachineInfo : ArduinoMachineInfo
	{
		public ArduinoTestMachineInfo ()
		{
			InternalFunctions.Add (new InternalFunction ("void assertAreEqual (int expected, int actual)", AssertAreEqual));
		}

		static void AssertAreEqual (ExecutionState state)
		{
			var expected = state.ActiveFrame.Args[0];
			var actual = state.ActiveFrame.Args[1];
			Assert.That (actual, Is.EqualTo (expected));
		}
	}
}

