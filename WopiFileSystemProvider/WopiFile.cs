﻿using System;
using System.IO;
using WopiHost.Contracts;

namespace WopiFileSystemProvider
{
	public class WopiFile : IWopiFile
	{
		public string Identifier { get; }

		protected FileInfo fileInfo;
		protected string FilePath { get; set; }

		protected FileInfo FileInfo
		{
			get { return fileInfo ?? (fileInfo = new FileInfo(FilePath)); }
		}
		public bool Exists
		{
			get
			{
				return FileInfo.Exists;
			}
		}

		public string Extension
		{
			get
			{
				var ext = FileInfo.Extension;
				if (ext.StartsWith("."))
				{
					ext = ext.Substring(1);
				}
				return ext;
			}
		}

		public long Length
		{
			get
			{
				return FileInfo.Length;
			}
		}

		public string Name
		{
			get { return FileInfo.Name; }
		}

		public DateTime LastWriteTimeUtc
		{
			get { return FileInfo.LastWriteTimeUtc; }
		}

		public WopiFile(string filePath, string fileIdentifier)
		{
			FilePath = filePath;
			Identifier = fileIdentifier;
		}

		public Stream GetReadStream()
		{
			return FileInfo.OpenRead();
		}

		public Stream GetWriteStream()
		{
			return FileInfo.Open(FileMode.Truncate);
		}
	}
}
