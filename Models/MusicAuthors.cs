namespace MusicShop.Models;

public class MusicAuthors
{
    public int MusicId { get; set; }
    public Music Music { get; set; }
    
    public int EnsembleId { get; set; }
    public Ensemble Ensemble { get; set; }
}