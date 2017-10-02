using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Helpers.Consts;
using Enterprise.Services.Decryption.Abstract;

namespace Enterprise.Services.Encryption
{
    public class DecryptionService: Bypasser<string,string>,IDecryptionService
    {
        public async Task<string> DecryptText(string text)
        {
            return await this.PostAction(WorkflowServiceClient.Decryption, text);
        }
    }
}
