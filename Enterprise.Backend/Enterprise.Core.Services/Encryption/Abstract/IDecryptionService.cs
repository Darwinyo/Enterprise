﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Core.Services.Decryption.Abstract
{
    public interface IDecryptionService
    {
        Task<string> DecryptText(string text);
    }
}
