using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DbProviders;
using DataAccess.Layout.Builder;
using Framework.ConfigData;
using Framework.ConfigData.Connection;
using Framework.Data;
using Framework.Database;
using Framework.Document;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestServer.Middlewares;
using Runtime.Persisters;
using Runtime.Runtime.Pipeline;
using Runtime.Server;

namespace RestServer
{
    public class Startup
    {
        public static RuntimeServerBootstrap Bootstrap { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Bootstrap = new RuntimeServerBootstrap();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(typeof(ApiConfigurationPersister));
            //TestDelimited();
            TestQuery();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(CustomEndpointMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void TestDelimited()
        {
            DelimitedLayoutBuilder builder = new DelimitedLayoutBuilder(new FileLayoutBuilderOptions() { FilePath = @"D:\chinook.track.csv" });

            builder.Build();

            var source = new DelimitedSourceConfigData() { FilePath = @"D:\chinook.track.csv", Layout = builder.Layout };

            var destination = new DelimitedDestinationConfigData() { Layout = builder.Layout, FilePath = @"D:\chinook.track_dest.csv" };

            source.Next = destination;

            var document = new DataflowDocument() { Source = source };

            var executer = new FlowExecuter();
            executer.Execute(document);
        }

        private void TestQuery()
        {
            var credentials = new Credentials() { Password = "Astera123", Username = "sa" };
            var connectionConfig = new SqlServerConnectionConfig() { Credentials = credentials, DatabaseName = "Chinook", ServerName = "ASTWKS246" };
            var sqlServer = DataAccess.DbProviders.DbProviderFactory.Create(DbProviderType.SqlServer);
            MetaFlatObject layout;
            using (var connection = new SqlConnection() { ConnectionString = connectionConfig.BuildConnectionString() })
            {
                connection.Open();
                layout = sqlServer.BuildLayout("Track", connection);
            }


            var dbSourceConfig = new DbSourceConfigSqlServer() { ConnectionConfig = connectionConfig, Layout = layout , TableConfig   = new DbTableConfig() { TableName = "Track"} };

            var destination = new DelimitedDestinationConfigData() { Layout = layout, FilePath = @"D:\chinook_track.csv" };
            dbSourceConfig.Next = destination;

            var document = new DataflowDocument() { Source = dbSourceConfig };
            var executer = new FlowExecuter();
            executer.Execute(document);

        }
    }
}
