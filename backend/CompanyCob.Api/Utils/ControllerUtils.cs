using Flunt.Notifications;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CompanyCob.Api.Utils
{
    public abstract class ControllerUtils
    {
        public static void LogErros(string mensagem, Notifiable model, ILogger logger)
        {
            logger.LogInformation(mensagem);
            foreach (var notificacao in model.Notifications)
            {
                logger.LogInformation("* {0}", notificacao.Message);
            }
        }

        public static void LogErros(string mensagem, List<string> erros, ILogger logger)
        {
            logger.LogInformation(mensagem);
            foreach (var erro in erros)
            {
                logger.LogInformation("* {0}", erro);
            }
        }
    }
}
