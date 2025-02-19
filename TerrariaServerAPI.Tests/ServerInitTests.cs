using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace TerrariaServerAPI.Tests
{
	[TestClass]
    public class ServerInitTests
	{
		[TestMethod]
		public void EnsureBoots()
		{
			var are = new AutoResetEvent(false);
			On.Terraria.Main.hook_DedServ cb = (On.Terraria.Main.orig_DedServ orig, Terraria.Main instance) =>
			{
				are.Set();
				Debug.WriteLine("Server startup successful");
			};
			On.Terraria.Main.DedServ += cb;

			new Thread(() => TerrariaApi.Server.Program.Main(new string[] { })).Start();

			var hit = are.WaitOne(TimeSpan.FromSeconds(30));

			On.Terraria.Main.DedServ -= cb;

			Assert.AreEqual(true, hit);
		}
	}
}
