using System;
using MetadataExtractor;
using System.Diagnostics;
using Images.ExifData.Dto;

namespace Images.ExifData
{
	public class ExifReader : IExifReader
	{
		public IEnumerable<ImageExifInfoDto> ReadExifData(string directory)
		{
			Stopwatch sw = Stopwatch.StartNew();

			var results = new List<ImageExifInfoDto>();
			IEnumerable<string> files = System.IO.Directory.EnumerateFiles(directory);

			foreach (var file in files)
				results.Add(GetExifInfo(file, ImageMetadataReader.ReadMetadata(file)));

			sw.Stop();
			Debug.WriteLine($"Total Time: {sw.ElapsedMilliseconds} ms");

			return results;
		}

		private ImageExifInfoDto GetExifInfo(string fileName, IReadOnlyList<MetadataExtractor.Directory> directories)
		{
			return new ImageExifInfoDto
			(
				FileName: Path.GetFileName(fileName),
				FileType: directories.FileType(),
				CurrentSize: directories.CurrentSize(),
				OriginalSize: directories.OriginalSize(),
				CameraMake: directories.CameraMake(),
				CameraModel: directories.CameraModel(),
				Exposure: directories.Exposure(),
				Iso: directories.Iso(),
				ShotDate: directories.ShotDate(),
				ShutterSpeed: directories.ShutterSpeed(),
				Aperture: directories.Aperture(),
				ExposureBias: directories.ExposureBias(),
				Image: File.ReadAllBytes(fileName)
			);
		}
	}
}
