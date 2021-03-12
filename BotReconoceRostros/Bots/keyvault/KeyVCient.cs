using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace BotReconoceRostros.Bots.keyvault
{
    /*Esta clase la usaremos para conectarnos a nuestro
     * repositorio de llaves para extraer el api key de 
     * computer vision. Datos que necesitamos:
     * TenantID, ClienteID= esta información la obtenemos registrando nuestra aplicacion como una identidad
     * SECRE_CLIENT= dentro del Azure AD tenemos que generar una llave para nuestra app 
     * KeyVAULt= url del servicio Azure Key Vault 
     */
    public class KeyVCient
    {
        private static readonly string CLIENTE_ID = "fe228b85-d650-42da-b574-a59003093aa4";
        private static readonly string TENANT_ID = "8f801786-dcd2-4f6b-b81e-f961ea9a9e20";
        private static readonly string SECRET_CLIENT = "_i.r~HQRogy-3o2Q~6azrU8.mAw4ZxU33v";
        private static readonly string KEYVAULT = "https://keyvaultvefe.vault.azure.net/";

        public static SecretClient Secret { get; private set; }
        static KeyVCient() { InitSecret(); }
          

        /*
         * Utilizamos el patrón singleton para evitar que se conecten
         * al servicio más de  una vez
         */
        private static void InitSecret() {
            if (Secret == null) {
                var credential = new ClientSecretCredential(TENANT_ID, CLIENTE_ID, SECRET_CLIENT);
                Secret = new SecretClient(new Uri(KEYVAULT), credential);
            }
        }


    }
}
