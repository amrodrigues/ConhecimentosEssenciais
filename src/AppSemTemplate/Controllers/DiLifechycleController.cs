using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppSemTemplate.Controllers
{
    [Route("teste-id")]
    public class DiLifechycleController : Controller
    {
        //  public IOperacao Operacao { get;set; }

        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public IServiceProvider ServiceProvider { get; }
        public DiLifechycleController(OperacaoService operacaoService,
                                      OperacaoService operacaoService2,
                                      IServiceProvider serviceProvider)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
            ServiceProvider = serviceProvider;
        }
        public string Index()
        {

            return
                "Primeira instância: " + Environment.NewLine + OperacaoService.Trasnient.OperacaoId + Environment.NewLine +

                 OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                 OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                 OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine + "Segunda instância: " + Environment.NewLine +
                OperacaoService2.Trasnient.OperacaoId + Environment.NewLine +
                OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }

        [Route("teste")]
        public string Teste([FromServices] OperacaoService operacaoService)
        {
            return OperacaoService.Trasnient.OperacaoId + Environment.NewLine +

                 OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                 OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                 OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine;
        }

        [Route("view")]
        public IActionResult ViewTeste()
        {
            return View("Index");
        }

        [Route("container")]
        public string TesteContainer()
        {
            using (var serviceScope = ServiceProvider.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
              
               var singService = services.GetRequiredService<IOperacaoSingleton>();

                return  "Instancia Singleton "+ Environment.NewLine +
                    singService.OperacaoId + Environment.NewLine 
                  ;
            }

        }


    }

   
}
