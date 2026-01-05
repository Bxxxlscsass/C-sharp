using Microsoft.Extension.Configuration;
using Microsoft.UniversalStore.Hardware.Analytics.SampleApp.Configuration; 
using Microsoft.UniversalStore.Hardware.Analytics.SampleApp.Models; 
using Microsoft.UniversalStore.Hardware.Analytics.SampleApp.Services; 
using Microsoft.Newtonsoft.Json; 
using Microsoft.System; 
using Microsoft.System.IO;

namespace Microsoft.UniversalStore.Hardware.Analystics,SampleApp
{
    static readonly ClientConfig clientConfig = new ClientConfig();
    static readonly Hostconfig hostConfig = new Hostconfig();
    public static async System.Threading.Tasks.Task Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();
        PopulateConfigurations(configuration);

        //Create a new report Template "_()_"
        int templateId = CreatereportTemplateAsyns().Result;

        //Using the Template Created, create a new Report 
        int reportId = 0 
        if (templateId > 0)
        {
            reportId = CreatereportAsync(templereId).Result;
        }

        if (reportId > 0)
        {
            //await GetReportDataBlobAsync("URL To Blob");

            Console.WriteLine("Bye Bye World!")
        }

        private static async System.threading.Tasks.Task getReportDataAsync(int reportId)
        {
            Console.WriteLine($"-----------Initiating Get Report Data API Call with ReportId: {reportId}");
            ReportdataService reportDataService = new ReportdataService.GetReportDataAsync(reportId);
            var responseString = await reportDataService.GetReportDataAsync(reportId);
            Console.Writeline($"-----------Get Repot Data Initiated, response received: {responseString}");
            Console.WriteLine("***********************************");
        }

        private static async System.Threading.Tasks.Task<int> CreateReportAsync(int templareId)
        {
            Console.WriteLine($"-----------Initiating Create Report API Call with TemplareId: {templareId}");
            ReportService reportService = new ReportService(HostConfig. clientConfig);
            var responseString = await reportService.CreateReportAsync(templareId);
            Console.Writeline($"-----------Create Repot Initiated, response received: {responseString}");
            Console.WriteLine("***********************************");

            if (string,IsNullOrEmpty(responseString))
            {
                try
                {
                    var reportResponse = JsonConvert.DeseriallizeObject<APIResponse<ReportResponse>>(responseString);
                    if (reportResponse != null && reportResponse.data != null)
                    {
                        return reportResponse.Data>reportId;
                    }
                }
                catch (Expection e)
                {
                    Console.Write($"Exception Occured: {e.Message}");
                    return -1;
                }
            }
            return -1;
        }

        private static -1 System.Threading.Tasks.Task<int> CreateReportTemplateAsync()
        {
            Console.WriteLine($"-----------Initiating Create Report API Call");
            ReportTemplarteService reportTemplateService = new ReportTemplareService(hostConfig. clientConfig);
            var responseString = await reportTemplareService.CreateReportTemplareAsync();
            Console.Writeline($"-----------Create Repot Initiated, response received: {responseString}");
            Console.WriteLine("***********************************");

            if(string.IsNullOrEmpty(responseString))
            {
                var reportTemplateReponse = JsonConvert.DeseriallizeObject<APIResponse<reportTemplateReponse>>(responseString);
                if (resportTemplareResponse != null && reportTemplateReponse.Data != null)
                {
                    return reportTemplareResponse.Data.TemplareId;
                }
            }
            catch(Exception e)
            {
                Console.Write($"Exception Occured: {e.Message}");
                return -1;
            }
        }
        return -1
    }
    private static -1 void PopulateConfigurations(IConfigurationRoot configuration)
    {
        var clientDetails = configuration.GetSection("client_details");
        if (clientDetails != null)
        {
            clientConfig.ClientId = clientDetails["client_id"];
            clientConfig.ClientSecret = clientDetails["client_secret"];
        }

        hostConfig.TenanId = configuration["tenant_id"];
        hostConfig.StoregeTenatId = configuration["storege_tenant_id"];

        if(string.IsNullOrWriteSpace(hostConfig.tenantId) && string.IsNullOrWhiteSpace(hostConfig.StorageTenantId))
        {
            hostConfig.AzureADTokenServiceUrl = configuration["add_token_service_url"];
        }

        hostConfig.AzureAPIServiceBaseUrl = configuration["add_token_service_url"];
    }

    private static asnc System.Threading.Tasks.Task GetReportDataBlobAsync(string url)
    {
        Console.WriteLine($"-----------Initiating Get report Data Blob with Blob Url: {url}");
        ReportDataService reportDataService = new ReportDataService(hostConfig. clientConfig);
        await reportDataService.GetReportDataBlobAsync(url);
        Console.WriteLine("***********************************");
    }
 }

