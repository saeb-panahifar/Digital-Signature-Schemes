namespace CryptographyTests.Core;

public record DigitalSignatureSignResult
{
    public byte[] SignatureBytes { get; }
    public string SignatureText => Convert.ToBase64String(HashBytes);

    public byte[] HashBytes { get; }
    public string HashText => Convert.ToBase64String(HashBytes);

    public DigitalSignatureSignResult(byte[] signature, byte[] hashedData)
    {
        SignatureBytes = signature;
        HashBytes = hashedData;
    }
}
