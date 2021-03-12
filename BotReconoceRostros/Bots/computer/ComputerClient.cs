using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using BotReconoceRostros.Bots.keyvault;

namespace BotReconoceRostros.Bots.computer
{
    /*
     * Esta clase la usaremos para conectarnos
     * al servicio Computer vision de Azure
     * Datos que necesitamos:
     * Nombre Secret: Necesitamos en nombre de la llave que vamos a obtener de Azure KeyVault
     * EndpointService: El url de acceso de computer vision
     */
    public class ComputerClient
    {
        private static readonly string ENDPOINT = "https://computerenvf.cognitiveservices.azure.com/";
        public static ComputerVisionClient Vision { get; private set; }
        

        static ComputerClient(){ InitComputer(); }

        private static void InitComputer() {
            if (Vision==null) {
                var key = KeyVCient.Secret.GetSecret("computerV").Value.Value;
                var credentials = new ApiKeyServiceClientCredentials(key);
                Vision = new ComputerVisionClient(credentials) { Endpoint=ENDPOINT};
            }  
        }


    }
}
