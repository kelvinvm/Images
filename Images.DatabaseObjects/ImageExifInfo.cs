using DevExpress.Xpo;
using System;
using System.Drawing;
using System.Linq;

namespace Images.ExifData
{
	public class ImageExifInfo : XPObject
	{
		private int originalWidth;
		private int originalHeight;
		private int currentWidth;
		private int currentHeigth;
		private byte[] propertyName = new byte[0];
		private string exposureBias = string.Empty;
		private string aperture = string.Empty;
		private string shutterSpeed = string.Empty;
		private DateTime shotDate;
		private int iso;
		private string exposure = string.Empty;
		private string cameraModel = string.Empty;
		private string cameraMake = string.Empty;
		private string fileType = string.Empty;
		private string fileName = string.Empty;

		[Size(63)]
		public string FileName
		{
			get => fileName;
			set => SetPropertyValue(nameof(FileName), ref fileName, value);
		}

		[Size(10)]
		public string FileType
		{
			get => fileType;
			set => SetPropertyValue(nameof(FileType), ref fileType, value);
		}

		public int CurrentHeight
		{
			get => currentHeigth;
			set => SetPropertyValue(nameof(CurrentHeight), ref currentHeigth, value);
		}

		public int CurrentWidth
		{
			get => currentWidth;
			set => SetPropertyValue(nameof(CurrentWidth), ref currentWidth, value);
		}

		public int OriginalHeight
		{
			get => originalHeight;
			set => SetPropertyValue(nameof(OriginalHeight), ref originalHeight, value);
		}
		
		public int OriginalWidth
		{
			get => originalWidth;
			set => SetPropertyValue(nameof(OriginalWidth), ref originalWidth, value);
		}

		[Size(63)]
		public string CameraMake
		{
			get => cameraMake;
			set => SetPropertyValue(nameof(CameraMake), ref cameraMake, value);
		}

		[Size(63)]
		public string CameraModel
		{
			get => cameraModel;
			set => SetPropertyValue(nameof(CameraModel), ref cameraModel, value);
		}

		[Size(15)]
		public string Exposure
		{
			get => exposure;
			set => SetPropertyValue(nameof(Exposure), ref exposure, value);
		}

		public int Iso
		{
			get => iso;
			set => SetPropertyValue(nameof(Iso), ref iso, value);
		}

		public DateTime ShotDate
		{
			get => shotDate;
			set => SetPropertyValue(nameof(ShotDate), ref shotDate, value);
		}

		[Size(10)]
		public string ShutterSpeed
		{
			get => shutterSpeed;
			set => SetPropertyValue(nameof(ShutterSpeed), ref shutterSpeed, value);
		}

		[Size(20)]
		public string Aperture
		{
			get => aperture;
			set => SetPropertyValue(nameof(Aperture), ref aperture, value);
		}

		[Size(20)]
		public string ExposureBias
		{
			get => exposureBias;
			set => SetPropertyValue(nameof(ExposureBias), ref exposureBias, value);
		}

		public byte[] Image
		{
			get => propertyName;
			set => SetPropertyValue(nameof(Image), ref propertyName, value);
		}

		public ImageExifInfo(Session session) : base(session)
		{
		}
	}

	//public class ImageExifInfo : XPObject
	//{
	//	[Key(AutoGenerate = true)]
	//	public int ExposureBG { get; set; }
	//	[Size(63)]
	//	public string FileName { get; set; }
	//	[Size(10)]
	//	public string FileType { get; set; }        // File Type Directory: TagType 1 (Description)
	//	public Point CurrentSize { get; set; }      // JPEG Directory:		TagType 3 (Width),	TagType 1 (Height), 
	//	public Point OriginalSize { get; set; }     // Exif IFD0 Directory: TagType 256 (Width), TagType 257 (Height)

	//	[Size(63)]
	//	public string CameraMake { get; set; }      // Exif IFD0 Directory:	TagType 271 (Make)
	//	[Size(63)]
	//	public string CameraModel { get; set; }     // Exif IFD0 Directory: TagType 272 (Model) 

	//	[Size(10)]
	//	public string Exposure { get; set; }		// Exif SubIFD:			TagType 33434
	//	public int Iso { get; set; }                //						TagType 34855
	//	public DateTime ShotDate { get; set; }      //						TagType 36867
	//	[Size(20)]
	//	public string ShutterSpeed { get; set; }    //						TagType 37377
	//	[Size(20)]
	//	public string Aperture { get; set; }        //						TagType 37378
	//	[Size(20)]
	//	public string ExposureBias { get; set; }    //						TagType 37380

	//	public ImageExifInfo(Session session) : base(session)
	//	{
	//	}


	//}
}
