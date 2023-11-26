// See https://aka.ms/new-console-template for more information

using Autofac;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Images.Runner;

var connectionString = "XpoProvider=MSSqlServer;data source=WIN11-DEV;integrated security=SSPI;initial catalog=ImageCatalog;TrustServerCertificate=True";
XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly);

XpoDefault.Session = null;

var builder = new ContainerBuilder();
builder.RegisterModule<AutofacRegistrations>();

using var scope = builder.Build().BeginLifetimeScope();
var runner = scope.Resolve<IRunner>();

await runner.RunAsync();