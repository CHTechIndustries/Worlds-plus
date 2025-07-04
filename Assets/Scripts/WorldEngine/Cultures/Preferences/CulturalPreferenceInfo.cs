using ProtoBuf;

[ProtoContract]
[ProtoInclude(100, typeof(CulturalPreference))]
public class CulturalPreferenceInfo : IKeyedValue<string>, ISynchronizable
{
    [ProtoMember(1)]
    public string Id;

    public string Name;

    public int RngOffset;

    public CulturalPreferenceInfo()
    {
    }

    public CulturalPreferenceInfo(string id, string name, int rngOffset)
    {
        Id = id;
        Name = name;
        RngOffset = rngOffset;
    }

    public CulturalPreferenceInfo(CulturalPreferenceInfo basePreference)
    {
        Id = basePreference.Id;
        Name = basePreference.Name;
        RngOffset = basePreference.RngOffset;
    }

    public string GetKey()
    {
        return Id;
    }

    public virtual void Synchronize()
    {
    }

    public virtual void FinalizeLoad()
    {
        PreferenceGenerator generator = World.GetPreferenceGenerator(Id);

        if (generator == null)
        {
            throw new System.Exception("Unable to load preference generator: " + Id);
        }

        Name = generator.Name;
        RngOffset = generator.IdHash;
    }
}
