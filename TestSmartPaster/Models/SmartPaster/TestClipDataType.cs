using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPaster.Models.SmartPaster;
using System.Windows.Forms;
using System.Drawing;

namespace TestSmartPaster.Models.SmartPaster
{
	/// <summary>
	/// ClipDataTypeのテスト
	/// </summary>
	[TestClass]
	public class TestClipDataType
	{
		/// <summary>
		/// テスト実行前にclipboardのクリア
		/// </summary>
		[TestInitialize]
		public void initialize()
		{
			Clipboard.Clear();
		}

		/// <summary>
		/// テストクラス終了前にclipboardのクリア
		/// </summary>
		[ClassCleanup]
		public static void end()
		{
			Clipboard.Clear();
		}

		/// <summary>
		/// Text形式のときにtxtが取得できること
		/// </summary>
		[TestMethod]
		public void TestExportExt01()
		{
			Clipboard.SetText("hogetext");
			Assert.AreEqual("txt", ClipDataType.Text.GetExt());
		}
		/// <summary>
		/// cammaSeparatedValue形式のときにcsvが取得できること
		/// </summary>
		[TestMethod]
		[Ignore]
		public void TestExportExt02()
		{
			Clipboard.SetText("aaa,bbb,ccc\r\n123,456,789\r\n");
			Assert.AreEqual("csv", ClipDataType.Text.GetExt());
		}
		/// <summary>
		/// Image形式のときにbmpが取得できること
		/// </summary>
		[TestMethod]
		public void TestExportExt03()
		{
			Image bitmap = new Bitmap(100, 100);
			Clipboard.SetImage(bitmap);
			Assert.AreEqual("bmp", ClipDataType.Image.GetExt());
		}
	}
}
