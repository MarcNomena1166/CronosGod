using Cronos;

namespace CronosGod
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _schedule = "1-59/2 * * * * * ";
        public Function _function;
   
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
                Console.WriteLine("le plannificateur marche dans: "+(DateTime.UtcNow+delay));            
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