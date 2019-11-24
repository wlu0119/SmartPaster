using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using SmartPaster.Models.SmartPaster;
using System.Drawing;
using System.IO;
using System.Text;

namespace TestSmartPaster.Models.SmartPaster
{
	/// <summary>
	/// SmartPasterのテストクラス
	/// </summary>
	[TestClass]
	public class TestSmartPaster
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
		/// データオブジェクトの種類がテキストのときに判定がテキストになること
		/// </summary>
		[TestMethod]
		public void TestGetClipType01()
		{
			Clipboard.SetText("hogetext");
			var target = new Paster();
			Assert.AreEqual(ClipDataType.Text, target.GetClipType());
		}

		/// <summary>
		/// データオブジェクトの種類が画像のときに判定が画像になること
		/// </summary>
		[TestMethod]
		public void TestGetClipType02()
		{
			Image bitmap = new Bitmap(100, 100);
			Clipboard.SetImage(bitmap);
			var target = new Paster();
			Assert.AreEqual(ClipDataType.Image, target.GetClipType());
		}

		/// <summary>
		/// データオブジェクトの種類がファイルのときに判定がファイルになること
		/// </summary>
		[TestMethod]
		[DeploymentItem(@"testdatas\TestSmartPaster\example_folder\TextFile1.txt", @"testdatas\TestSmartPaster\example_folder\")]
		public void TestGetClipType03()
		{
			Clipboard.SetText(@"testdatas\TestSmartPaster\example_folder\TextFile1.txt");
			var target = new Paster();
			Assert.AreEqual(ClipDataType.File, target.GetClipType());
		}

		/// <summary>
		/// データオブジェクトの種類がフォルダのときに判定がフォルダになること
		/// </summary>
		[TestMethod]
		[DeploymentItem(@"testdatas\TestSmartPaster\example_folder\TextFile1.txt", @"testdatas\TestSmartPaster\example_folder\")]
		public void TestGetClipType04()
		{
			Clipboard.SetText(@"testdatas\TestSmartPaster\example_folder\");
			var target = new Paster();
			Assert.AreEqual(ClipDataType.Folder, target.GetClipType());
		}

		/// <summary>
		/// クリップボードが取得可能か？
		/// 取得可能なときにTrue
		/// </summary>
		[TestMethod]
		public void TestGetStatus01()
		{
			Clipboard.SetText("hogetext");
			var target = new Paster();
			Assert.IsTrue(target.CanPaste());
		}

		/// <summary>
		/// クリップボードが取得可能か？
		/// 取得不可能なときにfalse
		/// </summary>
		[TestMethod]
		public void TestGetStatus02()
		{
			var target = new Paster();
			Assert.IsFalse(target.CanPaste());

		}

		/// <summary>
		/// 指定したストリームにクリップボードの内容が書き出されていること
		/// </summary>
		[TestMethod]
		public void TestExportFile01()
		{
			Clipboard.SetText("hogetext");

			MemoryStream ms = new MemoryStream();

			var target = new Paster();
			target.ExportFile(ms);

			Assert.AreEqual("hogetext", Encoding.ASCII.GetString(ms.ToArray()));
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

	}
}
