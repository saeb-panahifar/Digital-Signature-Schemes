namespace CryptographyTests.Core;

public record DigitalSignatureKeyPairResult
{
    public byte[] PrivateKeyBytes { get; }
    public string PrivateKeyString => Convert.ToBase64String(PrivateKeyBytes);

    public byte[] PublicKeyBytes { get; }
    public string PublicKeyString => Convert.ToBase64String(PublicKeyBytes);

    public DigitalSignatureKeyPairResult(byte[] privateKey, byte[] publicKey)
    {
        PrivateKeyBytes = privateKey;
        PublicKeyBytes = publicKey;
    }
}
