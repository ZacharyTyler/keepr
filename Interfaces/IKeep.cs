

namespace keepr.Interfaces
{
  public class IKeep
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string UserId { get; set; }
    string Img { get; set; }
    bool IsPrivate { get; set; }
    int Views { get; set; }
    int Keeps { get; set; }
  }
}
