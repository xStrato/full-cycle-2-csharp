namespace MicroVideosCatalog.Domain.Entities;
public record CastMember : Entity
{
    public string Name { get; private set; }
    public ECastMemberType CastMemberType { get; private set; }
    protected CastMember() { }
    public CastMember(string name, ECastMemberType castMemberType) : base()
        => (Name, CastMemberType) = (name, castMemberType);
    public CastMember(Guid id, string name, ECastMemberType castMemberType) : base(id)
        => (Name, CastMemberType) = (name, castMemberType);

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("'name' cannot be empty or null");
        Name = name;
    }

    public void SetCastMemberType(ECastMemberType castMemberType)
        => CastMemberType = castMemberType;

    public void SetCastMemberType(string castMemberType)
    {
        if (string.IsNullOrEmpty(castMemberType))
            throw new ArgumentException("'castMemberType' cannot be empty or null");

        if (Enum.TryParse<ECastMemberType>(castMemberType, out var parsedEnum) is false)
            throw new ArgumentException($"'{castMemberType}' cannot be parsed as valid 'ECastMemberType'");

        CastMemberType = parsedEnum;
    }
}