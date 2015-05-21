namespace Ccom.Pharmacy.Helpers
{
    public enum PassPortScannerEnums
    {
        InsertPassportOrId,
        ScanningInProgress,
        CollectDocument,
    }

    public enum CreditCardReaderEnums
    {
        InsertCreditCard,
        ReadingInProgress,
        EjectCard,
        CollectCard
    }

    public enum KeyCardEncoderEnums
    {
        EncodingInProgress,
        CollectKeyCard,
        RemoveState
    }

    public enum CardType
    {
        Invalid,
        Unknown,
        AmericanExpress,
        Bankcard,
        DinersClubInternational,
        DinersClubUSandCanada,
        DiscoverCard,
        JCB,
        Maestro,
        MasterCard,
        SoloDebit,
        SwitchDebit,
        Visa,
        VisaElectron,
        EnRoute
    }

    public enum CardTypeOWS
    {
        AX,
        DC,
        JC,
        MC,
        VA,
    }

    public enum PassPortScanner
    {
        UnableToRead,
        WrongInformation,
        Successful
    }
}
