using Images.ExifData.Dto;

namespace Images.ExifData
{
	public interface IExifReader
	{
		IEnumerable<ImageExifInfoDto> ReadExifData(string directory);
	}
}
