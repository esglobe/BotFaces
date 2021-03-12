using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace BotReconoceRostros.Bots.computer
{
    public class ComputerTaks
    {
        private static readonly ComputerVisionClient CLIENTE = ComputerClient.Vision;

        public static async Task<List<Rostro>> GetRostros(Stream str) {
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                VisualFeatureTypes.Faces
            };
            var resultado = await CLIENTE.AnalyzeImageInStreamAsync(str, features, language:"es");
            var faces = resultado.Faces.ToList();
            var objects = from tmp in faces
                          select new Rostro()
                          {
                              Gender = tmp.Gender.ToString(),
                              Age = tmp.Age
                              
                          };
            return objects.ToList();

        }



    }
}
