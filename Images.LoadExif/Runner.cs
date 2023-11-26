using DevExpress.Data.Filtering.Helpers;
using DevExpress.Xpo;
using Images.ExifData;
using Images.ExifData.Dto;
using System;
using System.Linq;

namespace Images.Runner
{
	public class Runner : IRunner
	{
		private readonly IExifReader _exifReader;

		public Runner(IExifReader exifReader)
		{
			_exifReader = exifReader ?? throw new ArgumentNullException(nameof(exifReader));
		}

		public async Task RunAsync()
		{
			var exifDtos = _exifReader.ReadExifData(@"C:\Dev\ImageLibrary");

			using var uow = new UnitOfWork();

			// Get the existing records
			var imageData = await uow.Query<ImageExifInfo>().ToListAsync();

			// Add new records
			foreach (var dto in exifDtos)
			{
				var existingExif = imageData.FirstOrDefault(exif => exif.FileName.Equals(dto.FileName, StringComparison.InvariantCultureIgnoreCase));
				if (existingExif == null) 
					CreateExifInfoInUow(uow, dto);
			}

			// Commit changes
			await uow.CommitChangesAsync();
		}

		private void CreateExifInfoInUow(UnitOfWork uow, ImageExifInfoDto dto)
		{
			// The object just needs to be added to the unit of work to be tracked and saved.
			new ImageExifInfo(uow)
			{
				FileName = dto.FileName,
				FileType = dto.FileType,
				CurrentHeight = dto.CurrentSize.Y,
				CurrentWidth = dto.CurrentSize.X,
				OriginalHeight = dto.OriginalSize.Y,
				OriginalWidth = dto.OriginalSize.X,
				CameraMake = dto.CameraMake,
				CameraModel = dto.CameraModel,
				Exposure = dto.Exposure,
				Iso = dto.Iso,
				ShotDate = dto.ShotDate,
				ShutterSpeed = dto.ShutterSpeed,
				Aperture = dto.Aperture,
				ExposureBias = dto.ExposureBias,
				Image = dto.Image
			};
		}
	}
}
