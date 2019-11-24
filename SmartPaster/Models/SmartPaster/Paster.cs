using SmartPaster.Models.SmartPaster;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartPaster.Models.SmartPaster
{
	/// <summary>
	/// いい感じに貼り付け処理を行うクラス
	/// クリップボードの内容が何であっても，デスクトップに貼り付けを行うことが目的
	/// </summary>
	internal class Paster
	{
		/// <summary>
		/// Clipboardに格納しているデータtypeを取得
		/// </summary>
		/// <returns>ClipDataType オブジェクト</returns>
		internal ClipDataType GetClipType()
		{
			if (Clipboard.ContainsText())
			{
				string cliptext = Clipboard.GetText();
				if (File.Exists(cliptext))
					return ClipDataType.File;
				else if (Directory.Exists(cliptext))
					return ClipDataType.Folder;
				else
					return ClipDataType.Text;
			}
			else if (Clipboard.ContainsImage())
				return ClipDataType.Image;
			else
				return ClipDataType.Other;
		}

		/// <summary>
		/// Clipboardからpaste処理が可能かを確認する
		/// </summary>
		/// <returns></returns>
		internal bool CanPaste()
		{
			return GetClipType().IsPasteType();
		}

		/// <summary>
		/// StreamWriterにClipboardの中身をいい感じに書き出す
		/// </summary>
		/// <param name="sw"></param>
		internal void ExportFile(Stream stream)
		{
			GetClipType().Export(stream);
		}

		/// <summary>
		/// 現在のクリップボードに合う拡張子を取得
		/// </summary>
		/// <returns></returns>
		internal string GetExt()
		{
			return GetClipType().GetExt();
		}
	}
}
