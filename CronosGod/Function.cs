using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cronos;
namespace CronosGod
{
    public class Function
    {
        public TimeSpan calculateDelay(string expression) 
        {
            CronExpression expressedCron = CronExpression.Parse(expression, CronFormat.IncludeSeconds);
            DateTime? next = expressedCron.GetNextOccurrence(DateTime.UtcNow);
            Console.WriteLine("Today is: " + (DateTime.UtcNow));
            Console.WriteLine("The next date is: " + (next.Value));
         
            if (next == null) { throw new ArgumentException("l'expression est invalide"); }
         
            return next.Value - DateTime.UtcNow;
        }
    }
}
