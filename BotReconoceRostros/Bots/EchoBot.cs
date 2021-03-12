// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.11.1

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using BotReconoceRostros.Bots.computer;
using System.Text;

namespace BotReconoceRostros.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            if (turnContext.Activity.Attachments?.Count > 0)
            {
                //primero probamos que el usuario cargue una imagen
                //si existe una imagen obtenemos el url
                var content = turnContext.Activity.Attachments[0];
                //abrimos un cliente http
                var http = new HttpClient();

                //del post obtenemos el url y convertimos a un stream
                var imagen = await http.GetStreamAsync(content.ContentUrl);

                //Verificamos que no sea nulo el stream
                if (imagen != null) {
                    var faces = await ComputerTaks.GetRostros(imagen);
                    StringBuilder build = new StringBuilder("-.-.Los rostros encontrados son:-.-.-.");
                    foreach(var tmp in faces) {
                        build.Append("Género: ").Append(tmp.Gender).Append(" ")
                            .Append("Edad: ").Append(tmp.Age).Append("\n");
                        
                    }
                    await turnContext.SendActivityAsync(MessageFactory.Text(build.ToString()));

                }


            }

        }
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Bienvenido a mi Bot que reconoce rostros en imagenes";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
