using Autofac;
using Images.ExifData;
using System;
using System.Linq;

namespace Images.Runner
{
	public class AutofacRegistrations : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ExifReader>().As<IExifReader>();
			builder.RegisterType<Runner>().As<IRunner>();
		}
	}
}
