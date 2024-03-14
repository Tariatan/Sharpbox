namespace Sharpbox;

public class MnemonicPair
{
    public Mnemonic Mnemonic { get; }
    public Planets Planet { get; }

    public MnemonicPair(Planets planet, Mnemonic mnemonic)
    {
        Planet = planet;
        Mnemonic = mnemonic;
    }
}