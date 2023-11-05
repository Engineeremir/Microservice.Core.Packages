﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Core.Packages.Security.OtpAuthenticator;

public interface IOtpAuthenticatorHelper
{
    public Task<byte[]> GenerateSecretKey();
    public Task<string> ConvertSecretKeyToString(byte[] secretKey);
    public Task<bool> VerifyCode(byte[] secretKey, string code);
}
