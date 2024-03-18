namespace AccountingComputerEquipment.Client.Data
{
    [Flags]
    public enum LevelEnum: int
    {
        Admin = 1 << 10, // 1024
        Level1 = 1 << 0, // 1
        Level2 = 1 << 1, // 2
        Level3 = 1 << 2, // 4
        Level4 = 1 << 3, // 8
    }
}
