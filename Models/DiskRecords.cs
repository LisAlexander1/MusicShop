namespace MusicShop.Models;

public class DiskRecords
{
    public int DiskId { get; set; }
    public Disk Disk { get; set; }
    
    public int MusicVersionId { get; set; }
    public MusicVersion MusicVersion { get; set; }
}