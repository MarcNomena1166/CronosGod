using Cronos;

namespace CronosGod
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _schedule = "* 1-59/2 1-23/2 1-31/2 1-11/2 *";
        public Function _function;
        //"* */15 */6 1-59/2 */4 *";
        public Worker(ILogger<Worker> logger,Function f)
        {
            _logger = logger;
            _function = f;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
         
            while (!stoppingToken.IsCancellationRequested)
            {
                TimeSpan delay = _function.calculateDelay(_schedule);
                Console.WriteLine("le plannificateur marche dans: "+delay);            
               // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(delay, stoppingToken);
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}