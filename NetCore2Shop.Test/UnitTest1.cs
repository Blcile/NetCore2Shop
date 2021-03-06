using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore2Shop.Common;

namespace NetCore2Shop.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TextEncrypt()
        {
            System.Console.WriteLine(Encryption.EncryptText("sjdnwlsdadd"));
            //adfc 9SCBakFUYUA=
            //sjdnwlsdadd Iuj+JqdD7il2B2eA+yOsRg==
        }

        [TestMethod]
        public void TextDencrypt()
        {
            Console.WriteLine(Encryption.DecrpytText("h+iGBH1sz2U="));
        }

        [TestMethod]
        public void ValidateCode()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Common.ValidateCode.CreateValidateCode(4));
            }
        }
        
        [TestMethod]
        public void ValidateCodeImg()
        {
            var code = new ValidateCode();
            var c = Common.ValidateCode.CreateValidateCode(4);
            Console.WriteLine(c);
            Console.WriteLine(Convert.ToBase64String(Common.ValidateCode.CreateValidateGraphic(c)));
        }
    }
}
