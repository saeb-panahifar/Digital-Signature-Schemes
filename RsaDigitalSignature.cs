using System.Security.Cryptography;
using System.Text;

namespace CryptographyTests.Core;

public static class RsaDigitalSignature
{
    // * You need to sign hash of your message.

    public static DigitalSignatureKeyPairResult CreateKeyPair(int keyLengthInBytes)
    {
        using var rsa = RSA.Create(keyLengthInBytes);
        var privateKey = rsa.ExportRSAPrivateKey();
        var publicKey = rsa.ExportRSAPublicKey();
        return new DigitalSignatureKeyPairResult(privateKey, publicKey);
    }

    public static DigitalSignatureSignResult Sign(string signMessage, byte[] privateKey)
    {
        var hashedMessage = HashMessage(signMessage);

        using var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(privateKey, out _);

        var signature = rsa.SignHash(hashedMessage, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        return new DigitalSignatureSignResult(signature, hashedMessage);
    }

    private static byte[] HashMessage(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        using var hasher = SHA256.Create();
        return hasher.ComputeHash(bytes);
    } 
    
    public static DigitalVerifyResult Verify(byte[] signature, byte[] publicKey, byte[] hashOfData)
    {
        using var rsa = RSA.Create();
        rsa.ImportRSAPublicKey(publicKey, out _);

        var result = rsa.VerifyHash(hashOfData, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        return new DigitalVerifyResult(result);
    }
}
