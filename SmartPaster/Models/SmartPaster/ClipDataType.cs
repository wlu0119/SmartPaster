using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPaster.Models.SmartPaster
{
	/// <summary>
	/// SmartPasterが取扱うデータタイプ
	/// Text形式ではさらにTextDataFormatにわかれる
	/// </summary>
	/// <see cref="https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.forms.textdataformat?view=netframework-4.7.2"/>
	internal enum ClipDataType
	{
		Image,
		Text,
		File,
		Folder,
		Other
	}

	/// <summary>
	/// ClipDataTypeの拡張メソッド
	/// </summary>
	internal static class ClipDataTypeExtensions
	{
		/// <summary>
		/// クリップボードの情報の形式
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		internal static bool IsPasteType(this ClipDataType type)
		{
			if (type == ClipDataType.Text)
				return true;
			else if (type == ClipDataType.Image)
				return true;
			else if (type == ClipDataType.Folder)
				return true;
			else if (type == ClipDataType.File)
				return true;
			else if (type == ClipDataType.Other)
				return false;
			else
				return false;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="type"></param>
		/// <param name="stream"></param>
		internal static void Export(this ClipDataType type, Stream stream)
		{
			if (stream == null)
				return;
			if (type == ClipDataType.Text)
			{
				using (StreamWriter sw = new StreamWriter(stream))
				{
					if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
					{
						sw.Write(Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
					}
					else
					{
						sw.Write(Clipboard.GetText(TextDataFormat.Text));
					}
				}

			}

			else if (type == ClipDataType.Image)
			{
				Image bmp = Clipboard.GetImage();
				bmp.Save(stream, ImageFormat.Bmp);
			}

			else if (type == ClipDataType.Folder)
				throw new NotSupportedException("未対応のファイル形式がクリップボードに含まれています．");
			else if (type == ClipDataType.File)
				throw new NotSupportedException("未知のフォルダ形式がクリップボードに含まれています．");
			else if (type == ClipDataType.Other)
				throw new NotSupportedException("未知の形式がクリップボードに含まれています．");
			else
				throw new NotSupportedException("未知の形式がクリップボードに含まれています．");
		}

		/// <summary>
		/// 拡張子の取得
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		internal static string GetExt(this ClipDataType type)
		{
			if (type == ClipDataType.Text)
			{
				if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
				{
					return "csv";
				}
				else
					return "txt";
			}

			else if (type == ClipDataType.Image)
			{
				return "bmp";
			}

			else if (type == ClipDataType.Folder)
				throw new NotSupportedException("未対応のファイル形式がクリップボードに含まれています．");
			else if (type == ClipDataType.File)
				throw new NotSupportedException("未知のフォルダ形式がクリップボードに含まれています．");
			else if (type == ClipDataType.Other)
				throw new NotSupportedException("未知の形式がクリップボードに含まれています．");
			else
				throw new NotSupportedException("未知の形式がクリップボードに含まれています．");
		}
	}
}
