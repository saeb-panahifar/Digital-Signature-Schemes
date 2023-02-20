// See https://aka.ms/new-console-template for more information

using CryptographyTests.Core;

var message = "This is a test message!";

var keys = RsaDigitalSignature.CreateKeyPair(4096);

var signed = RsaDigitalSignature.Sign(message, keys.PrivateKeyBytes);

var verify = RsaDigitalSignature.Verify(signed.SignatureBytes, keys.PublicKeyBytes, signed.HashBytes);

Console.WriteLine("**");
Console.WriteLine("RSA DigitalSignature");
Console.WriteLine($"Text: {message}");
Console.WriteLine($"Public Key: {keys.PublicKeyString}  ({keys.PublicKeyBytes.Length} bytes length)");
Console.WriteLine($"Private Key: {keys.PrivateKeyString}  ({keys.PrivateKeyBytes.Length} bytes length)");
Console.WriteLine($"Signature: {signed.SignatureText}  ({signed.SignatureBytes.Length} bytes length)");
Console.WriteLine($"Signature Hash: {signed.HashText}  ({signed.HashBytes.Length} bytes length)");
Console.WriteLine($"Verify: {verify.IsValid}");
Console.WriteLine("**");



